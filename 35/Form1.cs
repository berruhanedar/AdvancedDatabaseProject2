using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Text;

namespace _35
{
    public partial class Form1 : Form
    {
        String? connectionString;
        String? selectedDataBase;
        private int A_deadlockCount;
        private int B_deadlockCount;
        private readonly String Database_WithIndexes = "Data Source=DESKTOP-GI81Q2S\\SQLEXPRESS;Initial Catalog=AdventureWorks2022_WithIndexes;Integrated Security=True;";
        private readonly String Database_WithoutIndexes = "Data Source=DESKTOP-GI81Q2S\\SQLEXPRESS;Initial Catalog=AdventureWorks2022_WithoutIndexes;Integrated Security=True;";       
        public Form1()
        {
            InitializeComponent();
            btnStart.Click += btnStart_Click;
            A_deadlockCount = 0;
            B_deadlockCount = 0;

            string[] isolationLevels = { "Read Uncommitted", "Read Committed", "Repeatable Read", "Serializable" };
            foreach (var level in isolationLevels)
            {
                comboBoxIsolation.Items.Add(level);
            }
            comboBoxIsolation.SelectedIndex = 0;

            string[] databaseOptions = { "AdventureWorks2022-Without Indexes", "AdventureWorks2022-With Indexes" };
            foreach (var option in databaseOptions)
            {
                comboBoxIndex.Items.Add(option);
            }
            comboBoxIndex.SelectedIndex = 0; 
        }


        private async void btnStart_Click(object? sender, EventArgs e)
        {
            try
            {
                var message = new StringBuilder();
                message.AppendLine("Valid inputs provided.");
                message.AppendLine("Simulation is ready to run.");
                Console.WriteLine(message.ToString());

                Thread.Sleep(700);
                Console.WriteLine("Starting the simulation...");

                Stopwatch stopwatch = Stopwatch.StartNew();

                int numberOfTypeAUsers = int.Parse(numericUpDownTypeA.Value.ToString());
                int numberOfTypeBUsers = int.Parse(numericUpDownTypeB.Value.ToString());
                int selectedIsolationLevel = comboBoxIsolation.SelectedIndex;
                IsolationLevel isolationLevel = GetIsolationLevel(selectedIsolationLevel);
                int selectedDatabase_Index = comboBoxIndex.SelectedIndex;
                connectionString = SelectedDatabaseVersion(selectedDatabase_Index);

                
                int totalTransactions = numberOfTypeAUsers + numberOfTypeBUsers;
                int completedTransactions = 0;

                var tasks = new List<Task>();
                for (int i = 0; i < numberOfTypeAUsers; i++)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        try
                        {
                            TypeAUserThread(connectionString, isolationLevel);
                        }
                        finally
                        {
                            Interlocked.Increment(ref completedTransactions);
                            UpdateProgress(completedTransactions, totalTransactions);
                        }
                    }));
                }

                for (int i = 0; i < numberOfTypeBUsers; i++)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        try
                        {
                            TypeBUserThread(connectionString, isolationLevel);
                        }
                        finally
                        {
                            Interlocked.Increment(ref completedTransactions);
                            UpdateProgress(completedTransactions, totalTransactions);
                        }
                    }));
                }             

                stopwatch.Stop();
                TimeSpan elapsedTime = stopwatch.Elapsed;
                double elapsedSeconds = elapsedTime.TotalSeconds;
                double elapsedA = elapsedSeconds / numberOfTypeAUsers;
                double elapsedB = elapsedSeconds / numberOfTypeBUsers;


                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Database: {selectedDataBase}\nIsolation level: {isolationLevel}\nAverage Duration(sec) (Type A): {elapsedA} seconds\nAverage Duration(sec) (Type B): {elapsedB} seconds\nDeadlocks (Type A): {A_deadlockCount}\nDeadlocks (Type B): {B_deadlockCount}", "Simulation Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));

                if (!Console.IsOutputRedirected)
                {
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        private void UpdateProgress(int completedTransactions, int totalTransactions)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int, int>(UpdateProgress), new object[] { completedTransactions, totalTransactions });
            }
            else
            {
                int progress = (int)((double)completedTransactions / totalTransactions * 100);
            }
        }

        private IsolationLevel GetIsolationLevel(int selectedIndex)
        {
            var isolationLevels = new Dictionary<int, IsolationLevel>
            {
                { 0, IsolationLevel.ReadUncommitted },
                { 1, IsolationLevel.ReadCommitted },
                { 2, IsolationLevel.RepeatableRead },
                { 3, IsolationLevel.Serializable }
             };

            return isolationLevels.ContainsKey(selectedIndex) ? isolationLevels[selectedIndex] : IsolationLevel.ReadUncommitted;
        }

        private String SelectedDatabaseVersion(int selectedDatabase_Index)
        {
            switch (selectedDatabase_Index)
            {
                case 0:
                    selectedDataBase = "AdventureWorks2022-Without Indexes";
                    return Database_WithoutIndexes;
                case 1:
                    selectedDataBase = "AdventureWorks2022-With Indexes";
                    return Database_WithIndexes;
                default:
                    selectedDataBase = "AdventureWorks2022-Without Indexes";
                    return Database_WithoutIndexes; 
            }
        }

        private void TypeAUserThread(string connectionString, IsolationLevel isolationLevel)
        {
            Random rand = new Random();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(isolationLevel))
                {
                    try
                    {
                        Random rnd = new Random();
                        for (int i = 0; i < 100; i++)
                        {
                            if (rand.NextDouble() < 0.5)
                                ExecuteUpdateQuery(connection, transaction, "20110101", "20111231");
                            if (rand.NextDouble() < 0.5)
                                ExecuteUpdateQuery(connection, transaction, "20120101", "20121231");
                            if (rand.NextDouble() < 0.5)
                                ExecuteUpdateQuery(connection, transaction, "20130101", "20131231");
                            if (rand.NextDouble() < 0.5)
                                ExecuteUpdateQuery(connection, transaction, "20140101", "20141231");
                            if (rand.NextDouble() < 0.5)
                                ExecuteUpdateQuery(connection, transaction, "20150101", "20151231");
                        }
                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        if (transaction != null && ex.Number == 1205) // Deadlock
                        {
                            A_deadlockCount++;
                            transaction.Rollback();
                        }
                        else if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                    }

                }
            }
            stopwatch.Stop();
            var elapsed = stopwatch.Elapsed;
            Console.WriteLine($"Elapsed time for Type A user: {elapsed.TotalSeconds:F4} seconds");
        }
        private void TypeBUserThread(string connectionString, IsolationLevel isolationLevel)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Random rand = new Random();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                for (int i = 0; i < 100; i++)
                {
                    using (var transaction = connection.BeginTransaction(isolationLevel))
                    {
                        try
                        {
                            if (rand.NextDouble() < 0.5)
                                ExecuteSelectQuery(connection, transaction, "20110101", "20111231");
                            if (rand.NextDouble() < 0.5)
                                ExecuteSelectQuery(connection, transaction, "20120101", "20121231");
                            if (rand.NextDouble() < 0.5)
                                ExecuteSelectQuery(connection, transaction, "20130101", "20131231");
                            if (rand.NextDouble() < 0.5)
                                ExecuteSelectQuery(connection, transaction, "20140101", "20141231");
                            if (rand.NextDouble() < 0.5)
                                ExecuteSelectQuery(connection, transaction, "20150101", "20151231");
                            transaction.Commit();
                        }
                        catch (SqlException ex)
                        {
                            if (transaction != null && ex.Number == 1205) // Deadlock
                            {
                                B_deadlockCount++;
                                transaction.Rollback();
                            }
                            else if (transaction != null)
                            {
                                transaction.Rollback();
                            }
                        }

                    }
                }
            }

            stopwatch.Stop();
            var elapsed = stopwatch.Elapsed;
            Console.WriteLine($"Elapsed time for Type B user: {elapsed.TotalSeconds} seconds");
        }


        static void ExecuteUpdateQuery(SqlConnection connection, SqlTransaction transaction, string beginDate, string endDate)
        {
            string updateQuery = @"
            UPDATE Sales.SalesOrderDetail
            SET UnitPrice = UnitPrice * 10.0 / 10.0
            WHERE UnitPrice > 100
            AND EXISTS (
                SELECT * FROM Sales.SalesOrderHeader
                WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID
                AND Sales.SalesOrderHeader.OrderDate BETWEEN @BeginDate AND @EndDate
                AND Sales.SalesOrderHeader.OnlineOrderFlag = 1
            )";

            using (var cmd = new SqlCommand(updateQuery, connection, transaction))
            {
                cmd.CommandTimeout = 180;
                cmd.Parameters.AddWithValue("@BeginDate", beginDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.ExecuteNonQuery();


                try
                {
                    // Sorgunun başlangıç zamanını kaydedin
                    var start = DateTime.Now;
                    Console.WriteLine("Executing Sales Order Update Query at " + start.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                    // Sorguyu çalıştırın
                    cmd.ExecuteNonQuery();

                    // Sorgunun bitiş zamanını kaydedin
                    var end = DateTime.Now;
                    Console.WriteLine("Sales Order Update Query completed at " + end.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                    // Sorgunun ne kadar sürdüğünü hesaplayın ve konsola yazdırın
                    var elapsed = end - start;
                    Console.WriteLine($"Sales Order Update Query completed in {elapsed.TotalSeconds} seconds");
                }
                catch (Exception ex)
                {
                    // Hata durumunda hata mesajını konsola yazdırın
                    Console.WriteLine("SQL Command Error: " + ex.Message);
                }
            }
        }

        static void ExecuteSelectQuery(SqlConnection connection, SqlTransaction transaction, string beginDate, string endDate)
        {
            string selectQuery = @"
        SELECT SUM(Sales.SalesOrderDetail.OrderQty)
        FROM Sales.SalesOrderDetail
        WHERE UnitPrice > 100
        AND EXISTS (
            SELECT * FROM Sales.SalesOrderHeader
            WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID
            AND Sales.SalesOrderHeader.OrderDate BETWEEN @BeginDate AND @EndDate
            AND Sales.SalesOrderHeader.OnlineOrderFlag = 1
        )";

            using (var command = new SqlCommand(selectQuery, connection, transaction))
            {
                command.CommandTimeout = 180;
                command.Parameters.AddWithValue("@BeginDate", beginDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                try
                {
                    var start = DateTime.Now;
                    var result = command.ExecuteScalar();
                    var end = DateTime.Now;
                    var elapsed = end - start;
                    Console.WriteLine($"Select query executed in {elapsed.TotalSeconds:F4} seconds. Result: {result?.ToString() ?? "No result"}");
                }
                catch (Exception ex)
                {
                    // Hata durumunda hata mesajını konsola yazdırın
                    Console.WriteLine("SQL Command Error: " + ex.Message);
                }
            }
        }





        private void comboBoxIsolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox'ın seçimi değiştiğinde gerektiğinde bir işlem yapılabilir
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDownTypeA_ValueChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

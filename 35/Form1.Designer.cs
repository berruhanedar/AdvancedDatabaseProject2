
namespace _35
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            imageList1 = new ImageList(components);
            comboBoxIsolation = new ComboBox();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnStart = new Button();
            button2 = new Button();
            numericUpDownTypeA = new NumericUpDown();
            numericUpDownTypeB = new NumericUpDown();
            label7 = new Label();
            comboBoxIndex = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTypeA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTypeB).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(5, 5);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // comboBoxIsolation
            // 
            comboBoxIsolation.BackColor = Color.FromArgb(55, 61, 85);
            comboBoxIsolation.ForeColor = Color.White;
            comboBoxIsolation.FormattingEnabled = true;
            comboBoxIsolation.Location = new Point(63, 342);
            comboBoxIsolation.Name = "comboBoxIsolation";
            comboBoxIsolation.Size = new Size(427, 28);
            comboBoxIsolation.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(31, 41, 55);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 72);
            panel1.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(258, 20);
            label6.Name = "label6";
            label6.Size = new Size(261, 31);
            label6.TabIndex = 8;
            label6.Text = "PERFORMANCE REPORT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(231, 8);
            label5.Name = "label5";
            label5.Size = new Size(31, 46);
            label5.TabIndex = 8;
            label5.Text = "|";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(28, 15);
            label4.Name = "label4";
            label4.Size = new Size(199, 38);
            label4.TabIndex = 0;
            label4.Text = "SALES ORDER";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(61, 109);
            label1.Name = "label1";
            label1.Size = new Size(175, 20);
            label1.TabIndex = 4;
            label1.Text = "Number of Type A Users";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(60, 210);
            label2.Name = "label2";
            label2.Size = new Size(178, 20);
            label2.TabIndex = 5;
            label2.Text = "Number of Type B Users ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(60, 311);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 7;
            label3.Text = "Select Isolation Level ";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(55, 61, 85);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(396, 141);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 8;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(55, 61, 85);
            button2.ForeColor = Color.White;
            button2.Location = new Point(396, 242);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "STOP";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // numericUpDownTypeA
            // 
            numericUpDownTypeA.BackColor = Color.FromArgb(55, 61, 85);
            numericUpDownTypeA.ForeColor = Color.White;
            numericUpDownTypeA.Location = new Point(63, 141);
            numericUpDownTypeA.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownTypeA.Name = "numericUpDownTypeA";
            numericUpDownTypeA.Size = new Size(200, 27);
            numericUpDownTypeA.TabIndex = 11;
            numericUpDownTypeA.ValueChanged += numericUpDownTypeA_ValueChanged;
            // 
            // numericUpDownTypeB
            // 
            numericUpDownTypeB.BackColor = Color.FromArgb(55, 61, 85);
            numericUpDownTypeB.ForeColor = Color.White;
            numericUpDownTypeB.Location = new Point(63, 242);
            numericUpDownTypeB.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownTypeB.Name = "numericUpDownTypeB";
            numericUpDownTypeB.Size = new Size(200, 27);
            numericUpDownTypeB.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(63, 409);
            label7.Name = "label7";
            label7.Size = new Size(171, 20);
            label7.TabIndex = 16;
            label7.Text = "Select Database Version";
            // 
            // comboBoxIndex
            // 
            comboBoxIndex.BackColor = Color.FromArgb(55, 61, 85);
            comboBoxIndex.ForeColor = Color.White;
            comboBoxIndex.FormattingEnabled = true;
            comboBoxIndex.Location = new Point(66, 440);
            comboBoxIndex.Name = "comboBoxIndex";
            comboBoxIndex.Size = new Size(424, 28);
            comboBoxIndex.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(642, 536);
            Controls.Add(label7);
            Controls.Add(comboBoxIndex);
            Controls.Add(numericUpDownTypeB);
            Controls.Add(numericUpDownTypeA);
            Controls.Add(button2);
            Controls.Add(btnStart);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(comboBoxIsolation);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "PERFORMANCE REPORT SIMULATION";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTypeA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTypeB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        #endregion
        private ImageList imageList1;
        private ComboBox comboBoxIsolation;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label6;
        private Button btnStart;
        private Button button2;
        private NumericUpDown numericUpDownTypeA;
        private NumericUpDown numericUpDownTypeB;
        private Label label7;
        private ComboBox comboBoxIndex;
    }
}

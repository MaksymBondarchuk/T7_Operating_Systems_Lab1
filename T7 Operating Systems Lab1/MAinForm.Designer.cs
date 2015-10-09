namespace T7_Operating_Systems_Lab1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lTasks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.nudPossibility = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.OneTact = new System.Windows.Forms.Timer(this.components);
            this.lQueue = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bBegin = new System.Windows.Forms.Button();
            this.lAverage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerTest = new System.Windows.Forms.Timer(this.components);
            this.cbTestMode = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudPossibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            this.SuspendLayout();
            // 
            // lTasks
            // 
            this.lTasks.AutoArrange = false;
            this.lTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lTasks.GridLines = true;
            this.lTasks.Location = new System.Drawing.Point(12, 141);
            this.lTasks.Name = "lTasks";
            this.lTasks.Size = new System.Drawing.Size(455, 483);
            this.lTasks.TabIndex = 0;
            this.lTasks.UseCompatibleStateImageBehavior = false;
            this.lTasks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 62;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Spawned on";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Length (in tacts)";
            this.columnHeader3.Width = 114;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Completed on";
            this.columnHeader4.Width = 101;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Delay";
            this.columnHeader5.Width = 86;
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(230, 90);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Enabled = false;
            this.bStop.Location = new System.Drawing.Point(311, 90);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 2;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // nudPossibility
            // 
            this.nudPossibility.DecimalPlaces = 2;
            this.nudPossibility.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudPossibility.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudPossibility.Location = new System.Drawing.Point(12, 41);
            this.nudPossibility.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPossibility.Name = "nudPossibility";
            this.nudPossibility.Size = new System.Drawing.Size(109, 22);
            this.nudPossibility.TabIndex = 3;
            this.nudPossibility.ThousandsSeparator = true;
            this.nudPossibility.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Spawn possibility";
            // 
            // OneTact
            // 
            this.OneTact.Interval = 50;
            this.OneTact.Tick += new System.EventHandler(this.OneTact_Tick);
            // 
            // lQueue
            // 
            this.lQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lQueue.GridLines = true;
            this.lQueue.HoverSelection = true;
            this.lQueue.Location = new System.Drawing.Point(473, 141);
            this.lQueue.Name = "lQueue";
            this.lQueue.Size = new System.Drawing.Size(128, 483);
            this.lQueue.TabIndex = 5;
            this.lQueue.UseCompatibleStateImageBehavior = false;
            this.lQueue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "#";
            this.columnHeader6.Width = 119;
            // 
            // bBegin
            // 
            this.bBegin.Enabled = false;
            this.bBegin.Location = new System.Drawing.Point(392, 90);
            this.bBegin.Name = "bBegin";
            this.bBegin.Size = new System.Drawing.Size(75, 23);
            this.bBegin.TabIndex = 6;
            this.bBegin.Text = "To begin";
            this.bBegin.UseVisualStyleBackColor = true;
            this.bBegin.Click += new System.EventHandler(this.bBegin_Click);
            // 
            // lAverage
            // 
            this.lAverage.AutoSize = true;
            this.lAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lAverage.ForeColor = System.Drawing.Color.Maroon;
            this.lAverage.Location = new System.Drawing.Point(189, 20);
            this.lAverage.Name = "lAverage";
            this.lAverage.Size = new System.Drawing.Size(0, 29);
            this.lAverage.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tasks information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(470, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Performation order";
            // 
            // timerTest
            // 
            this.timerTest.Interval = 10000;
            this.timerTest.Tick += new System.EventHandler(this.timerTest_Tick);
            // 
            // cbTestMode
            // 
            this.cbTestMode.AutoSize = true;
            this.cbTestMode.Checked = true;
            this.cbTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTestMode.Location = new System.Drawing.Point(473, 94);
            this.cbTestMode.Name = "cbTestMode";
            this.cbTestMode.Size = new System.Drawing.Size(77, 17);
            this.cbTestMode.TabIndex = 10;
            this.cbTestMode.Text = "Test Mode";
            this.cbTestMode.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Maximal task length";
            // 
            // nudLength
            // 
            this.nudLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLength.Location = new System.Drawing.Point(12, 91);
            this.nudLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(109, 22);
            this.nudLength.TabIndex = 11;
            this.nudLength.ThousandsSeparator = true;
            this.nudLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AcceptButton = this.bStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(621, 636);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudLength);
            this.Controls.Add(this.cbTestMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lAverage);
            this.Controls.Add(this.bBegin);
            this.Controls.Add(this.lQueue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudPossibility);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.lTasks);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operating Systems Lab1";
            ((System.ComponentModel.ISupportInitialize)(this.nudPossibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lTasks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.NumericUpDown nudPossibility;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer OneTact;
        private System.Windows.Forms.ListView lQueue;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button bBegin;
        private System.Windows.Forms.Label lAverage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerTest;
        private System.Windows.Forms.CheckBox cbTestMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudLength;
    }
}


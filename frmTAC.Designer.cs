namespace TACControler
{
    partial class frmTAC
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
            this.tmr10sec = new System.Windows.Forms.Timer(this.components);
            this.tabControler = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveGraph = new System.Windows.Forms.Button();
            this.btnRefreshProperties = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.btnSendPID = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PIDTempP = new System.Windows.Forms.NumericUpDown();
            this.PIDTempI = new System.Windows.Forms.NumericUpDown();
            this.PIDTempD = new System.Windows.Forms.NumericUpDown();
            this.temperatureTarget = new System.Windows.Forms.NumericUpDown();
            this.btnSetTarget = new System.Windows.Forms.Button();
            this.tabCAN = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.btnPeltierEnable = new System.Windows.Forms.Button();
            this.btnFanEnable = new System.Windows.Forms.Button();
            this.btnAgitatorEnable = new System.Windows.Forms.Button();
            this.tabTubidity = new System.Windows.Forms.TabPage();
            this.ctrCanConnector1 = new PCAN.ctrCanConnector();
            this.ctrChart1 = new TACControler.TAC.UI.ctrChartCommand();
            this.ctrProperties1 = new TACControler.TAC.UI.ctrProperties();
            this.ctrChartTurbidity1 = new TACControler.TAC.UI.ctrChartTurbidity();
            this.tabControler.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PIDTempP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIDTempI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIDTempD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureTarget)).BeginInit();
            this.tabCAN.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabTubidity.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr10sec
            // 
            this.tmr10sec.Interval = 10000;
            this.tmr10sec.Tick += new System.EventHandler(this.tmr10sec_Tick);
            // 
            // tabControler
            // 
            this.tabControler.Controls.Add(this.tableLayoutPanel1);
            this.tabControler.Controls.Add(this.btnSendPID);
            this.tabControler.Controls.Add(this.label3);
            this.tabControler.Controls.Add(this.label2);
            this.tabControler.Controls.Add(this.label1);
            this.tabControler.Controls.Add(this.PIDTempP);
            this.tabControler.Controls.Add(this.PIDTempI);
            this.tabControler.Controls.Add(this.PIDTempD);
            this.tabControler.Controls.Add(this.temperatureTarget);
            this.tabControler.Controls.Add(this.btnSetTarget);
            this.tabControler.Location = new System.Drawing.Point(4, 22);
            this.tabControler.Name = "tabControler";
            this.tabControler.Size = new System.Drawing.Size(895, 552);
            this.tabControler.TabIndex = 2;
            this.tabControler.Text = "Controler";
            this.tabControler.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctrChart1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctrProperties1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(895, 552);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgitatorEnable);
            this.groupBox1.Controls.Add(this.btnFanEnable);
            this.groupBox1.Controls.Add(this.btnPeltierEnable);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSaveGraph);
            this.groupBox1.Controls.Add(this.btnRefreshProperties);
            this.groupBox1.Controls.Add(this.btnStartTest);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 349);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClear.Location = new System.Drawing.Point(3, 66);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 25);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear Graph";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveGraph
            // 
            this.btnSaveGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaveGraph.Location = new System.Drawing.Point(3, 41);
            this.btnSaveGraph.Name = "btnSaveGraph";
            this.btnSaveGraph.Size = new System.Drawing.Size(88, 25);
            this.btnSaveGraph.TabIndex = 2;
            this.btnSaveGraph.Text = "Save Graph";
            this.btnSaveGraph.UseVisualStyleBackColor = true;
            this.btnSaveGraph.Click += new System.EventHandler(this.btnSaveGraph_Click);
            // 
            // btnRefreshProperties
            // 
            this.btnRefreshProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefreshProperties.Location = new System.Drawing.Point(3, 310);
            this.btnRefreshProperties.Name = "btnRefreshProperties";
            this.btnRefreshProperties.Size = new System.Drawing.Size(88, 36);
            this.btnRefreshProperties.TabIndex = 1;
            this.btnRefreshProperties.Text = "Refresh Properties";
            this.btnRefreshProperties.UseVisualStyleBackColor = true;
            this.btnRefreshProperties.Click += new System.EventHandler(this.btnRefreshProperties_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStartTest.Location = new System.Drawing.Point(3, 16);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(88, 25);
            this.btnStartTest.TabIndex = 0;
            this.btnStartTest.Text = "Start Test";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // btnSendPID
            // 
            this.btnSendPID.Location = new System.Drawing.Point(509, 478);
            this.btnSendPID.Name = "btnSendPID";
            this.btnSendPID.Size = new System.Drawing.Size(75, 23);
            this.btnSendPID.TabIndex = 29;
            this.btnSendPID.Text = "Send PID";
            this.btnSendPID.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(708, 464);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "D";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(661, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "I";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(606, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "P";
            // 
            // PIDTempP
            // 
            this.PIDTempP.Location = new System.Drawing.Point(590, 480);
            this.PIDTempP.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.PIDTempP.Name = "PIDTempP";
            this.PIDTempP.Size = new System.Drawing.Size(47, 20);
            this.PIDTempP.TabIndex = 25;
            this.PIDTempP.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // PIDTempI
            // 
            this.PIDTempI.Location = new System.Drawing.Point(643, 480);
            this.PIDTempI.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.PIDTempI.Name = "PIDTempI";
            this.PIDTempI.Size = new System.Drawing.Size(47, 20);
            this.PIDTempI.TabIndex = 24;
            // 
            // PIDTempD
            // 
            this.PIDTempD.Location = new System.Drawing.Point(696, 480);
            this.PIDTempD.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.PIDTempD.Name = "PIDTempD";
            this.PIDTempD.Size = new System.Drawing.Size(48, 20);
            this.PIDTempD.TabIndex = 23;
            // 
            // temperatureTarget
            // 
            this.temperatureTarget.Location = new System.Drawing.Point(136, 480);
            this.temperatureTarget.Maximum = new decimal(new int[] {
            370,
            0,
            0,
            0});
            this.temperatureTarget.Name = "temperatureTarget";
            this.temperatureTarget.Size = new System.Drawing.Size(43, 20);
            this.temperatureTarget.TabIndex = 22;
            this.temperatureTarget.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // btnSetTarget
            // 
            this.btnSetTarget.Location = new System.Drawing.Point(55, 478);
            this.btnSetTarget.Name = "btnSetTarget";
            this.btnSetTarget.Size = new System.Drawing.Size(75, 23);
            this.btnSetTarget.TabIndex = 21;
            this.btnSetTarget.Text = "Set Target";
            this.btnSetTarget.UseVisualStyleBackColor = true;
            // 
            // tabCAN
            // 
            this.tabCAN.Controls.Add(this.ctrCanConnector1);
            this.tabCAN.Location = new System.Drawing.Point(4, 22);
            this.tabCAN.Name = "tabCAN";
            this.tabCAN.Padding = new System.Windows.Forms.Padding(3);
            this.tabCAN.Size = new System.Drawing.Size(895, 552);
            this.tabCAN.TabIndex = 3;
            this.tabCAN.Text = "CAN";
            this.tabCAN.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCAN);
            this.tabControl.Controls.Add(this.tabControler);
            this.tabControl.Controls.Add(this.tabTubidity);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(903, 578);
            this.tabControl.TabIndex = 7;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // btnPeltierEnable
            // 
            this.btnPeltierEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPeltierEnable.Location = new System.Drawing.Point(3, 91);
            this.btnPeltierEnable.Name = "btnPeltierEnable";
            this.btnPeltierEnable.Size = new System.Drawing.Size(88, 25);
            this.btnPeltierEnable.TabIndex = 4;
            this.btnPeltierEnable.Text = "Peltier Enable";
            this.btnPeltierEnable.UseVisualStyleBackColor = true;
            this.btnPeltierEnable.Click += new System.EventHandler(this.btnPeltierEnable_Click);
            // 
            // btnFanEnable
            // 
            this.btnFanEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFanEnable.Location = new System.Drawing.Point(3, 116);
            this.btnFanEnable.Name = "btnFanEnable";
            this.btnFanEnable.Size = new System.Drawing.Size(88, 25);
            this.btnFanEnable.TabIndex = 5;
            this.btnFanEnable.Text = "Fan Enable";
            this.btnFanEnable.UseVisualStyleBackColor = true;
            this.btnFanEnable.Click += new System.EventHandler(this.btnFanEnable_Click);
            // 
            // btnAgitatorEnable
            // 
            this.btnAgitatorEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgitatorEnable.Location = new System.Drawing.Point(3, 141);
            this.btnAgitatorEnable.Name = "btnAgitatorEnable";
            this.btnAgitatorEnable.Size = new System.Drawing.Size(88, 25);
            this.btnAgitatorEnable.TabIndex = 6;
            this.btnAgitatorEnable.Text = "Agitator Enable";
            this.btnAgitatorEnable.UseVisualStyleBackColor = true;
            this.btnAgitatorEnable.Click += new System.EventHandler(this.btnAgitatorEnable_Click);
            // 
            // tabTubidity
            // 
            this.tabTubidity.Controls.Add(this.ctrChartTurbidity1);
            this.tabTubidity.Location = new System.Drawing.Point(4, 22);
            this.tabTubidity.Name = "tabTubidity";
            this.tabTubidity.Size = new System.Drawing.Size(895, 552);
            this.tabTubidity.TabIndex = 4;
            this.tabTubidity.Text = "Turbidity";
            this.tabTubidity.UseVisualStyleBackColor = true;
            // 
            // ctrCanConnector1
            // 
            this.ctrCanConnector1.Location = new System.Drawing.Point(0, 0);
            this.ctrCanConnector1.Name = "ctrCanConnector1";
            this.ctrCanConnector1.Size = new System.Drawing.Size(302, 199);
            this.ctrCanConnector1.TabIndex = 0;
            // 
            // ctrChart1
            // 
            this.ctrChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrChart1.Location = new System.Drawing.Point(102, 2);
            this.ctrChart1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrChart1.Name = "ctrChart1";
            this.ctrChart1.Size = new System.Drawing.Size(791, 351);
            this.ctrChart1.TabIndex = 3;
            this.ctrChart1.Target = 25F;
            // 
            // ctrProperties1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ctrProperties1, 2);
            this.ctrProperties1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrProperties1.Location = new System.Drawing.Point(3, 358);
            this.ctrProperties1.Name = "ctrProperties1";
            this.ctrProperties1.Size = new System.Drawing.Size(889, 191);
            this.ctrProperties1.TabIndex = 4;
            // 
            // ctrChartTurbidity1
            // 
            this.ctrChartTurbidity1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrChartTurbidity1.Location = new System.Drawing.Point(0, 0);
            this.ctrChartTurbidity1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrChartTurbidity1.Name = "ctrChartTurbidity1";
            this.ctrChartTurbidity1.Size = new System.Drawing.Size(895, 552);
            this.ctrChartTurbidity1.TabIndex = 0;
            // 
            // frmTAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 578);
            this.Controls.Add(this.tabControl);
            this.Name = "frmTAC";
            this.Text = "TAC Controler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGripper_FormClosing);
            this.tabControler.ResumeLayout(false);
            this.tabControler.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PIDTempP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIDTempI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIDTempD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureTarget)).EndInit();
            this.tabCAN.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabTubidity.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmr10sec;
        private System.Windows.Forms.TabPage tabControler;
        private System.Windows.Forms.TabPage tabCAN;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.NumericUpDown temperatureTarget;
        private System.Windows.Forms.Button btnSetTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PIDTempP;
        private System.Windows.Forms.NumericUpDown PIDTempI;
        private System.Windows.Forms.NumericUpDown PIDTempD;
        private System.Windows.Forms.Button btnSendPID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Button btnRefreshProperties;
        private System.Windows.Forms.Button btnSaveGraph;
        private System.Windows.Forms.Button btnClear;
        private TAC.UI.ctrChartCommand ctrChart1;
        private TAC.UI.ctrProperties ctrProperties1;
        private PCAN.ctrCanConnector ctrCanConnector1;
        private System.Windows.Forms.Button btnAgitatorEnable;
        private System.Windows.Forms.Button btnFanEnable;
        private System.Windows.Forms.Button btnPeltierEnable;
        private System.Windows.Forms.TabPage tabTubidity;
        private TAC.UI.ctrChartTurbidity ctrChartTurbidity1;
    }
}


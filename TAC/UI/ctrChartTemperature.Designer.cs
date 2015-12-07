namespace TACControler.TAC.UI
{
    partial class ctrChartCommand
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tmrGetTemperatureAndLoad = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartCommand = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCurrentInfo = new System.Windows.Forms.Label();
            this.chartIntegral = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCommand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIntegral)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea1.AxisY.Title = "Temperature";
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel1.SetColumnSpan(this.chart, 2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(2, 2);
            this.chart.Margin = new System.Windows.Forms.Padding(2);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Temperature";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Consigne";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(770, 303);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Temperature";
            this.chart.Titles.Add(title1);
            // 
            // tmrGetTemperatureAndLoad
            // 
            this.tmrGetTemperatureAndLoad.Interval = 500;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.93798F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.06202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.chart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartCommand, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartIntegral, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCurrentInfo, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(774, 606);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chartCommand
            // 
            chartArea2.AxisY.Title = "Command";
            chartArea2.Name = "ChartArea1";
            this.chartCommand.ChartAreas.Add(chartArea2);
            this.tableLayoutPanel1.SetColumnSpan(this.chartCommand, 2);
            this.chartCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCommand.Location = new System.Drawing.Point(3, 310);
            this.chartCommand.Name = "chartCommand";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chartCommand.Series.Add(series1);
            this.chartCommand.Size = new System.Drawing.Size(768, 133);
            this.chartCommand.TabIndex = 7;
            this.chartCommand.Text = "chart1";
            // 
            // lblCurrentInfo
            // 
            this.lblCurrentInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.lblCurrentInfo, 2);
            this.lblCurrentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentInfo.Location = new System.Drawing.Point(3, 585);
            this.lblCurrentInfo.Name = "lblCurrentInfo";
            this.lblCurrentInfo.Size = new System.Drawing.Size(768, 21);
            this.lblCurrentInfo.TabIndex = 4;
            this.lblCurrentInfo.Text = "label2";
            this.lblCurrentInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chartIntegral
            // 
            chartArea3.AxisY.Title = "Integral";
            chartArea3.Name = "ChartArea1";
            this.chartIntegral.ChartAreas.Add(chartArea3);
            this.tableLayoutPanel1.SetColumnSpan(this.chartIntegral, 2);
            this.chartIntegral.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartIntegral.Legends.Add(legend1);
            this.chartIntegral.Location = new System.Drawing.Point(3, 449);
            this.chartIntegral.Name = "chartIntegral";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartIntegral.Series.Add(series2);
            this.chartIntegral.Size = new System.Drawing.Size(768, 133);
            this.chartIntegral.TabIndex = 6;
            this.chartIntegral.Text = "chartIntegral";
            // 
            // ctrChartCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctrChartCommand";
            this.Size = new System.Drawing.Size(774, 606);
            this.Load += new System.EventHandler(this.ctrChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCommand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIntegral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Timer tmrGetTemperatureAndLoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCurrentInfo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIntegral;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCommand;
    }
}

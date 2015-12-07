using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

using System.IO;

using PCAN;
using TAC.Driver;
using TAC.Events;

namespace TACControler.TAC.UI
{
    public partial class ctrChartTurbidity : UserControl
    {
        #region MEMBER
        private double x = 0;
        private Stopwatch stopwatch = new Stopwatch();

        private float minTemperature = 500;
        private float maxTemperature = -100;
        #endregion

        #region INITIALIZATION
        public ctrChartTurbidity()
        {
            InitializeComponent();
            PCANCom.Instance.OnMessageReceived += CANMessageReceived;
        }
        
        private void ctrChart_Load(object sender, EventArgs e)
        {
            chart.Series[0].ChartType = SeriesChartType.Line;

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0}";

            chart.Series[0].Color = Color.Blue;
            chart.Series[0].BorderWidth = 2;

            chart.ChartAreas[0].AxisY.MinorGrid.Interval = 1;
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart.ChartAreas[0].AxisX.Interval = (double)1200;

            chart.ChartAreas[0].AxisX.MinorGrid.Interval = 20;
            chart.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 60;

            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Number;

            clearChart();
        }
        #endregion

        #region CHART CONTROL (ADD DATA, CLEAR)
        public void addTurbidity(float value)
        {
            chart.Series[0].Points.AddXY(x, value);


            if(value < minTemperature)
            {
                minTemperature = value;
            }
            if(value > maxTemperature)
            {
                maxTemperature = value;
            }

            lblCurrentInfo.Text = "Current Turbidity: " + value.ToString() + "       -       " +
                                  "Min. Turbidity: " + minTemperature.ToString() + "       -       " +
                                  "Max. Turbidity: " + maxTemperature.ToString() + "";

        }

        public void increaseX()
        {
            stopwatch.Stop();
            x += (double)stopwatch.ElapsedMilliseconds / (double)1000;
            stopwatch.Restart();
            if (x > 20 * 60)
            {
                chart.Series[0].Points.RemoveAt(0);
                chart.ResetAutoValues();
            }
        }

        public void clearChart()
        {
            chart.Series[0].Points.Clear();
            x = 0;
            minTemperature = 500;
            maxTemperature = -100;
        }

        #endregion


        #region CAN MESSAGE RECEIVED
        private void CANMessageReceived(object sender, PCANComEventArgs e)
        {
            if (e.CanMsg.DATA[2] == CANDeviceConstant.HARDWARE_FILTER_TAC)
            {
                    packetDecoder(e.CanMsg.DATA);
            }
        }
        #endregion

        #region CAN MESSAGE TREATMENT
        private void packetDecoder(byte[] packet)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<byte[]>(packetDecoder), packet);
            }
            else
            {
                switch (packet[0])
                {
                    case TACConstant.INST_GET_TURBIDITY:
                        addTurbidity(BitConverter.ToSingle(packet, 4));
                        increaseX();                   
                        break;
                }

            }
        }
        #endregion

        #region HELPER

        public void saveChart()
        {
            StreamWriter w = new StreamWriter("t.csv");
            for (int i = 0; i < chart.Series[0].Points.Count; i++)
            {
                w.Write(chart.Series[0].Points[i].XValue.ToString().Replace(',','.'));
                if (i != chart.Series[0].Points.Count-1)
                    w.Write(",");
            }
            w.Close();
            w.Dispose();
            w = new StreamWriter("turbidity.csv");
            for (int i = 0; i < chart.Series[0].Points.Count; i++)
            {
                w.Write(chart.Series[0].Points[i].YValues[0].ToString().Replace(',', '.'));
                if (i != chart.Series[0].Points.Count - 1)
                    w.Write(",");
            }
            w.Close();
            w.Dispose();
        }

        #endregion

    }
}

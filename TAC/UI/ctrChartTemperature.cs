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
    public partial class ctrChartCommand : UserControl
    {
        #region MEMBER
        private double x = 0;

        private float minTemperature = 500;
        private float maxTemperature = -100;

        private float target = 25;
        [Description("Consigne"), Category("Data")]
        public float Target
        {
            get { return target; }
            set { target = value; }
        }


        private const byte MAX_DELAY_DATA = 50;
        private long[] delay = new long[MAX_DELAY_DATA];
        private byte curDelayIndex = 0;
        private byte nbOfDelayData = 0;
        private Stopwatch stopwatch = new Stopwatch();

        #endregion

        #region INITIALIZATION
        public ctrChartCommand()
        {
            InitializeComponent();
            lblCurrentInfo.Text = "";
            PCANCom.Instance.OnMessageReceived += CANMessageReceived;
            TACEvents.Instance.OnMessageBusEvent += OnMessageBusEventReceived;
        }
        
        private void ctrChart_Load(object sender, EventArgs e)
        {
            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[1].ChartType = SeriesChartType.Line;

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0}";
            chartCommand.ChartAreas[0].AxisX.LabelStyle.Format = "{0}";
            chartIntegral.ChartAreas[0].AxisX.LabelStyle.Format = "{0}";

            chart.Series[0].Color = Color.Red;
            chart.Series[1].Color = Color.Green;

            chart.Series[0].BorderWidth = 2;
            chart.Series[1].BorderWidth = 2;
            chartCommand.Series[0].BorderWidth = 2;
            chartIntegral.Series[0].BorderWidth = 2;

            chart.ChartAreas[0].AxisY.MinorGrid.Interval = 1;
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart.ChartAreas[0].AxisX.Interval = (double)1200;
            chartCommand.ChartAreas[0].AxisX.Interval = (double)1200;
            chartIntegral.ChartAreas[0].AxisX.Interval = (double)1200;

            chart.ChartAreas[0].AxisX.MinorGrid.Interval = 20;
            chart.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 60;

            chartCommand.ChartAreas[0].AxisX.MinorGrid.Interval = 20;
            chartCommand.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chartCommand.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chartCommand.ChartAreas[0].AxisX.MajorGrid.Interval = 60;
            
            chartIntegral.ChartAreas[0].AxisX.MinorGrid.Interval = 20;
            chartIntegral.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chartIntegral.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chartIntegral.ChartAreas[0].AxisX.MajorGrid.Interval = 60;

            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Number;

            clearChart();
        }
        #endregion

        #region CHART CONTROL (ADD DATA, CLEAR)
        public void addTemperature(float value)
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

            lblCurrentInfo.Text = "Current Temperature: " + value.ToString() + "°C       -       " +
                                  "Min. Temperature: " + minTemperature.ToString() + "°C       -       " +
                                  "Max. Temperature: " + maxTemperature.ToString() + "°C";

        }

        public void addTarget(float value)
        {
            chart.Series[1].Points.AddXY(x, value);
        }

        public void addCommand(sbyte value)
        {
            chartCommand.Series[0].Points.AddXY(x, value);
        }

        public void addIntegral(float value)
        {
            chartIntegral.Series[0].Points.AddXY(x, value);
        }

        public void increaseX()
        {
            stopwatch.Stop();
            x += (double)stopwatch.ElapsedMilliseconds / (double)1000;
            stopwatch.Restart();
            if (x > 20 * 60)
            {
                chart.Series[0].Points.RemoveAt(0);
                chart.Series[1].Points.RemoveAt(0);
                chartCommand.Series[0].Points.RemoveAt(0);
                chartIntegral.Series[0].Points.RemoveAt(0);

                chart.ResetAutoValues();
                chartCommand.ResetAutoValues();
                chartIntegral.ResetAutoValues();
            }
        }

        public void clearChart()
        {
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            chartCommand.Series[0].Points.Clear();
            chartIntegral.Series[0].Points.Clear();
            x = 0;
            minTemperature = 500;
            maxTemperature = -100;
        }

        #endregion

        #region MESSAGE BUS RECEIVED (OBSERVER PATTERN)

        private void OnMessageBusEventReceived(object sender,  TACEvents.MessageBusArgs e)
        {
            switch (e.type)
            {
                case TACEvents.MessageBusType.TEMPERATURE_TARGET:
                    target = e.value;
                    break;
            }
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
                    case TACConstant.INST_GET_CURRENT_TEMPERATURE:

                        Int16 temp =  BitConverter.ToInt16(packet,4);
                        float curTemp = (float)((float)temp / (float)10);
                        addTemperature(curTemp);
                        addTarget(target);
                        addCommand((sbyte)packet[6]);
                        increaseX();                   
                        break;

                    case TACConstant.INST_GET_TARGET_TEMPERATURE:
                        target = ((int)(packet[4] << 8) + (int)packet[3]) / (float)10;
                        break;

                    case TACConstant.INST_GET_PID_INTEGRAL:
                        byte[] ar = {packet[4], packet[5], packet[6], packet[7]};
                        addIntegral(BitConverter.ToSingle(ar, 0));
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
            w = new StreamWriter("temperature.csv");
            for (int i = 0; i < chart.Series[0].Points.Count; i++)
            {
                w.Write(chart.Series[0].Points[i].YValues[0].ToString().Replace(',', '.'));
                if (i != chart.Series[0].Points.Count - 1)
                    w.Write(",");
            }
            w.Close();
            w.Dispose();
            w = new StreamWriter("target.csv");
            for (int i = 0; i < chart.Series[0].Points.Count; i++)
            {
                w.Write(chart.Series[1].Points[i].YValues[0].ToString().Replace(',', '.'));
                if (i != chart.Series[1].Points.Count - 1)
                    w.Write(",");
            }
            w.Close();
            w.Dispose();
            w = new StreamWriter("command.csv");
            for (int i = 0; i < chartCommand.Series[0].Points.Count; i++)
            {
                w.Write(chartCommand.Series[0].Points[i].YValues[0].ToString().Replace(',', '.'));
                if (i != chartCommand.Series[0].Points.Count - 1)
                    w.Write(",");
            }
            w.Close();
            w.Dispose();
        }

        private void displayCommunicationDelay()
        {
            long mean = 0;
            stopwatch.Stop();
            delay[curDelayIndex++ % MAX_DELAY_DATA] = stopwatch.ElapsedMilliseconds;
            nbOfDelayData++;
            if (nbOfDelayData > MAX_DELAY_DATA) nbOfDelayData = MAX_DELAY_DATA;
            for (byte i = 0; i < MAX_DELAY_DATA; i++)
            {
                mean += delay[i];
            }
            mean /= nbOfDelayData;
            //lblDelay.Text = "Mean time: " + mean.ToString() + "ms";
            stopwatch.Restart();
        }

        #endregion

    }
}

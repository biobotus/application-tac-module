using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

using PCAN;
using Peak.Can.Basic;
using TAC.Driver;

namespace TACControler
{
    public partial class frmTAC : Form
    {

        #region MEMBER
        private const int TARGET_WAITING_10SECONDS = 30;
        private int nbOfSecond = 0;
        #endregion

        #region INITIALIZATION
        public frmTAC()
        {
            InitializeComponent();
            PCANCom.Instance.OnMessageReceived += CANMessageReceived;
        }


        private void frmGripper_FormClosing(object sender, FormClosingEventArgs e)
        {
            PCANCom.Instance.disconnect();
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
                if(packet[3] == 1)
                {
                    switch (packet[0])
                    {
                        case TACConstant.INST_GET_AGITATOR_STATE:
                            btnAgitatorEnable.Text = "Agitator Disable";
                            break;
                        case TACConstant.INST_GET_PELTIER_STATE:
                            btnPeltierEnable.Text = "Peltier Disable";
                            break;
                        case TACConstant.INST_GET_FAN_STATE:
                            btnFanEnable.Text = "Fan Disable";
                            break;
                    }
                }
                else if (packet[3] == 0)
                {
                    switch (packet[0])
                    {
                        case TACConstant.INST_GET_AGITATOR_STATE:
                            btnAgitatorEnable.Text = "Agitator Enable";
                            break;
                        case TACConstant.INST_GET_PELTIER_STATE:
                            btnPeltierEnable.Text = "Peltier Enable";
                            break;
                        case TACConstant.INST_GET_FAN_STATE:
                            btnFanEnable.Text = "Fan Enable";
                            break;
                    }
                }
            }
        }
        #endregion

        #region HANDLING EVENTS

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl.SelectedIndex == 1)
                ctrProperties1.getAllProperties();
        }

        private void tmr10sec_Tick(object sender, EventArgs e)
        {
            ushort temperature;

            if (nbOfSecond == 0)
            {
                if (ctrChart1.Target == 37)
                    temperature = 22;
                else
                    temperature = 37;
                TAC2CAN.setTemperatureTarget((ushort)(temperature * 10));
                ctrChart1.Target = temperature;
            }
            nbOfSecond = (nbOfSecond + 1) % TARGET_WAITING_10SECONDS;
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (btnStartTest.Text == "Start Test")
            {
                btnStartTest.Text = "Stop Test";
                nbOfSecond = 0;
                tmr10sec_Tick(null, null);
                tmr10sec.Enabled = true;
            }
            else
            {
                btnStartTest.Text = "Start Test";
                tmr10sec.Enabled = false;
            }
        }

        private void btnRefreshProperties_Click(object sender, EventArgs e)
        {
            ctrProperties1.getAllProperties();
        }

        private void btnSaveGraph_Click(object sender, EventArgs e)
        {
            ctrChart1.saveChart();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ctrChart1.clearChart();
        }

        private void btnPeltierEnable_Click(object sender, EventArgs e)
        {
            if(btnPeltierEnable.Text.Equals("Peltier Enable"))
            {
                TAC2CAN.setPeltierEnable(0);
            }
            else
            {
                TAC2CAN.setPeltierEnable(1);
            }
            TAC2CAN.getPeltierState();
        }

        private void btnFanEnable_Click(object sender, EventArgs e)
        {
            if (btnFanEnable.Text.Equals("Fan Enable"))
            {
                TAC2CAN.setFanEnable(0);
            }
            else
            {
                TAC2CAN.setFanEnable(1);
            }
            TAC2CAN.getFanState();
        }

        private void btnAgitatorEnable_Click(object sender, EventArgs e)
        {
            if (btnAgitatorEnable.Text.Equals("Agitator Enable"))
            {
                TAC2CAN.setAgitatorEnable(0);
            }
            else
            {
                TAC2CAN.setAgitatorEnable(1);
            }
            TAC2CAN.getAgitatorState();
        }

        #endregion

    }
}

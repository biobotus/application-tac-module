using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using PCAN;
using Peak.Can.Basic;
using TAC.Driver;
using TAC.Events;

namespace TACControler.TAC.UI
{
    public partial class ctrProperties : UserControl
    {

        #region INITIALIZAION
        public ctrProperties()
        {
            InitializeComponent();
            PCANCom.Instance.OnMessageReceived += CANMessageReceived;
            
            addProperties();
            dataGrid.AllowUserToAddRows = false;
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
                float k;
                switch (packet[0])
                {
                    case TACConstant.INST_GET_TARGET_TEMPERATURE:
                        dataGrid.Rows[0].Cells[2].Value = ((float)(packet[4] << 8) + (float)packet[3]) / (float)10;
                        break;
                    case TACConstant.INST_GET_TEMPERATURE_LIMIT_HIGH:
                        dataGrid.Rows[1].Cells[2].Value = ((float)(packet[4] << 8) + (float)packet[3]) / (float)10;
                        break;
                    case TACConstant.INST_GET_TEMPERATURE_LIMIT_LOW:
                        dataGrid.Rows[2].Cells[2].Value = ((float)(packet[4] << 8) + (float)packet[3]) / (float)10;
                        break;
                    case TACConstant.INST_GET_TEMPERATURE_PID_PARAM_P:
                        k = BitConverter.ToSingle(packet, 4);
                        dataGrid.Rows[3].Cells[2].Value = k;
                        break;
                    case TACConstant.INST_GET_TEMPERATURE_PID_PARAM_I:
                        k = BitConverter.ToSingle(packet, 4);
                        dataGrid.Rows[4].Cells[2].Value = k;
                        break;
                    case TACConstant.INST_GET_TEMPERATURE_PID_PARAM_D:
                        k = BitConverter.ToSingle(packet, 4);
                        dataGrid.Rows[5].Cells[2].Value = k;
                        break;
                    case TACConstant.INST_GET_AGITATOR_STATE:
                        dataGrid.Rows[6].Cells[2].Value = packet[3];
                        dataGrid.Rows[7].Cells[2].Value = packet[4];
                        break;
                    case TACConstant.INST_GET_PELTIER_STATE:
                        dataGrid.Rows[8].Cells[2].Value = packet[3];
                        dataGrid.Rows[9].Cells[2].Value = packet[4];
                        break;
                    case TACConstant.INST_GET_FAN_STATE:
                        dataGrid.Rows[10].Cells[2].Value = packet[3];
                        dataGrid.Rows[11].Cells[2].Value = packet[4];
                        break;
                    case TACConstant.INST_GET_TURBIDITY:
                        dataGrid.Rows[12].Cells[2].Value = BitConverter.ToSingle(packet,4);
                        break;
                }
            }
        }
        #endregion

        #region Adding Properties To The DataGrid

        private void addProperties()
        {
            addProperty("ROM", "Target Temperature");
            addProperty("ROM", "Temperature Limit High");
            addProperty("ROM", "Temperature Limit Low");
            addProperty("ROM", "PID Temperature param P");
            addProperty("ROM", "PID Temperature param I");
            addProperty("ROM", "PID Temperature param D");

            addProperty("RAM", "Agitator Enable");
            addProperty("RAM", "Agitator Speed Pourcentage");
            addProperty("RAM", "Peltier Enable");
            addProperty("RAM", "Peltier Speed");
            addProperty("RAM", "Fan Enable");
            addProperty("RAM", "Fan Speed");
            addProperty("RAM", "Turbidity");
        }

        private int addProperty(String memory, String propertyName)
        {
            DataGridViewRow row = (DataGridViewRow)dataGrid.Rows[0].Clone();
            row.Cells[0].Value = memory;
            row.Cells[1].Value = propertyName;

            row.Cells[2].Value = "";    // value
            return dataGrid.Rows.Add(row);
        }

        private int addProperty(String memory, String propertyName, String initialValue)
        {
            DataGridViewRow row = (DataGridViewRow)dataGrid.Rows[0].Clone();
            row.Cells[0].Value = memory;
            row.Cells[1].Value = propertyName;

            row.Cells[2].Value = "";    // value
            row.Cells[2].ToolTipText = "Initial Value: " + initialValue;

            return dataGrid.Rows.Add(row);
        }

        #endregion


        #region CAN MESSAGE GENERATION

        public void getAllProperties()
        {
            TAC2CAN.getTemperaturePIDValues();
            TAC2CAN.getTemperatureTargetValue();
            TAC2CAN.getPeltierState();
            TAC2CAN.getFanState();
            TAC2CAN.getAgitatorState();
            TAC2CAN.getTemperatureLimitHigh();
            TAC2CAN.getTemperatureLimitLow();
            TAC2CAN.getTurbidity();
        }

        #endregion

        #region PROPERTY CHANGED
        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            float tmp;

            if (e.RowIndex >= 0 && e.RowIndex < 25)
            {
                if (dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    try
                    {

                        switch (e.RowIndex)
                        {
                            case 0: // Target Temperature
                                tmp = float.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                                TAC2CAN.setTemperatureTarget((ushort)(tmp * (float)10));
                                TACEvents.Instance.postMessageBusEvent(TACEvents.MessageBusType.TEMPERATURE_TARGET, tmp);
                                break;
                            case 1: // Temperature Limit High
                                tmp = float.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                                TAC2CAN.setTemperatureLimitHigh((ushort)(tmp * (float)10));
                                break;
                            case 2: // Temperature Limit Low
                                tmp = float.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                                TAC2CAN.setTemperatureLimitLow((ushort)(tmp * (float)10));
                                break;
                            case 3: // PID Temperature param P
                                tmp = float.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                                TAC2CAN.setTemperaturePIDParamP(tmp);
                                break;
                            case 4: // PID Temperature param I
                                tmp = float.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                                TAC2CAN.setTemperaturePIDParamI(tmp);
                                break;
                            case 5: // PID Temperature param D
                                tmp = float.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                                TAC2CAN.setTemperaturePIDParamD(tmp);
                                break;
                            case 6: // Agitator Enable
                                TAC2CAN.setAgitatorEnable(byte.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                                break;
                            case 7: // Agitator Speed
                                TAC2CAN.setAgitatorSpeed(byte.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                                break;
                            case 8: // Peltier Enable
                                TAC2CAN.setPeltierEnable(byte.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                                break;
                            case 9: // Peltier speed
                                TAC2CAN.setPeltierSpeed(byte.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                                break;
                            case 10: // Fan Enable
                                TAC2CAN.setFanEnable(byte.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                                break;
                            case 11: // Fan Speed
                                TAC2CAN.setFanSpeed(byte.Parse(dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                                break;
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        #endregion
    }
}

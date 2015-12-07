using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCAN;
using Peak.Can.Basic;

namespace TAC.Driver
{
    class TAC2CAN
    {

        #region GET

        public static void getTemperaturePIDValues()
        {
            sendCANMessage(TACConstant.INST_GET_TEMPERATURE_PID_PARAM_P, TACConstant.MODULE0, 0, 0, 0, 0, 0, 0);
            sendCANMessage(TACConstant.INST_GET_TEMPERATURE_PID_PARAM_I, TACConstant.MODULE0, 0, 0, 0, 0, 0, 0);
            sendCANMessage(TACConstant.INST_GET_TEMPERATURE_PID_PARAM_D, TACConstant.MODULE0, 0, 0, 0, 0, 0, 0);
        }

        public static void getTemperatureTargetValue()
        {
            sendCANMessage(TACConstant.INST_GET_TARGET_TEMPERATURE,
                            TACConstant.MODULE0,
                            0, 0, 0, 0, 0, 0);
        }

        public static void getPeltierState()
        {
            sendCANMessage(TACConstant.INST_GET_PELTIER_STATE,
                        TACConstant.MODULE0,
                            0, 0, 0, 0, 0, 0);
        }

        public static void getFanState()
        {
            sendCANMessage(TACConstant.INST_GET_FAN_STATE,
                        TACConstant.MODULE0,
                            0, 0, 0, 0, 0, 0);
        }

        public static void getAgitatorState()
        {
            sendCANMessage(TACConstant.INST_GET_AGITATOR_STATE,
                        TACConstant.MODULE0,
                            0, 0, 0, 0, 0, 0);
        }

        public static void getTemperatureLimitHigh()
        {
            sendCANMessage(TACConstant.INST_GET_TEMPERATURE_LIMIT_HIGH,
                            TACConstant.MODULE0,
                            0, 0, 0, 0, 0, 0);
        }

        public static void getTemperatureLimitLow()
        {
            sendCANMessage(TACConstant.INST_GET_TEMPERATURE_LIMIT_LOW,
                            TACConstant.MODULE0,
                            0, 0, 0, 0, 0, 0);
        }

        public static void getTurbidity()
        {
            sendCANMessage(TACConstant.INST_GET_TURBIDITY,
                            TACConstant.MODULE0,
                            0, 0, 0, 0, 0, 0);
        }

        public static void getModelFirmware()
        {
            sendCANMessage(TACConstant.INST_GET_MODEL_FIRMWARE, 0, 0, 0, 0, 0, 0, 0);
        }
        #endregion

        #region SET

        public static void setTemperatureLimitHigh(UInt16 limit)
        {
            sendCANMessage(TACConstant.INST_SET_TEMPERATURE_LIMIT_HIGH,
                            TACConstant.MODULE0,
                            (byte)(limit), (byte)(limit >> 8), 0, 0, 0, 0);
        }

        public static void setTemperatureLimitLow(UInt16 limit)
        {
            sendCANMessage(TACConstant.INST_SET_TEMPERATURE_LIMIT_LOW,
                            TACConstant.MODULE0,
                            (byte)(limit), (byte)(limit >> 8), 0, 0, 0, 0);
        }


        public static void setTemperatureTarget(UInt16 temperature)
        {
            sendCANMessage(TACConstant.INST_SET_TARGET_TEMPERATURE,
                            TACConstant.MODULE0,
                            (byte)(temperature), (byte)(temperature >> 8), 0, 0, 0, 0);
        }

        public static void setTemperaturePIDParamP(float kp)
        {
            byte[] k;
            k = BitConverter.GetBytes(kp);

            sendCANMessage(TACConstant.INST_SET_TEMPERATURE_PID_PARAM_P,
                            TACConstant.MODULE0,
                            0, 0, k[0], k[1], k[2], k[3]);
        }

        public static void setTemperaturePIDParamI(float ki)
        {
            byte[] k;
            k = BitConverter.GetBytes(ki);

            sendCANMessage( TACConstant.INST_SET_TEMPERATURE_PID_PARAM_I,
                            TACConstant.MODULE0, 
                            0, 0, k[0], k[1], k[2], k[3]);
        }

        public static void setTemperaturePIDParamD(float kd)
        {
            byte[] k;
            k = BitConverter.GetBytes(kd);

            sendCANMessage( TACConstant.INST_SET_TEMPERATURE_PID_PARAM_D,
                            TACConstant.MODULE0, 
                            0, 0, k[0], k[1], k[2], k[3]);
        }

        public static void setPeltierEnable(int enable)
        {
            sendCANMessage(TACConstant.INST_SET_PELTIER_ENABLE,
                           TACConstant.MODULE0, 
                           (byte)enable, 0, 0, 0, 0, 0);
        }
        public static void setPeltierSpeed(int speed)
        {
            sendCANMessage(TACConstant.INST_SET_PELTIER_SPEED,
                           TACConstant.MODULE0,
                           (byte)speed, 0, 0, 0, 0, 0);
        }

        public static void setFanEnable(int enable)
        {
            sendCANMessage(TACConstant.INST_SET_FAN_ENABLE,
                           TACConstant.MODULE0,
                           (byte)enable, 0, 0, 0, 0, 0);
        }
        public static void setFanSpeed(int speed)
        {
            sendCANMessage(TACConstant.INST_SET_FAN_SPEED,
                           TACConstant.MODULE0,
                           (byte)speed, 0, 0, 0, 0, 0);
        }

        public static void setAgitatorEnable(int enable)
        {
            sendCANMessage(TACConstant.INST_SET_AGITATOR_ENABLE,
                           TACConstant.MODULE0,
                           (byte)enable, 0, 0, 0, 0, 0);
        }

        public static void setAgitatorSpeed(byte speed)
        {
            sendCANMessage(TACConstant.INST_SET_AGITATOR_SPEED,
                           TACConstant.MODULE0,
                           (byte)speed, 0, 0, 0, 0, 0);
        }
        #endregion


        #region HELPER

        private static void sendCANMessage(byte instruction, byte module, byte byte2, byte byte3, byte byte4, byte byte5, byte byte6, byte byte7)
        {
            TPCANMsg CANMsg = new TPCANMsg();
            CANMsg.DATA = new byte[8];
            CANMsg.DATA[0] = instruction;
            CANMsg.DATA[1] = module;
            CANMsg.DATA[2] = byte2;
            CANMsg.DATA[3] = byte3;
            CANMsg.DATA[4] = byte4;
            CANMsg.DATA[5] = byte5;
            CANMsg.DATA[6] = byte6;
            CANMsg.DATA[7] = byte7;
            CANMsg.ID = CANDeviceConstant.HARDWARE_FILTER_TAC;
            CANQueue.Instance.add(CANMsg);
            CANQueue.Instance.executeFirst();
        }
        #endregion
    }
}

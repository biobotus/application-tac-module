using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC.Driver
{
    class TACConstant
    {

        public const int MODULE0 = 0;
        public const int MODULE1 = 1;

        public const int INST_GET_CURRENT_TEMPERATURE = 0;

        public const int INST_SET_TARGET_TEMPERATURE = 1;
        public const int INST_GET_TARGET_TEMPERATURE = 2;

        public const int INST_SET_TEMPERATURE_LIMIT_HIGH = 3;
        public const int INST_GET_TEMPERATURE_LIMIT_HIGH = 4;

        public const int INST_SET_TEMPERATURE_LIMIT_LOW = 5;
        public const int INST_GET_TEMPERATURE_LIMIT_LOW = 6;

        public const int INST_SET_AGITATOR_ENABLE = 7;
        public const int INST_SET_AGITATOR_SPEED = 8;
        public const int INST_GET_AGITATOR_STATE = 9;

        public const int INST_SET_FAN_ENABLE = 10;
        public const int INST_SET_FAN_SPEED = 11;
        public const int INST_GET_FAN_STATE = 12;

        public const int INST_SET_PELTIER_ENABLE = 13;
        public const int INST_SET_PELTIER_SPEED = 14;
        public const int INST_GET_PELTIER_STATE = 15;

        public const int INST_GET_TURBIDITY = 16;

        public const int INST_SET_TEMPERATURE_PID_PARAM_P = 17;
        public const int INST_SET_TEMPERATURE_PID_PARAM_I = 18;
        public const int INST_SET_TEMPERATURE_PID_PARAM_D = 19;
        public const int INST_GET_TEMPERATURE_PID_PARAM_P = 20;
        public const int INST_GET_TEMPERATURE_PID_PARAM_I = 21;
        public const int INST_GET_TEMPERATURE_PID_PARAM_D = 22;

        public const int INST_GET_PID_INTEGRAL = 23;

        public const int INST_GET_MODEL_FIRMWARE = 254;

    }
}

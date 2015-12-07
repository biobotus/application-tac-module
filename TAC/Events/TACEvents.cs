using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAC.Events
{
    class TACEvents
    {
        #region INSTANCE
        private static TACEvents instance;
        public static TACEvents Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TACEvents();
                }
                return instance;
            }
        }
        #endregion


        #region MESSAGE BUS EVENT (TO SHARE INFORMATION BETWEEN COMPONANT)

        public enum MessageBusType
        {
            TEMPERATURE_TARGET,
        }

        public event EventHandler<MessageBusArgs> OnMessageBusEvent;
        public void postMessageBusEvent(MessageBusType type, float value)
        {
            if (OnMessageBusEvent != null)
            {
                OnMessageBusEvent(this, new MessageBusArgs(type, value));
            }
        }
        public class MessageBusArgs : EventArgs
        {
            public MessageBusType type { get; private set; }
            public float value { get; private set; }

            public MessageBusArgs(MessageBusType type, float value)
            {
                this.type = type;
                this.value = value;
            }
        }



        #endregion
    }
}

using Bioscoop.ThirdPartyMessenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop
{
    class MessageAdapter
    {
        private MessengerProvider _messengerProvider;

        public MessageAdapter()
        {
            _messengerProvider = new MessengerProvider();
        }

        public void Send(string msg)
        {
            _messengerProvider.SendMessage(msg);
        }
    }
}

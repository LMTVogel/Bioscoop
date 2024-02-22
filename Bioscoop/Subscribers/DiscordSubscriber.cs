using Bioscoop.subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Subscribers
{
    class DiscordSubscriber : ISubscriber
    {
        private MessageAdapter _messageAdapter = new MessageAdapter();

        public void Update(string msg)
        {
            _messageAdapter.Send($"Discord: {msg}");
        }
    }
}

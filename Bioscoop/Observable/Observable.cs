using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bioscoop.subscribers;

namespace Bioscoop.Observable
{
     class Observable : IObservable
    {
        private List<ISubscriber> subscribers = new List<ISubscriber>();

        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void Notify(string msg)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Update(msg);
            }
        }
    }
}

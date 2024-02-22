using Bioscoop.subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Observable
{
    public interface IObservable
    {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void Notify(string msg);
    }
}

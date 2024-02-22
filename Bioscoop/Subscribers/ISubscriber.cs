using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.subscribers
{
    public interface ISubscriber
    {
        void Update(string msg);
    }
}

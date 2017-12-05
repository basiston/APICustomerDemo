using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Models;

namespace APICustomerDemo
{
    public class RequestQueue
    {
        private static ConcurrentQueue<Guid> _queue;

        public static ConcurrentQueue<Guid> Queue
        {
            get
            {
                if (_queue == null)
                {
                    _queue = new ConcurrentQueue<Guid>();
                }
                return _queue;
            }
        }
    }
}

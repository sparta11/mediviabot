using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util
{
    class InputDeque<T>
    {


        private Object thisLock = new Object();
        private Deque<T> deque = new Deque<T>();


        public int Count
        {
            get
            {
                lock (thisLock)
                {
                    return deque.Count;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                lock (thisLock)
                {
                    return deque[index];
                }
            }
        }

        public bool IsEmpty
        {

            get
            {
                lock (thisLock)
                {
                    return Count == 0;
                }
            }

        }

        public T First()
        {
            lock (thisLock)
            {
                return deque.First();
            }
        }

        public T Last()
        {
            lock (thisLock)
            {
                return deque.Last();
            }
        }

        public void AddToFront(T input)
        {
            lock (thisLock)
            {
                deque.AddToFront(input);
            }
        }

        public void AddToBack(T input)
        {
            lock (thisLock)
            {
                deque.AddToBack(input);
            }
        }

        public void RemoveFromFront()
        {
            lock (thisLock)
            {
                deque.RemoveFromFront();
            }
        }

        public void Insert(int index, T input)
        {
            lock (thisLock)
            {
                deque.Insert(index, input);
            }
        }

        public bool Contains(T input)
        {
            lock (thisLock)
            {
                return deque.Contains(input);
            }
        }
    }
}

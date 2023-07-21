using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeDataCollection
{
    public class LargeDataCollection : IDisposable
    {
        private List<object> data1;

        public LargeDataCollection(IEnumerable<object> d1)
        {
            data1 = new List<object>(d1);
        }

        public void Add(object item)
        {
            data1.Add(item);
        }

        public void Remove(object item)
        {
            data1.Remove(item);
        }

        public void AccessData()
        {
            foreach (var item in data1)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (data1 != null)
                {
                    data1.Clear();
                    data1 = null;
                }
            }

        }
    }

    public class Program
    {
        public static void Main()
        {
            using (var largeDataCollection = new LargeDataCollection(new List<object> { "muku", 21.234, 90 }))
            {
                largeDataCollection.Add(42);

                largeDataCollection.Remove("muku");

                largeDataCollection.AccessData();
            }
            Console.ReadKey();
        }
    }

}

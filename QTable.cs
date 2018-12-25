using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake_ai
{
    public class QTable
    {
        private Dictionary<Tuple<string, int>, int> table;

        public QTable()
        {
            table = new Dictionary<Tuple<string, int>, int>();
        }

        public void Add(Tuple<string, int> key, int value)
        {
            table.Add(key, value);
        }

        public int TryGet(Tuple<string, int>)
        {
            int value = 0;

            if (!table.TryGetValue(key, out value))
            {
                return -1;
            }

            return value;
        }
    }
}

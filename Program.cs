using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake_ai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var season = new List<Episode>();

            for (int i = 0; i < 100; i++)
            {
                season.Add(new Episode());
                season[i].Play();
            }
        }
    }
}

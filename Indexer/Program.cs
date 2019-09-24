using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Names name = new Names();
            name.Add("Anna"); //1
            name.Add("David"); //2
            name.Add("Zenek"); //3
            int i = name["Anna"]; // i = 2
            Console.Read();
        }
    }
}

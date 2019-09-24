using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    public class Names
    {
        List<string> namelist = new List<string>();
        public void Add(string name)
        {
            namelist.Add(name);
        }
        public int this[string name]
        {
            get
            {
                for (int i = 0; i < namelist.Count; i++)
                {
                    if (namelist[i] == name)
                    {
                        return i + 1;
                    }
                }
                return 0;
            }
        }

    }
}

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
                var isOk = namelist.Where(a => a == name).FirstOrDefault();
                if (isOk != null)
                {
                    return namelist.IndexOf(isOk) + 1;
                }else return 0;
            }
           

            
        }


    }
}

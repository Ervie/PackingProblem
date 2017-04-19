using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utilities.Files
{
    public class File<T>
    {
        public T Content { get; set; }
        public string Path { get; set; }
    }
}

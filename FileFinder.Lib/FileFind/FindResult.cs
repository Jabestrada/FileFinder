using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Lib
{
    public class FindResult
    {
        public FindOptions FindOptions { get; set; }
        public bool HadErrors { get; set; }
        public Exception Error { get; set; }
        public IList<FindResultItem> Results { get; set; }
    }
}

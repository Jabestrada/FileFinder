using FileFinder.Lib.FileEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Lib
{
    public class FindOptions
    {
        public string StartFolder { get; set; }
        public string[] SearchKeys { get; set; }
        public IProgress<FindProgress> Progress { get; set; }
        public IFileEvaluator FileEvaluator { get; set; }
    }
}

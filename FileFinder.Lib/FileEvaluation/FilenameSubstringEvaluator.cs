using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Lib.FileEvaluation
{
    public class FilenameSubstringEvaluator : IFileEvaluator
    {
        public bool IsInterestedInFile(FileEvaluationOptions options, FileInfo file)
        {
            foreach (var key in options.SearchKeys) {
                if (file.Name.IndexOf(key, 0, StringComparison.InvariantCultureIgnoreCase) > 0) {
                    return true;
                }
            }
            return false;
        }
    }
}

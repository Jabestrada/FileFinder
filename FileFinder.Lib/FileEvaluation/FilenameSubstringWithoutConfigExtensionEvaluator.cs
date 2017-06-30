using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Lib.FileEvaluation
{
    public class FilenameSubstringWithoutConfigExtensionEvaluator : IFileEvaluator
    {
        public bool IsInterestedInFile(FileEvaluationOptions options, FileInfo file)
        {
            foreach (var key in options.SearchKeys) {
                if (file.Name.IndexOf(key, 0, StringComparison.InvariantCultureIgnoreCase) > 0) {
                    if (file.Extension.ToLowerInvariant() != ".config")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

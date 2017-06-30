using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Lib.FileEvaluation
{
    public interface IFileEvaluator
    {
        bool IsInterestedInFile(FileEvaluationOptions options, FileInfo file);
    }
}

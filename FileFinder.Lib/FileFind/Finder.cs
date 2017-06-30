using FileFinder.Lib.FileEvaluation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Lib
{
    public class FolderAndFileStats
    {
        public int FolderCount { get; set; }
        public int FileCount { get; set; }
    }

    public class Finder
    {
        private FindOptions _options;
        private IProgress<FindProgress> _progress;
        private IFileEvaluator _fileEvaluator;
        private FileEvaluationOptions _fileEvalOptions;

        public Finder(FindOptions options)
        {
            _fileEvaluator = options.FileEvaluator;
            if (_fileEvaluator == null) {
                throw new InvalidOperationException("options.FileEvaluator cannot be null");
            }
            _fileEvalOptions = new FileEvaluationOptions { SearchKeys = options.SearchKeys };
            _options = options;
            _progress = options.Progress;
        }

        private void reportProgress(FindProgress progress) {
            if (_progress != null) {
                _progress.Report(progress);
            }
        }

        public async Task<FindResult> Start()
        {
            return await Task.Run(() => {
                try
                {
                    var progress = new FindProgress { Phase = FindProgressPhase.Prepping };
                    reportProgress(progress);
                    var rootFolder = new DirectoryInfo(_options.StartFolder);
                    var folderAndFileStats = new FolderAndFileStats { FolderCount = 1 };
                    GetStats(rootFolder, folderAndFileStats);
                    progress.AllTotal = folderAndFileStats.FileCount;

                    reportProgress(new FindProgress { Phase = FindProgressPhase.PrepDone });

                    var findResult = new FindResult();
                    findResult.FindOptions = _options;
                    findResult.Results = new List<FindResultItem>();
                    var currentFileIndex = 0;
                    Find(rootFolder, folderAndFileStats, findResult, ref currentFileIndex);
                    reportProgress(new FindProgress { Phase = FindProgressPhase.Done});
                    return findResult;
                }
                catch(Exception exc)
                {
                    reportProgress(new FindProgress { Phase = FindProgressPhase.DoneWithErrors });
                    return new FindResult {
                        FindOptions = _options,
                        HadErrors = true,
                        Error = exc
                    };
                }
            });

        }

        protected void GetStats(DirectoryInfo folder, FolderAndFileStats runningStats) {
            runningStats.FileCount += folder.GetFiles().Count();
            foreach(var subFolder in folder.GetDirectories())
            {
                runningStats.FolderCount++;
                GetStats(subFolder, runningStats);
            }
        }

        protected void Find(DirectoryInfo folder, FolderAndFileStats stats, FindResult findResult, ref int currentFileIndex)
        {
            var fileIndexWithinParent = 0;
            var filesThisFolder = folder.GetFiles();
            var totalThisFolder = filesThisFolder.Count();
            foreach (var file in filesThisFolder)
            {
                fileIndexWithinParent++;
                currentFileIndex++;
                var progress = new FindProgress {
                    Phase = FindProgressPhase.Finding,
                    Filename = file.FullName,
                    IndexInParentFolder = fileIndexWithinParent,
                    ParentFolderTotal = totalThisFolder,
                    AllIndex = currentFileIndex,
                    AllTotal = stats.FileCount
                };

                if (_fileEvaluator.IsInterestedInFile(_fileEvalOptions, file)) {
                    findResult.Results.Add(
                        new FindResultItem {
                             FullFilename = file.FullName
                    });
                }

                reportProgress(progress);
            }
            foreach (var subfolder in folder.GetDirectories()) {
                Find(subfolder, stats, findResult, ref currentFileIndex);
            }
        }

    }
}

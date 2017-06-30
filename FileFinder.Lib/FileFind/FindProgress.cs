using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Lib
{
    public enum FindProgressPhase
    {
        Prepping,
        PrepDone,
        Finding,
        DoneWithErrors,
        Done
    }

    public class FindProgress
    {
        public string Filename { get; set; }

        public FindProgressPhase Phase { get; set; }

        public int ParentFolderTotal { get; set; }
        public int IndexInParentFolder{ get; set; }

        public int AllIndex { get; set; }
        public int AllTotal { get; set; }

    }
}

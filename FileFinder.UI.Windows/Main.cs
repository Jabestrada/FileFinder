using FileFinder.Lib;
using FileFinder.Lib.FileEvaluation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileFinder.UI.Windows
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void findButton_Click(object sender, EventArgs e)
        {
            var searchKeys = inputPatterns.Text
                            .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(s => !string.IsNullOrWhiteSpace(s))
                            .ToArray();
            var output = new StringBuilder();

            IFileEvaluator fileEvaluator = null;
            if (optFileContainsSubstring.Checked) {
                fileEvaluator = new FilenameSubstringEvaluator();
            } else if (optFileHasConfigExtension.Checked)
            {
                fileEvaluator = new FilenameSubstringWithConfigExtensionEvaluator();
            } else if (optFileDoesNotHaveConfigExtension.Checked)
            {
                fileEvaluator = new FilenameSubstringWithoutConfigExtensionEvaluator();
            }

            var fileFinder = new Finder(
                new FindOptions
                {
                    StartFolder = startFolder.Text,
                    SearchKeys = searchKeys,
                    FileEvaluator = fileEvaluator,
                    Progress = new Progress<FindProgress>(progress =>
                    {
                        if (progress.Phase == FindProgressPhase.Finding)
                        {
                            statusLabel.Text = string.Format("{0} of {1}", progress.AllIndex, progress.AllTotal);
                            Console.Out.WriteLine(string.Format("{0} of {1}", progress.AllIndex, progress.AllTotal));
                        }
                    })
                }
            );

            var findResult = await fileFinder.Start();
            if (findResult.HadErrors)
            {
                MessageBox.Show("Error occurred: " + findResult.Error.Message);
            }
            else
            {
                foreach (var result in findResult.Results)
                {
                    output.AppendLine(result.FullFilename);
                }
                resultsTextbox.Text = output.ToString();
                MessageBox.Show(string.Format("Matches found: {0}", findResult.Results.Count));
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

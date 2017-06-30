namespace FileFinder.UI.Windows
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputPatterns = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.resultsTextbox = new System.Windows.Forms.TextBox();
            this.startFolder = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.optFileContainsSubstring = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optFileDoesNotHaveConfigExtension = new System.Windows.Forms.RadioButton();
            this.optFileHasConfigExtension = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputPatterns
            // 
            this.inputPatterns.Location = new System.Drawing.Point(49, 199);
            this.inputPatterns.Multiline = true;
            this.inputPatterns.Name = "inputPatterns";
            this.inputPatterns.Size = new System.Drawing.Size(1284, 192);
            this.inputPatterns.TabIndex = 0;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(1151, 538);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(182, 79);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // resultsTextbox
            // 
            this.resultsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsTextbox.Location = new System.Drawing.Point(59, 727);
            this.resultsTextbox.Multiline = true;
            this.resultsTextbox.Name = "resultsTextbox";
            this.resultsTextbox.ReadOnly = true;
            this.resultsTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextbox.Size = new System.Drawing.Size(1284, 382);
            this.resultsTextbox.TabIndex = 0;
            this.resultsTextbox.Text = "C:\\JABE\\Temp";
            // 
            // startFolder
            // 
            this.startFolder.Location = new System.Drawing.Point(49, 96);
            this.startFolder.Name = "startFolder";
            this.startFolder.Size = new System.Drawing.Size(1284, 38);
            this.startFolder.TabIndex = 2;
            this.startFolder.Text = "C:\\inetpub\\wwwroot\\sitecore01\\Website\\App_Config";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(53, 645);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(93, 32);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "label1";
            // 
            // optFileContainsSubstring
            // 
            this.optFileContainsSubstring.AutoSize = true;
            this.optFileContainsSubstring.Checked = true;
            this.optFileContainsSubstring.Location = new System.Drawing.Point(32, 26);
            this.optFileContainsSubstring.Name = "optFileContainsSubstring";
            this.optFileContainsSubstring.Size = new System.Drawing.Size(407, 36);
            this.optFileContainsSubstring.TabIndex = 4;
            this.optFileContainsSubstring.TabStop = true;
            this.optFileContainsSubstring.Text = "Filename contains substring";
            this.optFileContainsSubstring.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optFileDoesNotHaveConfigExtension);
            this.panel1.Controls.Add(this.optFileHasConfigExtension);
            this.panel1.Controls.Add(this.optFileContainsSubstring);
            this.panel1.Location = new System.Drawing.Point(59, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 210);
            this.panel1.TabIndex = 5;
            // 
            // optFileDoesNotHaveConfigExtension
            // 
            this.optFileDoesNotHaveConfigExtension.AutoSize = true;
            this.optFileDoesNotHaveConfigExtension.Location = new System.Drawing.Point(32, 125);
            this.optFileDoesNotHaveConfigExtension.Name = "optFileDoesNotHaveConfigExtension";
            this.optFileDoesNotHaveConfigExtension.Size = new System.Drawing.Size(921, 36);
            this.optFileDoesNotHaveConfigExtension.TabIndex = 6;
            this.optFileDoesNotHaveConfigExtension.Text = "Filename contains substring and DOES NOT HAVE .config extension";
            this.optFileDoesNotHaveConfigExtension.UseVisualStyleBackColor = true;
            // 
            // optFileHasConfigExtension
            // 
            this.optFileHasConfigExtension.AutoSize = true;
            this.optFileHasConfigExtension.Location = new System.Drawing.Point(32, 79);
            this.optFileHasConfigExtension.Name = "optFileHasConfigExtension";
            this.optFileHasConfigExtension.Size = new System.Drawing.Size(737, 36);
            this.optFileHasConfigExtension.TabIndex = 5;
            this.optFileHasConfigExtension.Text = "Filename contains substring and has .config extension";
            this.optFileHasConfigExtension.UseVisualStyleBackColor = true;
            this.optFileHasConfigExtension.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 1121);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.startFolder);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.resultsTextbox);
            this.Controls.Add(this.inputPatterns);
            this.Name = "Main";
            this.Text = "File Finder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputPatterns;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox resultsTextbox;
        private System.Windows.Forms.TextBox startFolder;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.RadioButton optFileContainsSubstring;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optFileHasConfigExtension;
        private System.Windows.Forms.RadioButton optFileDoesNotHaveConfigExtension;
    }
}


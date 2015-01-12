namespace GFindStr
{
    partial class GFindStrForm
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
            this.logResult = new System.Windows.Forms.TextBox();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.comboBoxCase = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.logFull = new System.Windows.Forms.TextBox();
            this.logFilter = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearchFull = new System.Windows.Forms.Button();
            this.buttonSearchResults = new System.Windows.Forms.Button();
            this.comboBoxClick = new System.Windows.Forms.ComboBox();
            this.checkBoxAutoFocus = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logResult
            // 
            this.logResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.logResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logResult.HideSelection = false;
            this.logResult.Location = new System.Drawing.Point(0, 0);
            this.logResult.Multiline = true;
            this.logResult.Name = "logResult";
            this.logResult.ReadOnly = true;
            this.logResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logResult.Size = new System.Drawing.Size(500, 656);
            this.logResult.TabIndex = 1;
            this.logResult.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<Drag text file here to begin>";
            this.logResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.logResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.logResult_MouseClick);
            this.logResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.logResult_MouseDoubleClick);
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Location = new System.Drawing.Point(74, 0);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(89, 21);
            this.comboBoxMode.TabIndex = 4;
            this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
            // 
            // comboBoxCase
            // 
            this.comboBoxCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCase.FormattingEnabled = true;
            this.comboBoxCase.Location = new System.Drawing.Point(0, -1);
            this.comboBoxCase.Name = "comboBoxCase";
            this.comboBoxCase.Size = new System.Drawing.Size(68, 21);
            this.comboBoxCase.TabIndex = 5;
            this.comboBoxCase.SelectedIndexChanged += new System.EventHandler(this.comboBoxCase_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 26);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.logResult);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.logFull);
            this.splitContainer1.Size = new System.Drawing.Size(992, 656);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 6;
            // 
            // logFull
            // 
            this.logFull.BackColor = System.Drawing.Color.WhiteSmoke;
            this.logFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logFull.HideSelection = false;
            this.logFull.Location = new System.Drawing.Point(0, 0);
            this.logFull.Multiline = true;
            this.logFull.Name = "logFull";
            this.logFull.ReadOnly = true;
            this.logFull.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logFull.Size = new System.Drawing.Size(488, 656);
            this.logFull.TabIndex = 2;
            // 
            // logFilter
            // 
            this.logFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logFilter.FormattingEnabled = true;
            this.logFilter.Location = new System.Drawing.Point(169, 0);
            this.logFilter.Name = "logFilter";
            this.logFilter.Size = new System.Drawing.Size(825, 21);
            this.logFilter.TabIndex = 2;
            this.logFilter.SelectedIndexChanged += new System.EventHandler(this.logFilter_SelectedIndexChanged);
            this.logFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.logFilter_KeyUp);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearch.Location = new System.Drawing.Point(259, 687);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(163, 20);
            this.textBoxSearch.TabIndex = 7;
            this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyUp);
            // 
            // buttonSearchFull
            // 
            this.buttonSearchFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchFull.Location = new System.Drawing.Point(427, 687);
            this.buttonSearchFull.Name = "buttonSearchFull";
            this.buttonSearchFull.Size = new System.Drawing.Size(20, 20);
            this.buttonSearchFull.TabIndex = 8;
            this.buttonSearchFull.Text = ">";
            this.buttonSearchFull.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSearchFull.UseVisualStyleBackColor = true;
            this.buttonSearchFull.Click += new System.EventHandler(this.buttonSearchFull_Click);
            // 
            // buttonSearchResults
            // 
            this.buttonSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchResults.Location = new System.Drawing.Point(234, 687);
            this.buttonSearchResults.Name = "buttonSearchResults";
            this.buttonSearchResults.Size = new System.Drawing.Size(20, 20);
            this.buttonSearchResults.TabIndex = 9;
            this.buttonSearchResults.Text = "<";
            this.buttonSearchResults.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSearchResults.UseVisualStyleBackColor = true;
            this.buttonSearchResults.Click += new System.EventHandler(this.buttonSearchResults_Click);
            // 
            // comboBoxClick
            // 
            this.comboBoxClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxClick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxClick.FormattingEnabled = true;
            this.comboBoxClick.Location = new System.Drawing.Point(4, 686);
            this.comboBoxClick.Name = "comboBoxClick";
            this.comboBoxClick.Size = new System.Drawing.Size(80, 21);
            this.comboBoxClick.TabIndex = 10;
            // 
            // checkBoxAutoFocus
            // 
            this.checkBoxAutoFocus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAutoFocus.AutoSize = true;
            this.checkBoxAutoFocus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAutoFocus.Location = new System.Drawing.Point(105, 688);
            this.checkBoxAutoFocus.Name = "checkBoxAutoFocus";
            this.checkBoxAutoFocus.Size = new System.Drawing.Size(74, 17);
            this.checkBoxAutoFocus.TabIndex = 11;
            this.checkBoxAutoFocus.Text = "AutoFocus";
            this.checkBoxAutoFocus.UseVisualStyleBackColor = true;
            // 
            // GFindStrForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 708);
            this.Controls.Add(this.checkBoxAutoFocus);
            this.Controls.Add(this.comboBoxClick);
            this.Controls.Add(this.buttonSearchResults);
            this.Controls.Add(this.buttonSearchFull);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.logFilter);
            this.Controls.Add(this.comboBoxCase);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GFindStrForm";
            this.Text = "findstr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GFindStrForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.GFindStr_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.GFindStr_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logResult;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.ComboBox comboBoxCase;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox logFull;
        private System.Windows.Forms.ComboBox logFilter;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearchFull;
        private System.Windows.Forms.Button buttonSearchResults;
        private System.Windows.Forms.ComboBox comboBoxClick;
        private System.Windows.Forms.CheckBox checkBoxAutoFocus;
    }
}


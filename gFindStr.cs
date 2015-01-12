using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace GFindStr
{
    public partial class GFindStrForm : Form
    {
        private FindStrMode modeMatchAny = new FindStrMode("Match Any", String.Empty);
        private FindStrMode modeMatchExact = new FindStrMode("Match Exact", "/C:");
        private FindStrMode modeRegex = new FindStrMode("RegEx", "/R ");
        private string lastFileName = String.Empty;
        private string fileName;
        private long fullCount = 0;
        bool lastSearchedLogFull = false;
        bool bInit = false;
        AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

        public GFindStrForm(string filename)
        {
            InitializeComponent();
            comboBoxMode.Items.Add(modeMatchAny);
            comboBoxMode.Items.Add(modeMatchExact);
            comboBoxMode.Items.Add(modeRegex);
            comboBoxMode.SelectedIndex = 0;

            comboBoxCase.Items.Add("nocase");
            comboBoxCase.Items.Add("case");
            comboBoxCase.SelectedIndex = 0;

            comboBoxClick.Items.Add("doubleClick");
            comboBoxClick.Items.Add("singleClick");
            comboBoxClick.SelectedIndex = 0;

            checkBoxAutoFocus.Checked = true;

            logResult.Select(0, 0);
            logFilter.Select();

            logFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            logFilter.AutoCompleteSource = AutoCompleteSource.CustomSource;
            logFilter.AutoCompleteCustomSource = autoComplete;

            try
            {
                LoadSettings();
            }
            catch { }

            if( filename != string.Empty)
            {
                fileName = filename;
            }

            bInit = true;

            if(System.IO.File.Exists(fileName))
            {
                Process();
            }
        }

        private void GFindStrForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch { }
        }

        private void SaveSettings()
        {
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings.Clear();

            int index = 0;
            foreach( string search in autoComplete )
            {
                string key = String.Format("Search{0}", index++);
                config.AppSettings.Settings.Add(key, search);
            }

            config.AppSettings.Settings.Add("Height", Height.ToString());
            config.AppSettings.Settings.Add("Width", Width.ToString());
            config.AppSettings.Settings.Add("LocationX", Location.X.ToString());
            config.AppSettings.Settings.Add("LocationY", Location.Y.ToString());
            config.AppSettings.Settings.Add("WindowState", Enum.GetName(typeof(FormWindowState), WindowState));
            config.AppSettings.Settings.Add("Splitter", splitContainer1.SplitterDistance.ToString());
            config.AppSettings.Settings.Add("FileName", fileName);
            config.AppSettings.Settings.Add("Filter", logFilter.Text);
            config.AppSettings.Settings.Add("Click", comboBoxClick.Text);
            config.AppSettings.Settings.Add("AutoFocus", Convert.ToString(checkBoxAutoFocus.Checked));
            config.AppSettings.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);
        }

        private void LoadSettings()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
                if (key.Contains("Search"))
                {
                    autoComplete.Add(value);
                    logFilter.Items.Add(value);
                }
            }

            if (ConfigurationManager.AppSettings["Height"] != null)
            {
                Height = Convert.ToInt32(ConfigurationManager.AppSettings["Height"]);
                Width = Convert.ToInt32(ConfigurationManager.AppSettings["Width"]);
                Location = new Point(Convert.ToInt32(ConfigurationManager.AppSettings["LocationX"]),
                                    Convert.ToInt32(ConfigurationManager.AppSettings["LocationY"]));
                FormWindowState state = (FormWindowState)Enum.Parse(typeof(FormWindowState),
                                        ConfigurationManager.AppSettings["WindowState"], true);
                splitContainer1.SplitterDistance = Convert.ToInt32(ConfigurationManager.AppSettings["Splitter"]);
                fileName = ConfigurationManager.AppSettings["FileName"];
                logFilter.Text = ConfigurationManager.AppSettings["Filter"];
                comboBoxClick.Text = ConfigurationManager.AppSettings["Click"];
                checkBoxAutoFocus.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["AutoFocus"]);
                StartPosition = FormStartPosition.Manual;
            }
        }

        private void RunFilter()
        {
            this.Text = "gFindStr - " + fileName;
            logResult.Clear();
            logResult.TextAlign = HorizontalAlignment.Left;

            if (logFilter.Text == String.Empty)
            {
                FillTextBox(logResult, modeRegex, ".*");
                logFull.Text = logResult.Text;
                fullCount = CountLinesInString(logFull.Text);
            }
            else
            {
                if(( logFilter.Text.Trim() != String.Empty) &&
                    !autoComplete.Contains(logFilter.Text))
                {
                    autoComplete.Add(logFilter.Text);
                    logFilter.Items.Add(logFilter.Text);
                }

                FillTextBox(logResult, (FindStrMode)comboBoxMode.SelectedItem, logFilter.Text);

                if (fileName != lastFileName)
                {
                    FillTextBox(logFull, modeRegex, ".*");
                    fullCount = CountLinesInString(logFull.Text);
                }
            }

            logFull.SelectionStart = 0;
            logFull.SelectionLength = 0;
            logResult.SelectionStart = 0;
            logResult.SelectionLength = 0;

            lastFileName = fileName;

            this.Text = String.Format("gFindStr - {2}   ({0}/{1})", CountLinesInString(logResult.Text), fullCount, fileName);

            logResult.Focus();
        }

        private void FillTextBox(TextBox tb, FindStrMode mode, string filter)
        {
            bool nocase = comboBoxCase.SelectedItem.ToString() == "nocase";

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.CreateNoWindow = true;
           
            p.StartInfo.Arguments =
                String.Format("/c type \"{3}\" | findstr.exe /P /N {0} {1}\"{2}\"", (nocase ? "/I" : ""),
                   mode.Option, filter, fileName);

            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            tb.Text = output.Replace('\0', ' ');
            p.WaitForExit();
        }

        private void Process()
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                RunFilter();
            }
            catch(Exception e)
            {
                logResult.Text = "<" + e.Message + ">";
            }

            Cursor.Current = oldCursor;
        }

        private void GFindStr_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (files != null && files.Length > 0)
            {
                fileName = files[0];

            }
            else
            {
                fileName = String.Empty;
            }

            Process();
        }

        private void GFindStr_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        static long CountLinesInString(string s)
        {
            long count = 0;
            int start = 0;
            while ((start = s.IndexOf('\n', start)) != -1)
            {
                count++;
                start++;
            }
            return count;
        }

        private void logFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return )
            {
                Process();
            }
        }

        private void PairSelection()
        {
            int index = logResult.GetFirstCharIndexOfCurrentLine();
            if (index == -1) return;
            int pos = logResult.Text.IndexOf('\r', index) + 1;
            if (pos == -1) return;
            int len = pos - index;
            string searchstring = logResult.Text.Substring(index, len);
            int index2 = logFull.Text.IndexOf(searchstring);
            if (index2 == -1) return;

            SuspendLayout();

            logResult.Select(index, len);

            logFull.Select(logFull.Text.Length, 0);
            logFull.ScrollToCaret();

            logFull.Select(index2, searchstring.Length);
            Point pt = logFull.GetPositionFromCharIndex(index2);
            logFull.ScrollToCaret();

            if (checkBoxAutoFocus.Checked)
            {
                logFull.Focus();
            }

            ResumeLayout(true);
        }

        private void logResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (comboBoxClick.SelectedItem.ToString() == "doubleClick")
            {
                PairSelection();
            }
        }

        private void logResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBoxClick.SelectedItem.ToString() == "singleClick")
            {
                PairSelection();
            }
        }

        private void logFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process();
        }

        private void SearchTextBox(TextBox textBox)
        {
            if (textBoxSearch.Text == string.Empty)
            {
                return;
            }

            int index = textBox.SelectionStart + 1;
            if (index == -1) return;
            int pos = textBox.Text.IndexOf(textBoxSearch.Text, index);
            if (pos == -1)
            {
                pos = textBox.Text.IndexOf(textBoxSearch.Text, 0);
                if (pos == -1)
                {
                    textBoxSearch.ForeColor = Color.Red;
                    return;
                }
            }

            textBoxSearch.ForeColor = Color.Black;

            textBox.Select(textBox.Text.Length, 0);
            textBox.ScrollToCaret();

            textBox.Select(pos, textBoxSearch.Text.Length);
            textBox.ScrollToCaret();
        }

        private void buttonSearchResults_Click(object sender, EventArgs e)
        {
            SearchTextBox(logResult);
            lastSearchedLogFull = false;
        }

        private void buttonSearchFull_Click(object sender, EventArgs e)
        {
            SearchTextBox(logFull);
            lastSearchedLogFull = true;
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SearchTextBox(lastSearchedLogFull ? logFull : logResult);
            }
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bInit)
            {
                Process();
            }
        }

        private void comboBoxCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bInit)
            {
                Process();
            }
        }
    }

    class FindStrMode : object
    {
        private string modeText;
        private string optionText;

        public FindStrMode(string mode, string option)
        {
            modeText = mode;
            optionText = option;
        }

        public string Mode
        {
            get { return modeText; }
        }

        public string Option
        {
            get { return optionText; }
        }

        public override string ToString()
        {
            return modeText;
        }
    }
}

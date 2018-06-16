using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PKeeper
{

    public partial class GridForm : Form
    {
        enum TValidFile { noValidFileSelected, validFileSelected, validFileWrongPassword };
        private DateTime StartTime = DateTime.Now;
        private TValidFile validFile;
        private List<GridTabClass> gridTabs;
        String PIN = "";

        public GridForm()
        {
            InitializeComponent();
            gridTabs = new List<GridTabClass>();
        //------------------------------------//
        Retry:
            btn_reloadFile.Enabled = false;
            tabControl1.TabPages.Clear();
            listBox1.Items.Clear();
            splitPanel.SplitterDistance = (int)Program.baseKey.GetValue("Sections Width", 200);
            splitPanel.Panel1Collapsed = Convert.ToBoolean(Program.baseKey.GetValue("Sections Collapsed", false));
            btn_expand.Visible = splitPanel.Panel1Collapsed;
            currentDATFile = Program.baseKey.GetValue("DAT File", "").ToString();
            if (currentDATFile.Trim() == "")
            {
                MessageBox.Show("It seems it's the first time you are using PKeeper.\nYou must choose a file where passwords will be kept", "User action is needed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                FirstTimeLoad(true);
            }
            else if (Program.PINRetries <= 0)
            {
                if (MessageBox.Show("You have unsuccesfully tried to open the file.\nDo you want to choose another?", "Fail", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!FirstTimeLoad(true))
                        Environment.Exit(0);
                    else
                        Program.PINRetries = 3;
                }
                else
                    Environment.Exit(0);

            }
            else if (!loadFromFile())
                if (validFile == TValidFile.validFileWrongPassword)
                    goto Retry;
                else if (MessageBox.Show("Do you want to recreate the file? All data will be lost!!!", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Delete(currentDATFile);
                    var myFile = File.Create(currentDATFile);
                    myFile.Close();
                }
                else
                    if (!chooseFile(false))
                    goto Retry;
            //------------------------------------//
            StartTime = DateTime.Now;
            //idleTimer.Start();
            chk_timeOut.Checked = Convert.ToBoolean(Program.baseKey.GetValue("Timeout", true));
            //countDownTimer.Start();
            assignAllClicks(this.Controls);
        }

        private String CurrentDATFile;
        public String currentDATFile
        {
            get
            {
                return CurrentDATFile;
            }
            set
            {
                CurrentDATFile = value;
                toolStripStatusLabel1.Text = value;
                Program.baseKey.SetValue("DAT File", CurrentDATFile);
            }
        }

        public bool FirstTimeLoad(bool BReset)
        {
            if (BReset || currentDATFile.Trim() == "" || !File.Exists(currentDATFile))
            {
                Program.baseKey.SetValue("DAT File", "");
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.FileName = "PKeeper.dat";
            }
            else
            {
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(CurrentDATFile);
                openFileDialog1.FileName = Path.GetFileName(CurrentDATFile);
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    if (MessageBox.Show("File already exists.\nDo you want to recreate the file?\nAll data will be lost!!!", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(openFileDialog1.FileName);
                        }
                        catch { }
                        Application.DoEvents();
                        if (File.Exists(openFileDialog1.FileName))
                        {
                            MessageBox.Show("Could not overwrite file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return FirstTimeLoad(false);
                        }
                    }
                    else
                    {
                        return FirstTimeLoad(true);
                    }
                }
            }
            else
            {
                MessageBox.Show("No valid password file was chosen.\nThe program will exit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return false;
            }
            PinForm pinForm = new PinForm(this, false);
            pinForm.Text = "Please enter a new password";
        EnterFirstTimePIN:
            String tmpPIN = "";
            if (pinForm.ShowDialog() == DialogResult.OK)
            {
                tmpPIN = pinForm.maskedPIN.Text;
                pinForm.Text = "Please verify your password";
                if (pinForm.ShowDialog() == DialogResult.OK)
                {
                    if (pinForm.maskedPIN.Text == tmpPIN)
                        PIN = tmpPIN;
                    else
                    {
                        MessageBox.Show("The passwords don't match.\nPlease retry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto EnterFirstTimePIN;
                    }
                    currentDATFile = openFileDialog1.FileName;
                    saveToFile();
                    return true;
                }
                else
                    return false;

            }
            else
            {
                MessageBox.Show("No valid password was chosen.\nThe program will exit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return false;
            }
        }

        private void DoOnApplicationIdle(object sender, EventArgs e)
        {
            if (!idleTimer.Enabled)
            {
                StartTime = DateTime.Now;
                countDownTimer.Start();
                idleTimer.Start();
            }
        }

        private void assignAllClicks(Control.ControlCollection prntControls)
        {
            foreach (Control fc in prntControls)
            {
                fc.Click += Generic_Click;
                if (fc.Controls.Count > 0)
                    assignAllClicks(fc.Controls);
            }
        }

        private void idleTimer_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Generic_Click(object sender, EventArgs e)
        {
            idleTimer.Stop();
        }

        private bool loadFromFile(bool askForPIN = true)
        {
            String[] textLines;
            try
            {
                textLines = File.ReadAllLines(currentDATFile, Encoding.Default);
                if (textLines.Length != 0)
                {
                    if (textLines[0] != "PKeeperV2")
                        throw new System.ArgumentException("The file \"" + currentDATFile + "\" is invalid!");
                    validFile = TValidFile.validFileSelected;
                    if (askForPIN)
                    {
                        PinForm pinForm = new PinForm(this, true);
                        DialogResult dr;
                        dr = pinForm.ShowDialog();
                        if (dr == DialogResult.Cancel)
                        {
                            MessageBox.Show("Password verification canceled by user.\nThe program will exit!", "Aborting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Environment.Exit(0);
                        }
                        if ((dr != DialogResult.OK) || (textLines[1] != pinForm.maskedPIN.Text))
                        {
                            validFile = TValidFile.validFileWrongPassword;
                            throw new System.ArgumentException("Wrong password!");
                        }
                        else
                            PIN = textLines[1];
                    }
                    validFile = TValidFile.validFileSelected;
                    String[] Sections = textLines[2].Split('\a');
                    textLines = textLines.Skip(3).ToArray();
                    string[] gridData = String.Join("\n", textLines).Split('\0');
                    for (int x = 0; x <= listBox1.Items.Count - 1; x++)
                        DeleteTab(listBox1.Items[x].ToString());
                    listBox1.Items.Clear();
                    for (int x = 0; x <= Sections.Length - 1; x++)
                    {
                        GridTabClass tmpGtb = AddNewTab(Sections[x]);
                        if (x < gridData.Count())
                            textToGridView(gridData[x], ref tmpGtb);
                    }
                    if (listBox1.Items.Count > 0)
                        listBox1.SelectedIndex = 0;
                    DoKeys();
                }
                else // Empty file
                {
                    throw new System.ArgumentException("The passwords file is empty!");
                }
                validFile = TValidFile.validFileSelected;
                btn_reloadFile.Enabled = true;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private String gridViewToText(GridTabClass inGridView)
        {
            String result = "";
            for (int x = 0; x <= inGridView.TabGrid.Rows.Count - 1; x++)
            {
                if (!inGridView.TabGrid.Rows[x].IsNewRow)
                {
                    for (int y = 0; y <= inGridView.TabGrid.Rows[x].Cells.Count - 1; y++)
                    {
                        result += (y > 0 ? "\a" : "") + inGridView.TabGrid.Rows[x].Cells[y].Value;
                    }
                    result += '\n';
                }
            }
            return result;
        }

        private void textToGridView(String inText, ref GridTabClass inGridView)
        {
            if (inText.Trim() == "")
                return;
            inGridView.EnableCellEnter(false);
            try
            {
                String[] lines = inText.Split('\n');
                String[] cells;
                inGridView.TabGrid.Rows.Clear();
                lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                inGridView.TabGrid.Rows.Add(lines.Length);

                for (int x = 0; x <= lines.Length - 1; x++)
                {
                    cells = lines[x].Split('\a');
                    for (int y = 0; y <= cells.Length - 1; y++)
                        inGridView.TabGrid.Rows[x].Cells[y].Value = cells[y];
                }
            }
            finally
            {
                inGridView.EnableCellEnter(true);
            }
        }

        private bool saveToFile()
        {

            String fileText = "PKeeperV2\n" + PIN + '\n';

            for (int x = 0; x <= listBox1.Items.Count - 1; x++)
                fileText += listBox1.Items[x].ToString() + '\a';
            fileText += '\n';
            foreach (GridTabClass tmpView in gridTabs)
                fileText += gridViewToText(tmpView) + "\0";
            File.Delete(currentDATFile);
            File.WriteAllText(currentDATFile, fileText);
            return true;
        }

        private void DoKeys()
        {
            btn_addTab.Enabled = (textBox1.Text != "") && (((listBox1.Items.Count > 0) && (textBox1.Text != listBox1.SelectedItem.ToString()))
                                                      || (listBox1.Items.Count == 0));
            toolTip1.SetToolTip(btn_addTab, "Add new section");
            btn_renameTab.Enabled = (textBox1.Text != "") && (listBox1.Items.Count > 0) && (textBox1.Text != listBox1.SelectedItem.ToString());
            toolTip2.SetToolTip(btn_renameTab, "Rename current section");
            btn_deleteTab.Enabled = listBox1.Items.Count > 0;
            toolTip3.SetToolTip(btn_deleteTab, "Delete current section");
        }

        private GridTabClass AddNewTab(string inTabName)
        {
            inTabName = inTabName.Trim();
            if (inTabName == "")
                return null;
            GridTabClass newTab = new GridTabClass(this, tabControl1, inTabName);
            gridTabs.Add(newTab);
            listBox1.Items.Add(inTabName);
            listBox1.SetSelected(listBox1.Items.Count - 1, true);
            assignAllClicks(newTab.Controls);
            return newTab;
        }

        private void DeleteTab(string inTabName)
        {
            GridTabClass tabToDelete = null;
            foreach (GridTabClass gtb in gridTabs)
            {
                if (gtb.gridTabName == inTabName)
                {
                    tabToDelete = gtb;
                    break;
                }

            }
            if (tabToDelete != null)
            {
                gridTabs.Remove(tabToDelete);
                tabControl1.TabPages.Remove(tabToDelete);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void btn_addTab_Click(object sender, EventArgs e)
        {
            bool found = false;
            for (int x = 0; x <= listBox1.Items.Count - 1; x++)
            {
                if (textBox1.Text.ToUpper().Equals(listBox1.Items[x].ToString().ToUpper()))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                AddNewTab(textBox1.Text);
            else
                MessageBox.Show("There is already a section with that name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DoKeys();
        }

        private void btn_deleteTab_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The current section will be deleted.\nAll the passwords on this section will be lost.\nAre you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes)
                return;
            if (listBox1.SelectedIndex >= 0)
            {
                int i = listBox1.SelectedIndex;
                listBox1.SelectedValueChanged -= listBox1_SelectedValueChanged; //unbind event
                DeleteTab(listBox1.SelectedItem.ToString());
                listBox1.Items.RemoveAt(i);
                listBox1.SelectedValueChanged += new EventHandler(listBox1_SelectedValueChanged); // bind event
                listBox1.SelectedIndex = Math.Min(i, listBox1.Items.Count - 1);
            }
            if (listBox1.Items.Count > 0)
                textBox1.Text = listBox1.SelectedItem.ToString();
            else
                textBox1.Text = "";
            DoKeys();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndexChanged -= tabControl1_SelectedIndexChanged;
            textBox1.Text = listBox1.SelectedItem.ToString();
            for (int x = 0; x <= tabControl1.TabCount - 1; x++)
            {
                if (((GridTabClass)tabControl1.TabPages[x]).gridTabName == listBox1.SelectedItem.ToString())
                    tabControl1.SelectedIndex = x;
            }
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 0)
                for (int x = 0; x <= listBox1.Items.Count - 1; x++)
                {
                    if (((GridTabClass)((TabControl)sender).SelectedTab).gridTabName == listBox1.Items[x].ToString())
                        listBox1.SelectedIndex = x;
                }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            idleTimer.Stop();
            DataGridView currentGrid = null;
            if (this.ActiveControl != null && this.ActiveControl.GetType() == typeof(DataGridView))
                currentGrid = (DataGridView)this.ActiveControl;
            if (currentGrid == null || currentGrid.CurrentCell == null)
                return base.ProcessCmdKey(ref msg, keyData);
            int icolumn = currentGrid.CurrentCell.ColumnIndex;
            int irow = currentGrid.CurrentCell.RowIndex;

            if (keyData == Keys.Enter)
            {
                if (icolumn == currentGrid.Columns.Count - 1)
                {
                    currentGrid.Rows.Add();
                    currentGrid.CurrentCell = currentGrid[0, irow + 1];
                }
                else
                {
                    currentGrid.CurrentCell = currentGrid[icolumn + 1, irow];
                }
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DoKeys();
            if (listBox1.Items.Count > 0)
            {
                if (listBox1.SelectedItem.ToString() != textBox1.Text)
                    textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
                else
                    textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
            }
        }

        public bool createNewFile()
        {
            return true;
        }

        public bool chooseFile(bool showWarning)
        {
            if (showWarning && MessageBox.Show("Any changes will be lost.\nAre you sure?", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.No)
                return false;
            String tmpDatFile = currentDATFile;
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(CurrentDATFile);
            openFileDialog1.FileName = Path.GetFileName(CurrentDATFile);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentDATFile = openFileDialog1.FileName;
                if (!loadFromFile())
                {
                    if (MessageBox.Show("Do you want to recreate the file? All data will be lost!!!", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        File.Delete(currentDATFile);
                        File.Create(currentDATFile);
                        Program.baseKey.SetValue("DAT File", currentDATFile);
                        return true;
                    }
                    else
                    {
                        currentDATFile = tmpDatFile;
                        return false;
                    }
                }
                else
                {
                    Program.baseKey.SetValue("DAT File", currentDATFile);
                    return true;
                }

            }
            else
                return false;
        }

        private void btn_chooseFile_Click(object sender, EventArgs e)
        {
            chooseFile(true);
        }

        private void btn_renameTab_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The current section will be renamed.\nAre you sure?", "Rename", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes)
                return;
            listBox1.SelectedValueChanged -= listBox1_SelectedValueChanged;
            listBox1.Items[listBox1.SelectedIndex] = textBox1.Text;
            ((GridTabClass)tabControl1.SelectedTab).gridTabName = textBox1.Text;
            listBox1.SelectedValueChanged += listBox1_SelectedValueChanged;
            DoKeys();
            textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
        }

        private void btn_reloadFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Any changes will be lost.\nAre you sure?", "Rename", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes)
                return;
            loadFromFile(false);
        }

        private void btn_saveFile_Click(object sender, EventArgs e)
        {
            saveToFile();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveToFile();
            Program.baseKey.SetValue("DAT File", CurrentDATFile);
            Program.baseKey.SetValue("Sections Collapsed", splitPanel.Panel1Collapsed);
            Program.baseKey.SetValue("Sections Width", splitPanel.SplitterDistance);
            Program.baseKey.SetValue("Timeout", chk_timeOut.Checked);
            Program.baseKey.Dispose();
            Application.Idle -= DoOnApplicationIdle;
        }

        private void btn_changePassword_Click(object sender, EventArgs e)
        {
            PinForm pinForm = new PinForm(this, false);
            pinForm.Text = "Give current password";
            if ((pinForm.ShowDialog() != DialogResult.OK) || (PIN != pinForm.maskedPIN.Text))
            {
                MessageBox.Show("Wrong password!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pinForm.Dispose();
            pinForm = new PinForm(this, false);
            if (pinForm.ShowDialog() == DialogResult.OK)
            {
                PIN = pinForm.maskedPIN.Text;
                MessageBox.Show("Password changed succesfully");
                saveToFile();
            }

        }

        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            String rmnd = "00";
            if (idleTimer.Enabled)
            {
                TimeSpan remaining;
                try
                {
                    DateTime timeout = StartTime.AddSeconds(idleTimer.Interval / 1000);
                    remaining = timeout.Subtract(DateTime.Now);
                    rmnd = remaining.TotalSeconds.ToString("00");
                }
                finally
                {
                    lblTimeLeft.Text = "Time Remaining " + rmnd;
                }
                if (remaining.TotalSeconds <= 10)
                    lblTimeLeft.ForeColor = Color.Red;
                else
                    lblTimeLeft.ForeColor = Color.Black;
            }
            else
            {
                lblTimeLeft.Text = "Time Remaining 60";
                countDownTimer.Stop();
            }
        }

        private void btn_collapse_Click(object sender, EventArgs e)
        {
            splitPanel.Panel1Collapsed = true;
            btn_expand.Visible = true;
        }

        private void btn_expand_Click(object sender, EventArgs e)
        {
            splitPanel.Panel1Collapsed = false;
            btn_expand.Visible = false;
        }


        private void chk_timeOut_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_timeOut.Checked)
            {
                Application.Idle += DoOnApplicationIdle;
            }
            else
            {
                Application.Idle -= DoOnApplicationIdle;
                countDownTimer.Stop();
                idleTimer.Stop();
                lblTimeLeft.Text = "Time Remaining 60";
            }
        }
    }



}
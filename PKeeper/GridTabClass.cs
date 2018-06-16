using System;
using System.Windows.Forms;

namespace PKeeper
{
   public class GridTabClass : TabPage
   {
      private Panel topGridPanel;
      private Button AddRec;
      private Button DelRec;
      private Button btnURL;
      private Button btnUsername;
      private Button btnPassword;
      private GridForm classParent;
      private TabControl parentTabControl;

      public DataGridView TabGrid;
      private DataGridView tabGrid
      {
         get { return TabGrid; }
         set { TabGrid = value; }
      }

      private String GridTabName;
      public String gridTabName
      {
         get
         {
            return GridTabName;
         }
         set
         {
            GridTabName = value;
            this.Text = value;
         }
      }

      public GridTabClass(GridForm ClassParent, TabControl ParentTabControl, string TabTitle) : base()
      {
         parentTabControl = ParentTabControl;
         parentTabControl.TabPages.Add(this);
         classParent = ClassParent;
         this.Text = TabTitle;
         gridTabName = TabTitle;

         // Data Grid
         tabGrid = new DataGridView();
         tabGrid.Name = "grd_" + TabTitle;
         tabGrid.Dock = DockStyle.Fill;
         tabGrid.Parent = this;
         tabGrid.AllowUserToAddRows = false;
         tabGrid.RowValidating += Grid_RowValidating;
         tabGrid.CellEnter += tabGrid_CellEnter;
         tabGrid.CellBeginEdit += tabGrid_CellBeginEdit;
         tabGrid.CellFormatting += tabGrid_CellFormatting;
         DataGridViewTextBoxCell cellTemplate = new DataGridViewTextBoxCell();

         DataGridViewColumn col1 = new DataGridViewColumn(cellTemplate);
         col1.HeaderText = "URL";
         col1.Width = 250;
         tabGrid.Columns.Add(col1);
         DataGridViewColumn col2 = new DataGridViewColumn(cellTemplate);
         col2.HeaderText = "Description";
         col2.Width = 250;
         tabGrid.Columns.Add(col2);
         DataGridViewColumn col3 = new DataGridViewColumn(cellTemplate);
         col3.HeaderText = "Username";
         col3.Width = 80;
         tabGrid.Columns.Add(col3);
         DataGridViewColumn col4 = new DataGridViewColumn(cellTemplate);
         col4.HeaderText = "Password";
         col4.Width = 80;
         tabGrid.Columns.Add(col4);
         // Top Panel
         topGridPanel = new Panel();
         topGridPanel.Parent = this;
         topGridPanel.Dock = DockStyle.Top;
         topGridPanel.Height = 30;
         // Add-Delete Buttons
         AddRec = new Button();
         AddRec.Parent = topGridPanel;
         AddRec.ImageList = classParent.imageList1;
         AddRec.ImageIndex = 10;
         AddRec.Top = 3;
         AddRec.Left = 10;
         AddRec.Text = "";
         AddRec.Width = 30;
         AddRec.Click += AddRec_Click;
         DelRec = new Button();
         DelRec.Parent = topGridPanel;
         DelRec.ImageList = classParent.imageList1;
         DelRec.ImageIndex = 9;
         DelRec.Top = 3;
         DelRec.Left = 50;
         DelRec.Text = "";
         DelRec.Width = 30;
         DelRec.Click += DelRec_Click;
         // Grid Buttons
         btnURL = new Button();
         btnURL.Visible = false;
         btnURL.Parent = tabGrid;// ParentTabControl;
         btnURL.ImageList = classParent.imageList1;
         btnURL.ImageIndex = 0;
         btnURL.Click += btnURL_Click;
         btnURL.FlatStyle = FlatStyle.Flat;
         btnURL.FlatAppearance.BorderSize = 0;
         btnUsername = new Button();
         btnUsername.Visible = false;
         btnUsername.Parent = tabGrid;// ParentTabControl;
         btnUsername.ImageList = classParent.imageList1;
         btnUsername.ImageIndex = 1;
         btnUsername.Click += btnUsername_Click;
         btnUsername.FlatStyle = FlatStyle.Flat;
         btnUsername.FlatAppearance.BorderSize = 0;
         btnPassword = new Button();
         btnPassword.Visible = false;
         btnPassword.Parent = tabGrid;// ParentTabControl;
         btnPassword.ImageList = classParent.imageList1;
         btnPassword.ImageIndex = 1;
         btnPassword.Click += btnPassword_Click;
         btnPassword.FlatStyle = FlatStyle.Flat;
         btnPassword.FlatAppearance.BorderSize = 0;
      }

      public void EnableCellEnter(bool doEnable)
      {
         if(doEnable)
            tabGrid.CellEnter += tabGrid_CellEnter;
         else
            tabGrid.CellEnter -= tabGrid_CellEnter;
      }

      private void tabGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
      {
         btnURL.Visible = false;
         btnUsername.Visible = false;
         btnPassword.Visible = false;

         if((e.RowIndex < 0) || (e.ColumnIndex < 0) || (e.ColumnIndex == 1) || (((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode))
            return;
         if(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            return;

         Button btn;
         switch(e.ColumnIndex)
         {
            case 0: btn = btnURL; break;
            case 2: btn = btnUsername; break;
            case 3: btn = btnPassword; break;
            default: btn = null; break;
         }
         if((btn == null) || (btn.Visible))
            return;
         btn.Text = "";
         btn.Width = 32;
         btn.Left = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location.X
                      + ((DataGridView)sender).Columns[e.ColumnIndex].Width
                      - btn.Width - 1;
         btn.Top = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location.Y;
         btn.Height = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Height - 1;
         btn.Visible = true;
         btn.BringToFront();
      }

      private void tabGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
      {
         btnURL.Visible = false;
         btnUsername.Visible = false;
         btnPassword.Visible = false;
      }

      private void tabGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
      {
         if(e.ColumnIndex == 3 && e.Value != null)
         {
            e.Value = new String('*', e.Value.ToString().Length);
         }
      }

      private void AddRec_Click(object sender, EventArgs e)
      {
         tabGrid.Focus();
         tabGrid.CurrentCell = tabGrid.Rows[tabGrid.Rows.Add()].Cells[0];
      }

      private void DelRec_Click(object sender, EventArgs e)
      {
         if((tabGrid.Rows.Count > 0) && (!tabGrid.CurrentRow.IsNewRow))
            if(MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
               tabGrid.Rows.Remove(tabGrid.CurrentRow);
      }

      private void Grid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
      {
         MethodInvoker DeleteRow = () =>
         {
            btnURL.Visible = false;
            btnUsername.Visible = false;
            btnPassword.Visible = false;
            ((DataGridView)sender).Rows.RemoveAt(e.RowIndex);
         };

         if((((DataGridView)sender).CurrentRow != null) && ((DataGridView)sender).IsCurrentRowDirty &&
            (
                ((((DataGridView)sender).CurrentRow.Cells[0].Value == null) || (((DataGridView)sender).CurrentRow.Cells[0].Value.ToString() == ""))
             || ((((DataGridView)sender).CurrentRow.Cells[2].Value == null) || (((DataGridView)sender).CurrentRow.Cells[2].Value.ToString() == ""))
             || ((((DataGridView)sender).CurrentRow.Cells[3].Value == null) || (((DataGridView)sender).CurrentRow.Cells[3].Value.ToString() == ""))
             )
             )
         {
            if(MessageBox.Show("Fields URL, Username and Password must have values!\nDo you want to delete the current record?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
               BeginInvoke(DeleteRow);
            }
            e.Cancel = true;
         }
      }
      private void btnURL_Click(object sender, EventArgs e)
      {
         try
         {
            System.Diagnostics.Process.Start(((DataGridView)((Button)sender).Parent).CurrentCell.Value.ToString());
         }
         catch
         {
            MessageBox.Show("Ooops, something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void btnUsername_Click(object sender, EventArgs e)
      {
         Clipboard.SetText(((DataGridView)((Button)sender).Parent).CurrentCell.Value.ToString());
      }

      private void btnPassword_Click(object sender, EventArgs e)
      {
         Clipboard.SetText(((DataGridView)((Button)sender).Parent).CurrentCell.Value.ToString());
      }


   }
}

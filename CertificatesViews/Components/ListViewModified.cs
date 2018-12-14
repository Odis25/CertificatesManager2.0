using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace CertificatesViews.Components
{
    public class ListViewModified : ListView
    {
        // Объявление констант
        const int LVM_FIRST = 0x1000;
        const int LVM_GETHEADER = (LVM_FIRST + 31);

        // Объявление полей

        int index = -1;

        //Save the Handle to the Column Headers, a ListView has only child Window which is used to render Column headers  
        IntPtr headerHandle;
        //This is used use to hook into the message loop of the Column Headers
        HeaderProc headerProc;

        //Save the column indices which are hidden
        List<int> hiddenColumnIndices = new List<int>();
        //Save the width of hidden columns
        Dictionary<int, int> hiddenColumnWidths = new Dictionary<int, int>();
        //Save the Left (X-Position) of the Pipes which separate Column Headers.
        Dictionary<int, int> columnPipeLefts = new Dictionary<int, int>();        

        public ContextMenuStrip HeaderContextMenu { get; set; }

        ContextMenuStrip _itemsContextMenu;
        /// <summary>
        /// Контекстное меню, вызываемое щелчком правой кнопки мыши по элементам ListViewItem
        /// </summary>
        public ContextMenuStrip ItemsContextMenu
        {
            get
            {
                return _itemsContextMenu ?? new ContextMenuStrip();
            }
            set { _itemsContextMenu = value; }
        }

        // Конструктор класса
        public ListViewModified() : base()
        {
            BuildStripMenu();

            VisibleChanged += ListViewModified_VisibleChanged;
            MouseClick += ListViewModified_MouseClick;
            columnPipeLefts[0] = 0;
            this.DoubleBuffered = true;
        }

        private void ListViewModified_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ItemsContextMenu.Show(MousePosition);
                }
            }
        }

        private bool EnumChild(IntPtr childHwnd, object lParam)
        {
            headerHandle = childHwnd;
            return true;
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private void ListViewModified_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && headerHandle == IntPtr.Zero && !DesignMode)
            {
                IntPtr hwnd = SendMessage(this.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
                if (hwnd != null)
                {
                    headerProc = new HeaderProc(this);
                    headerHandle = hwnd;
                    headerProc.AssignHandle(hwnd);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x101e && hiddenColumnIndices.Contains(m.WParam.ToInt32()))//WM_SETCOLUMNWIDTH = 0x101e
            {
                if (m.LParam.ToInt32() > 0) hiddenColumnWidths[m.WParam.ToInt32()] = m.LParam.ToInt32();
                return;//Discard the message changing hidden column width so that it won't be shown again.                
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Look for the WM_VSCROLL or the WM_HSCROLL messages.
            if ((m.Msg == 0x115) || (m.Msg == 0x114))
            {
                // Move focus to the ListView to cause ComboBox to lose focus.
                Focus();
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            base.WndProc(ref m);
            if (m.Msg == 0x7b)
            {  //wm_contextmenu
                if (m.WParam != this.Handle)
                {
                    if (HeaderContextMenu == null)
                    {
                        HeaderContextMenu = new ContextMenuStrip();
                        BuildStripMenu();
                    }
                    HeaderContextMenu.Show(Control.MousePosition);
                }
                    
            }
        }

        protected override void OnColumnWidthChanging(ColumnWidthChangingEventArgs e)
        {
            if (hiddenColumnIndices.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
                e.NewWidth = 0;
            }
            base.OnColumnWidthChanging(e);
        }

        //We need to update columnPipeLefts whenever the width of any column changes
        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            UpdateColumnPipeLefts(Columns[e.ColumnIndex].DisplayIndex + 1);
        }

        protected override void OnColumnReordered(ColumnReorderedEventArgs e)
        {
            int i = Math.Min(e.NewDisplayIndex, e.OldDisplayIndex);
            index = index != -1 ? Math.Min(i + 1, index) : i + 1;
            base.OnColumnReordered(e);
        }

        //This is used to update the columnPipeLefts every reordering columns or resizing columns.
        private void UpdateColumnPipeLefts(int fromIndex)
        {
            int w = fromIndex > 0 ? columnPipeLefts[fromIndex - 1] : 0;
            for (int i = fromIndex; i < Columns.Count; i++)
            {
                w += i > 0 ? Columns.OfType<ColumnHeader>().Where(k => k.DisplayIndex == i - 1).Single().Width : 0;
                columnPipeLefts[i] = w;
            }
        }

        //This is used to hide a column with ColumnHeader passed in
        public void HideColumn(ColumnHeader col)
        {
            if (!hiddenColumnIndices.Contains(col.Index))
            {
                hiddenColumnWidths[col.Index] = col.Width;//Save the current width to restore later                
                col.Width = 0;//Hide the column
                hiddenColumnIndices.Add(col.Index);
            }
        }

        //This is used to hide a column with column index passed in
        public void HideColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= Columns.Count) return;
            if (!hiddenColumnIndices.Contains(columnIndex))
            {
                hiddenColumnWidths[columnIndex] = Columns[columnIndex].Width;//Save the current width to restore later                
                Columns[columnIndex].Width = 0;//Hide the column
                hiddenColumnIndices.Add(columnIndex);
            }
        }

        //This is used to show a column with ColumnHeader passed in
        public void ShowColumn(ColumnHeader col)
        {
            hiddenColumnIndices.Remove(col.Index);
            if (hiddenColumnWidths.ContainsKey(col.Index))
                col.Width = hiddenColumnWidths[col.Index];//Restore the Width to show the column
            hiddenColumnWidths.Remove(col.Index);
        }

        //This is used to show a column with column index passed in
        public void ShowColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= Columns.Count) return;
            hiddenColumnIndices.Remove(columnIndex);
            if (hiddenColumnWidths.ContainsKey(columnIndex))
                Columns[columnIndex].Width = hiddenColumnWidths[columnIndex];//Restore the Width to show the column            
            hiddenColumnWidths.Remove(columnIndex);
        }

        //The helper class allows us to hook into the message loop of the Column Headers
        private class HeaderProc : NativeWindow
        {
            [DllImport("user32")]
            private static extern int SetCursor(IntPtr hCursor);
            public HeaderProc(ListViewModified listView)
            {
                this.listView = listView;
            }
            bool mouseDown;
            ListViewModified listView;
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x200 && listView != null && !mouseDown)
                {
                    int x = (m.LParam.ToInt32() << 16) >> 16;
                    if (IsSpottedOnAnyHiddenColumnPipe(x)) return;
                }
                if (m.Msg == 0x201)
                {
                    mouseDown = true;
                    int x = (m.LParam.ToInt32() << 16) >> 16;
                    IsSpottedOnAnyHiddenColumnPipe(x);
                }
                if (m.Msg == 0x202) mouseDown = false;
                if (m.Msg == 0xf && listView.index != -1 && MouseButtons == MouseButtons.None)
                { //WM_PAINT = 0xf
                    listView.UpdateColumnPipeLefts(listView.index);
                    listView.index = -1;
                };
                base.WndProc(ref m);
            }
            private bool IsSpottedOnAnyHiddenColumnPipe(int x)
            {
                foreach (int i in listView.hiddenColumnIndices.Select(j => listView.Columns[j].DisplayIndex))
                {
                    if (x > listView.columnPipeLefts[i] - 1 && x < listView.columnPipeLefts[i] + 15)
                    {
                        SetCursor(Cursors.Arrow.Handle);
                        return true;
                    }
                }
                return false;
            }
        }

        // Создаем ToolStripMenu для скрытия/отображения заголовков ListView
        private void BuildStripMenu()
        {
            foreach (ColumnHeader column in Columns)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = column.Text;
                item.Tag = column.Index;
                item.Checked = true;
                item.Click += ToolStripMenuItem_Click;
                HeaderContextMenu.Items.Add(item);
            }
        }

        // Правый Клик на заголовках ListView
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            int num = Convert.ToInt32(item.Tag);

            if (Columns[num].Width != 0)
            {
                HideColumn(num);
                item.Checked = false;
            }
            else
            {
                ShowColumn(num);
                item.Checked = true;
            }
        }
    }

    

}

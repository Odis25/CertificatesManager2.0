using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CertificatesViews.Components
{
    public delegate void CheckBoxHeaderClickHandler(CheckBoxHeaderCellEventArgs e);

    public class CheckBoxHeaderCellEventArgs : EventArgs
    {
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
        }

        public CheckBoxHeaderCellEventArgs(bool _checked)
        {
            _isChecked = _checked;
        }
    }

    public class CheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Size checkboxsize;
        bool isChecked;
        Point location;
        Point cellboundsLocation;
        CheckBoxState state = CheckBoxState.UncheckedNormal;

        public event CheckBoxHeaderClickHandler OnCheckBoxHeaderClick;

        public CheckBoxHeaderCell()
        {
            location = new Point();
            cellboundsLocation = new Point();
            isChecked = false;
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            /* Make a condition to check whether the click is fired inside a checkbox region */
            Point clickpoint = new Point(e.X + cellboundsLocation.X, e.Y + cellboundsLocation.Y);

            if ((clickpoint.X > location.X && clickpoint.X < (location.X + checkboxsize.Width)) && (clickpoint.Y > location.Y && clickpoint.Y < (location.Y + checkboxsize.Height)))
            {
                isChecked = !isChecked;
                if (OnCheckBoxHeaderClick != null)
                {
                    OnCheckBoxHeaderClick(new CheckBoxHeaderCellEventArgs(isChecked));
                    this.DataGridView.InvalidateCell(this);
                }
            }
            base.OnMouseClick(e);
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            checkboxsize = CheckBoxRenderer.GetGlyphSize(graphics, CheckBoxState.UncheckedNormal);

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState,
            value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            location.X = cellBounds.X + (cellBounds.Width / 2 - checkboxsize.Width / 2);
            location.Y = cellBounds.Y + (cellBounds.Height / 2 - checkboxsize.Height / 2);
            cellboundsLocation = cellBounds.Location;

            //location.X = cellBounds.X + this.ContentBounds.Right + 1;
            location.Y = cellBounds.Y + (ContentBounds.Bottom + 2);

            if (isChecked)
                state = CheckBoxState.CheckedNormal;
            else
                state = CheckBoxState.UncheckedNormal;

            CheckBoxRenderer.DrawCheckBox(graphics, location, state);

        }
    }
}

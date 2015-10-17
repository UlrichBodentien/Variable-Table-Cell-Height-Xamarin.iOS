using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace VariableTableCellHeight
{
    public class VegetableTableViewSource : UITableViewSource
    {
        private List<Vegetable> vegtables;

        public VegetableTableViewSource(List<Vegetable> vegtables)
        {
            this.vegtables = vegtables;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (VegetableTableCell)tableView.DequeueReusableCell(VegetableTableCell.Identifier);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.Header = vegtables[indexPath.Row].Name;
            cell.Text = vegtables[indexPath.Row].Description;

            cell.SetNeedsUpdateConstraints();
            cell.UpdateConstraintsIfNeeded();

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return vegtables.Count;
        }
    }
}
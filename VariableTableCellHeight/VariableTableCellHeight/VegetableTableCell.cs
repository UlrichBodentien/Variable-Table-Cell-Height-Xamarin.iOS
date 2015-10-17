using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;
using Praeclarum.UI;

namespace VariableTableCellHeight
{
    public class VegetableTableCell : UITableViewCell
    {
        public const string Identifier = "Reuse";

        private bool didUpdateConstraints = false;

        private UILabel headerLabel;
        private UILabel textLabel;
        private UIView seperator;

        protected internal VegetableTableCell(IntPtr handle) : base(handle)
        {
            headerLabel = new UILabel();
            headerLabel.TextColor = UIColor.Black;
            headerLabel.Font = UIFont.SystemFontOfSize(18);

            textLabel = new UILabel();
            textLabel.TextColor = UIColor.Black;

            textLabel.Lines = 0;
            textLabel.LineBreakMode = UILineBreakMode.WordWrap;
            textLabel.Font = UIFont.SystemFontOfSize(14);

            seperator = new UIView();
            seperator.BackgroundColor = UIColor.FromRGB(211, 211, 211);

            ContentView.AddSubviews(headerLabel, textLabel, seperator);
        }

        public string Header
        {
            get { return headerLabel.Text; }
            set { headerLabel.Text = value; }
        }

        public string Text
        {
            get { return textLabel.Text; }
            set { textLabel.Text = value; }
        }

        public override void UpdateConstraints()
        {
            base.UpdateConstraints();

            headerLabel.SetContentCompressionResistancePriority(1000, UILayoutConstraintAxis.Vertical);
            textLabel.SetContentCompressionResistancePriority(1000, UILayoutConstraintAxis.Vertical);
            seperator.SetContentCompressionResistancePriority(1000, UILayoutConstraintAxis.Vertical);

            if (!didUpdateConstraints)
            {
                ContentView.ConstrainLayout(() =>

                    headerLabel.Frame.Top == ContentView.Frame.Top + 5
                    && headerLabel.Frame.Left == ContentView.Frame.Left + 8
                    && headerLabel.Frame.Right == ContentView.Frame.Right - 8

                    && textLabel.Frame.Top == headerLabel.Frame.Bottom + 8
                    && textLabel.Frame.Left == ContentView.Frame.Left + 8
                    && textLabel.Frame.Right == ContentView.Frame.Right - 8

                    && seperator.Frame.Top == textLabel.Frame.Bottom + 10
                    && seperator.Frame.Left == ContentView.Frame.Left + 8
                    && seperator.Frame.Right == ContentView.Frame.Right - 8
                    && seperator.Frame.Height == 1
                    && seperator.Frame.Bottom == ContentView.Frame.Bottom - 5);

                didUpdateConstraints = true;
            }
        }
    }
}

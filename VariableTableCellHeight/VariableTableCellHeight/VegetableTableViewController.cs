using System;
using System.Collections.Generic;
using UIKit;
using Praeclarum.UI;

namespace VariableTableCellHeight
{
    public class VegetableTableViewController : UIViewController
    {
        private UITableView tableView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Vegatables";
            View.BackgroundColor = UIColor.White;

            InitializeTableView();
            SetupLayoutConstraints();
        }

        private void InitializeTableView()
        {
            tableView = new UITableView();
            tableView.RegisterClassForCellReuse(typeof(VegetableTableCell), VegetableTableCell.Identifier);
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            tableView.RowHeight = UITableView.AutomaticDimension;
            tableView.EstimatedRowHeight = 50;
            var vegtables = LoadVegatables();
            tableView.Source = new VegetableTableViewSource(vegtables);
            View.AddSubview(tableView);
        }

        private void SetupLayoutConstraints()
        {
            View.ConstrainLayout(() =>

                tableView.Frame.Top == View.Frame.Top
                && tableView.Frame.Left == View.Frame.Left
                && tableView.Frame.Right == View.Frame.Right
                && tableView.Frame.Bottom == View.Frame.Bottom);
        }

        private List<Vegetable> LoadVegatables()
        {
            return new List<Vegetable>()
            {
                new Vegetable() {Name = "Tomato", Description = "The tomato (see pronunciation) is the edible, often red berry-type fruit of the nightshade Solanum lycopersicum, commonly known as a tomato plant. The tomato is consumed in diverse ways, including raw, as an ingredient in many dishes, sauces, salads, and drinks." },

                new Vegetable() {Name = "Carrot", Description = "The carrot (Daucus carota subsp. sativus) is a root vegetable, usually orange in colour, though purple, red, white, and yellow varieties exist. It has a crisp texture when fresh. The most commonly eaten part of a carrot is a taproot, although the greens are sometimes eaten as well. It is a domesticated form of the wild carrot Daucus carota, native to Europe and southwestern Asia. The domestic carrot has been selectively bred for its greatly enlarged and more palatable, less woody - textured edible taproot.The Food and Agriculture Organization of the United Nations(FAO) reports that world production of carrots and turnips(these plants are combined by the FAO for reporting purposes) for calendar year 2011 was almost 35.658 million tonnes.Almost half were grown in China.Carrots are widely used in many cuisines, especially in the preparation of salads, and carrot salads are a tradition in many regional cuisines." },

                new Vegetable() {Name = "Broccoli", Description = "Broccoli is an edible green plant in the cabbage family whose large flowerhead is eaten as a vegetable." },
            };
        }
    }
}
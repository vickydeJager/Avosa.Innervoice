using System.Collections.Generic;

namespace Avosa.Innervoice.Data
{
    public class LineItem : BaseRecord
    {
        public LineItem()
        {
            Items = new List<SubItem>();
        }

        public LineItem(string description, decimal unitCost, int quatity)
        {
            Description = description;

            UnitCost = unitCost;

            Quantity = quatity;
        }

        public string Description { get; set; }

        public decimal UnitCost { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost
        {
            get
            {
                return Quantity * UnitCost;
            }
        }

        public List<SubItem> Items { get; set; }
    }
}

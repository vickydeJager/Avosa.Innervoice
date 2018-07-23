namespace Avosa.Innervoice.Data
{
    public class Product : BaseRecord
    {
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Name, this.UnitPrice);
        }
    }
}

namespace Avosa.Innervoice.Data
{
    public class Contact : BaseRecord
    {
        public ContactType ContactType { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.ContactType, this.Value);
        }
    }
}

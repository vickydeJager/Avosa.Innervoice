using System.Collections.Generic;

namespace Avosa.Innervoice.Data
{
    public class Client : BaseRecord
    {
        public Client()
        {
            ContactDetails = new ContactDetails();
            Quotes = new List<Quote>();
        }

        public string Name { get; set; }

        public Address Address { get; set; }

        public ContactDetails ContactDetails { get; set; }

        public List<Quote> Quotes { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Name, this.ContactDetails.GetCellphone());
        }
    }
}

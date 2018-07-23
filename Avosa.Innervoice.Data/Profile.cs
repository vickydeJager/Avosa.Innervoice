using System;
using System.Collections.Generic;

namespace Avosa.Innervoice.Data
{
    public class Profile : BaseRecord
    {
        public Profile()
        {
            ContactDetails = new List<Contact>();
            Clients = new List<Client>();
            Products = new List<Product>();
        }

        public string Name { get; set; }

        public string RegistrationNo { get; set; }

        public Address Address { get; set; }

        public List<Contact> ContactDetails { get; set; }

        public Guid LogoID { get; set; }

        public List<Client> Clients { get; set; }

        public List<Product> Products { get; set; }
  
    }
}

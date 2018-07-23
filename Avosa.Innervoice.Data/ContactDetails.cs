using System.Collections.Generic;

namespace Avosa.Innervoice.Data
{
    public class ContactDetails : List<Contact>
    {
        public string GetCellphone()
        {
            return GetContactValue(ContactType.Cellphone);
        }

        public string GetTelephone()
        {
            return GetContactValue(ContactType.Telephone);
        }

        public string GetEmail()
        {
            return GetContactValue(ContactType.Email);
        }

        private string GetContactValue(ContactType contactType)
        {
            var result = string.Empty;

            foreach (var item in this)
            {
                if (item.ContactType == contactType)
                {
                    result = item.Value;
                    break;
                }
            }

            return result;
        }
    }
}

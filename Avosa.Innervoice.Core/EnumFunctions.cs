using Avosa.Innervoice.Data;
using System.Collections.Generic;

namespace Avosa.Innervoice.Core
{
    public static class EnumFunctions
    {
        public static ComboBoxSource<AddressType, string> GetAddressTypes()
        {
            var result = new ComboBoxSource<AddressType, string>();

            result.AddMember(AddressType.Physical, AddressType.Physical.ToString());
            result.AddMember(AddressType.Postal, AddressType.Postal.ToString());

            return result;
        }

        public static ComboBoxSource<ContactType, string> GetContactTypes()
        {
            var result = new ComboBoxSource<ContactType, string>();

            result.AddMember(ContactType.Cellphone, ContactType.Cellphone.ToString());
            result.AddMember(ContactType.Telephone, ContactType.Telephone.ToString());
            result.AddMember(ContactType.Email, ContactType.Email.ToString());

            return result;
        }

    }
}

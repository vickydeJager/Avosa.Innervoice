using Avosa.Innervoice.Core;
using Avosa.Innervoice.Data;
using System;
using System.Windows.Forms;

namespace Avosa.Innervoice.UI
{
    public partial class CreateClient : Form
    {
        private readonly IManageProfile _manageProfile;

        public CreateClient(IManageProfile manageProfile)
        {
            _manageProfile = manageProfile;

            InitializeComponent();

            Client = new Client();
        }

        public Client Client { get; set; }

        private void CreateClient_Load(object sender, EventArgs e)
        {
            PopulateTypes();
        }

        private void PopulateTypes()
        {
            cboType.DataSource = EnumFunctions.GetAddressTypes();
            cboType.ValueMember = "Key";
            cboType.DisplayMember = "Value";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addContact = IoC.Resolve<ContactDetails>();

            if (addContact.ShowDialog() == DialogResult.OK)
            {
                Client.ContactDetails.Add(addContact.Contact);

                lstContactDetails.Items.Add((Client.ContactDetails.Count - 1).ToString(), addContact.Contact.ToString(), 0);
            }
        }

        private Address GetAddress()
        {
            var address = new Address();

            address.StreetNo = txtStreetNo.Text;
            address.Street = txtStreet.Text;
            address.UnitNo = txtUnitNo.Text;
            address.EstateName = txtEstateName.Text;
            address.Suburb = txtSuburb.Text;
            address.City = txtCity.Text;
            address.Province = txtProvince.Text;
            address.PostalCode = txtPostalCode.Text;
            address.Coordinates = txtCoordinates.Text;
            address.Type = (AddressType)cboType.SelectedValue;

            return address;
        }

        public void Save()
        {
            Client.Name = txtName.Text;
            Client.Address = GetAddress();

            var confirmer = _manageProfile.AddClient(Client);

            if (!confirmer.Success)
                MessageBox.Show(confirmer.Error);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();

            DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}

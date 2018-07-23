using Avosa.Innervoice.Core;
using Avosa.Innervoice.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Avosa.Innervoice.UI
{
    public partial class CreateProfile : Form
    {
        private readonly IManageProfile _manageProfile;
        private readonly Profile _profile;
        private string lastLogo;

        public CreateProfile(IManageProfile manageProfile)
        {
            _manageProfile = manageProfile;
            _profile = new Profile();

            InitializeComponent();
        }

        private void CreateProfile_Load(object sender, EventArgs e)
        {
            PopulateTypes();
        }

        private void PopulateTypes()
        {
            cboType.DataSource = EnumFunctions.GetAddressTypes();
            cboType.ValueMember = "Key";
            cboType.DisplayMember = "Value";
        }

        public void Save()
        {
            _profile.Name = txtCompanyName.Text;
            _profile.RegistrationNo = txtRegNo.Text;
            _profile.Address = GetAddress();
            _profile.LogoID = SaveImage();

            _manageProfile.Create(_profile);
        }

        private Guid SaveImage()
        {
            var imageID = Guid.NewGuid();
            var imagePath = string.Format("./{0}.{1}", imageID.ToString(), lastLogo);

            picLogo.BackgroundImage.Save(imagePath);

            return imageID;
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

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var addContact = IoC.Resolve<ContactDetails>();

            if (addContact.ShowDialog() == DialogResult.OK)
            {
                _profile.ContactDetails.Add(addContact.Contact);
                var item = string.Format("{0}: {1}", addContact.Contact.ContactType, addContact.Contact.Value);
                lstContactDetails.Items.Add((_profile.ContactDetails.Count - 1).ToString(), item, 0);
            }
        }

        private void btnSelectLogo_Click(object sender, System.EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var filenameParts = fileDialog.FileName.Split('.');
                lastLogo = filenameParts[filenameParts.Length - 1];

                picLogo.BackgroundImage = Image.FromFile(fileDialog.FileName);
            }
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

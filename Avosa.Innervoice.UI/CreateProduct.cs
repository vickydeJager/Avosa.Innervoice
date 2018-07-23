using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avosa.Innervoice.Core;
using Avosa.Innervoice.Data;

namespace Avosa.Innervoice.UI
{
    public partial class CreateProduct : Form
    {
        private readonly IManageProfile _manageProfile;

        public CreateProduct(IManageProfile manageProfile)
        {
            _manageProfile = manageProfile;
    
            InitializeComponent();

            Product = new Product();
        }

        public Product Product { get; set; }

        public void Save()
        {
            Product.Name = txtProductDescription.Text;
            Product.UnitPrice = nudUnitPrice.Value;
            Product.IsActive = chkIsActive.Checked;

            var confirmer = _manageProfile.AddProduct(Product);

            if (!confirmer.Success)
                MessageBox.Show(confirmer.Error);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();

            DialogResult = DialogResult.OK;

            this.Close();
            /*Product = new Product
            {
                ProductName = txtProductDescription.Text,
                ProductPrice = nudUnitPrice.Value,
                IsActive = chkIsActive.Checked
            };

            DialogResult = DialogResult.OK;

            this.Close();*/
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

using Avosa.Innervoice.Core;
using Avosa.Innervoice.Data;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace Avosa.Innervoice.UI
{
    public partial class Products : Form
    {
        private readonly IManageProfile _manageProfile;

        public Products(IManageProfile manageProfile)
        {
            InitializeComponent();

            _manageProfile = manageProfile;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            PopulateProductList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var createProduct = IoC.Resolve<CreateProduct>();
            createProduct.ShowDialog();
            PopulateProductList();
        }

        public void PopulateProductList()
        {
            lstProducts.Clear();
            var products = _manageProfile.GetProducts();

            for (var i = 0; i < products.Count; i++)
            {
                var product = products[i];

                lstProducts.Items.Add(product.ID.ToString(), product.ToString(), 0);
            }
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            var productID = GetProductID(list.SelectedItems);

            _manageProfile.SetActiveProduct(productID);
        }

        private Guid GetProductID(SelectedListViewItemCollection items)
        {
            var result = Guid.Empty;

            foreach (ListViewItem item in items)
            {
                result = Guid.Parse(item.Name);
                break;
            }

            return result;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}

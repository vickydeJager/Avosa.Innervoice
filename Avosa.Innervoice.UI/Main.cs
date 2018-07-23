using Avosa.Innervoice.Core;
using System.Windows.Forms;

namespace Avosa.Innervoice.UI
{
    public partial class Main : Form
    {
        private readonly IManageProfile _manageProfile;

        public Main(IManageProfile manageProfile)
        {
            InitializeComponent();

            _manageProfile = manageProfile;
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            if (!_manageProfile.HasProfile())
            {
                var createProfile = IoC.Resolve<CreateProfile>();
            }

            lblProfileName.Text = _manageProfile.GetName();
        }

        private void clientsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var clients = IoC.Resolve<Clients>();
            clients.ShowDialog();
        }

        private void productsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var products = IoC.Resolve<Products>();
            products.ShowDialog();
        }
    }
}

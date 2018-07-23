using Avosa.Innervoice.Core;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace Avosa.Innervoice.UI
{
    public partial class Clients : Form
    {
        private readonly IManageProfile _manageProfile;

        public Clients(IManageProfile manageProfile)
        {
            InitializeComponent();

            _manageProfile = manageProfile;
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            PopulatClientList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var createClient = IoC.Resolve<CreateClient>();
            createClient.ShowDialog();
            PopulatClientList();
        }

        public void PopulatClientList()
        {
            lstClients.Clear();
            var clients = _manageProfile.GetClients();

            for (var i = 0; i < clients.Count; i++)
            {
                var client = clients[i];

                lstClients.Items.Add(client.ID.ToString(), client.ToString(), 0);
            }
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            var clientID = GetClientID(list.SelectedItems);

            grpOptions.Visible = true;

            _manageProfile.SetActiveClient(clientID);
        }

        private Guid GetClientID(SelectedListViewItemCollection items)
        {
            var result = Guid.Empty;

            foreach (ListViewItem item in items)
            {
                result = Guid.Parse(item.Name);
                break;
            }

            return result;
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            var createQuote = IoC.Resolve<CreateQuote>();
            createQuote.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

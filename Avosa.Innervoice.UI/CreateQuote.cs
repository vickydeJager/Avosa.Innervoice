using Avosa.Innervoice.Core;
using Avosa.Innervoice.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Avosa.Innervoice.UI
{
    public partial class CreateQuote : Form
    {
        private readonly IManageProfile _manageProfile;

        public CreateQuote(IManageProfile manageProfile, IQuotes quotes)
        {
            _manageProfile = manageProfile;

            InitializeComponent();
        }

        private void PopulateGrid()
        {
            SetupColumns();

            foreach (var item in _manageProfile.GetActiveQuote().LineItems)
            {
                dgvLineItems.Rows.Add(item);
            }
        }

        public void SetupColumns()
        {
            dgvLineItems.DataError += dgvLineItems_DataError;

            var colID = CreateColumn("colID", "ID", false, typeof(Guid), false);
            dgvLineItems.Columns.Add(colID);

            var colQty = CreateColumn("colQty", "Qty", typeof(int));
            dgvLineItems.Columns.Add(colQty);

            var colDescription = CreateComboBoxColumn("colDescription", "Description", GetDescriptionData());
            dgvLineItems.Columns.Add(colDescription);

            var colUnitPrice = CreateColumn("colUnitPrice", "Unit Price", typeof(decimal));
            dgvLineItems.Columns.Add(colUnitPrice);

            var colTotal = CreateColumn("colTotal", "Total", true, typeof(decimal), true);
            dgvLineItems.Columns.Add(colTotal);
        }

        private void dgvLineItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var message = e.Exception.ToString();
        }

        public ComboBoxSource<Guid, string> GetDescriptionData()
        {
            var result = new ComboBoxSource<Guid, string>();
            result.AddMember(Guid.Empty, "Select");

            foreach (var item in _manageProfile.GetProducts())
            {
                result.AddMember(item.ID, item.Name);
            }

            return result;
        }

        private DataGridViewColumn CreateColumn(string name, string headerText, Type type)
        {
            return CreateColumn(name, headerText, true, type, false);
        }

        private DataGridViewColumn CreateColumn(string name, string headerText, bool visible, Type type, bool readOnly)
        {
            var txtcol = new DataGridViewTextBoxColumn();
            txtcol.Name = name;
            txtcol.HeaderText = headerText;
            txtcol.Visible = visible;
            txtcol.ValueType = type;
            txtcol.ReadOnly = readOnly;

            return txtcol;
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumn(string name, string headerText, ComboBoxSource<Guid, string> data)
        {
            var cmbColumn = new DataGridViewComboBoxColumn();

            cmbColumn.DefaultCellStyle.NullValue = "Select";
            cmbColumn.Name = name;
            cmbColumn.HeaderText = headerText;
            cmbColumn.DataSource = data;
            //cmbColumn.MaxDropDownItems = 10;
            cmbColumn.DisplayMember = "Value";
            cmbColumn.ValueMember = "Key";

            return cmbColumn;
        }


        private void CreateQuote_Load(object sender, EventArgs e)
        {
            _manageProfile.SetActiveQuote(new Quote());


            PopulateGrid();
        }

        private void dgvLineItems_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var row = dgvLineItems.Rows[rowIndex];
            var lineItem = GetLineItem(row);

            _manageProfile.GetActiveQuote().LineItems.Add(lineItem);
        }

        private LineItem GetLineItem(DataGridViewRow row)
        {
            var result = new LineItem();

            var colDescription = row.Cells["colDescription"].FormattedValue.ToString();
            //var colDescription = row.Cells["colDescription"].Selected.ToString();
            var colUnitPrice = row.Cells["colUnitPrice"].Value;
            var colQty = row.Cells["colQty"].Value;

            if (colDescription != null && colUnitPrice != null && colQty != null)
            {
                var description = colDescription.ToString();
                var unitPrice = decimal.Parse(colUnitPrice.ToString());
                var qty = int.Parse(colQty.ToString());

                result = new LineItem(description, unitPrice, qty);
                row.Cells["colTotal"].Value = result.TotalCost;
            }

            return result;
        }

        private List<LineItem> GetLineItems()
        {
            var result = new List<LineItem>();

            foreach (DataGridViewRow item in dgvLineItems.Rows)
            {
                result.Add(GetLineItem(item));
            }

            return result;
        }

        private void dgvLineItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvLineItems.CurrentCell.ColumnIndex == 2 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;

            if (sendingCB.SelectedItem != null)
            {
                var selectedItem = (KeyValuePair<Guid, string>)sendingCB.SelectedItem;

                var product = _manageProfile.GetProductByID(selectedItem.Key);

                var unitPriceCol = dgvLineItems.CurrentRow.Cells["colUnitPrice"];

                if (product != null)
                {
                    unitPriceCol.Value = product.UnitPrice;
                }
                else
                {
                    unitPriceCol.Value = 0;
                }
            }
        }

        public void Save()
        {
            var lineItems = GetLineItems();

            _manageProfile.AddClientQuote(dtpDueDate.Value, lineItems);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}

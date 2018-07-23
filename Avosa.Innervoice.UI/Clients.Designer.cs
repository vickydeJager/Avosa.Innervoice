namespace Avosa.Innervoice.UI
{
    partial class Clients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstClients = new System.Windows.Forms.ListView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnQuote = new System.Windows.Forms.Button();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstClients
            // 
            this.lstClients.Location = new System.Drawing.Point(23, 21);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(267, 459);
            this.lstClients.TabIndex = 0;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.List;
            this.lstClients.SelectedIndexChanged += new System.EventHandler(this.lstClients_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(519, 505);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(617, 505);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnQuote
            // 
            this.btnQuote.Location = new System.Drawing.Point(216, 19);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Size = new System.Drawing.Size(75, 23);
            this.btnQuote.TabIndex = 3;
            this.btnQuote.Text = "Quote";
            this.btnQuote.UseVisualStyleBackColor = true;
            this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.btnQuote);
            this.grpOptions.Location = new System.Drawing.Point(380, 21);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(309, 254);
            this.grpOptions.TabIndex = 4;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "groupBox1";
            this.grpOptions.Visible = false;
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 540);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstClients);
            this.Name = "Clients";
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.Clients_Load);
            this.grpOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstClients;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnQuote;
        private System.Windows.Forms.GroupBox grpOptions;
    }
}
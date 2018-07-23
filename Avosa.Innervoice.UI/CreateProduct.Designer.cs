namespace Avosa.Innervoice.UI
{
    partial class CreateProduct
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
            this.nudUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // nudUnitPrice
            // 
            this.nudUnitPrice.DecimalPlaces = 2;
            this.nudUnitPrice.Location = new System.Drawing.Point(259, 12);
            this.nudUnitPrice.Name = "nudUnitPrice";
            this.nudUnitPrice.Size = new System.Drawing.Size(120, 20);
            this.nudUnitPrice.TabIndex = 41;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(312, 50);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(67, 17);
            this.chkIsActive.TabIndex = 39;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(304, 83);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 38;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Location = new System.Drawing.Point(12, 12);
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(220, 20);
            this.txtProductDescription.TabIndex = 37;
            // 
            // CreateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 133);
            this.Controls.Add(this.nudUnitPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtProductDescription);
            this.Name = "CreateProduct";
            this.Text = "CreateProduct";
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudUnitPrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtProductDescription;
    }
}
namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class InvoiceView
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
            txtInvoiceType = new MaterialSkin.Controls.MaterialComboBox();
            btnPrint = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // txtInvoiceType
            // 
            txtInvoiceType.AutoResize = false;
            txtInvoiceType.BackColor = Color.FromArgb(255, 255, 255);
            txtInvoiceType.Depth = 0;
            txtInvoiceType.DrawMode = DrawMode.OwnerDrawVariable;
            txtInvoiceType.DropDownHeight = 174;
            txtInvoiceType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtInvoiceType.DropDownWidth = 121;
            txtInvoiceType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtInvoiceType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtInvoiceType.FormattingEnabled = true;
            txtInvoiceType.Hint = "Select Invoice Type";
            txtInvoiceType.IntegralHeight = false;
            txtInvoiceType.ItemHeight = 43;
            txtInvoiceType.Location = new Point(132, 81);
            txtInvoiceType.Margin = new Padding(4, 5, 4, 5);
            txtInvoiceType.MaxDropDownItems = 4;
            txtInvoiceType.MouseState = MaterialSkin.MouseState.OUT;
            txtInvoiceType.Name = "txtInvoiceType";
            txtInvoiceType.Size = new Size(421, 49);
            txtInvoiceType.StartIndex = 0;
            txtInvoiceType.TabIndex = 0;
            // 
            // btnPrint
            // 
            btnPrint.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPrint.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnPrint.Depth = 0;
            btnPrint.HighEmphasis = true;
            btnPrint.Icon = null;
            btnPrint.Location = new Point(306, 158);
            btnPrint.Margin = new Padding(6, 10, 6, 10);
            btnPrint.MouseState = MaterialSkin.MouseState.HOVER;
            btnPrint.Name = "btnPrint";
            btnPrint.NoAccentTextColor = Color.Empty;
            btnPrint.Size = new Size(64, 36);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "PRINT";
            btnPrint.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnPrint.UseAccentColor = false;
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // InvoiceView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673, 271);
            Controls.Add(btnPrint);
            Controls.Add(txtInvoiceType);
            Margin = new Padding(4, 5, 4, 5);
            Name = "InvoiceView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Generate Invoice";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox txtInvoiceType;
        private MaterialSkin.Controls.MaterialButton btnPrint;
    }
}
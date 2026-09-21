namespace OrderDesk;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        lblEmail = new Label();
        txtCustomerEmail = new TextBox();
        lblDiscount = new Label();
        cmbDiscountType = new ComboBox();
        dgvItems = new DataGridView();
        Product = new DataGridViewTextBoxColumn();
        Price = new DataGridViewTextBoxColumn();
        Qty = new DataGridViewTextBoxColumn();
        btnCalculate = new Button();
        btnSaveOrder = new Button();
        btnEmailInvoice = new Button();
        btnPrint = new Button();
        lblTotal = new Label();
        ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
        SuspendLayout();
        //
        // lblEmail
        //
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(20, 24);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(110, 20);
        lblEmail.TabIndex = 0;
        lblEmail.Text = "Customer Email:";
        //
        // txtCustomerEmail
        //
        txtCustomerEmail.Location = new Point(145, 21);
        txtCustomerEmail.Name = "txtCustomerEmail";
        txtCustomerEmail.Size = new Size(320, 27);
        txtCustomerEmail.TabIndex = 1;
        //
        // lblDiscount
        //
        lblDiscount.AutoSize = true;
        lblDiscount.Location = new Point(495, 24);
        lblDiscount.Name = "lblDiscount";
        lblDiscount.Size = new Size(70, 20);
        lblDiscount.TabIndex = 2;
        lblDiscount.Text = "Discount:";
        //
        // cmbDiscountType
        //
        // Part 2 (OCP): the items are NOT hard-coded here any more.
        // Form1_Load fills them from DiscountStrategyFactory.
        cmbDiscountType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDiscountType.Location = new Point(571, 21);
        cmbDiscountType.Name = "cmbDiscountType";
        cmbDiscountType.Size = new Size(180, 28);
        cmbDiscountType.TabIndex = 3;
        //
        // dgvItems
        //
        dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvItems.BackgroundColor = SystemColors.Window;
        dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvItems.Columns.AddRange(new DataGridViewColumn[] { Product, Price, Qty });
        dgvItems.Location = new Point(20, 64);
        dgvItems.Name = "dgvItems";
        dgvItems.RowHeadersWidth = 51;
        dgvItems.Size = new Size(731, 250);
        dgvItems.TabIndex = 4;
        //
        // Product
        //
        Product.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        Product.HeaderText = "Product";
        Product.MinimumWidth = 200;
        Product.Name = "Product";
        //
        // Price
        //
        Price.HeaderText = "Price";
        Price.MinimumWidth = 6;
        Price.Name = "Price";
        Price.Width = 140;
        //
        // Qty
        //
        Qty.HeaderText = "Qty";
        Qty.MinimumWidth = 6;
        Qty.Name = "Qty";
        Qty.Width = 100;
        //
        // btnCalculate
        //
        btnCalculate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnCalculate.Location = new Point(20, 328);
        btnCalculate.Name = "btnCalculate";
        btnCalculate.Size = new Size(140, 38);
        btnCalculate.TabIndex = 5;
        btnCalculate.Text = "Calculate";
        btnCalculate.UseVisualStyleBackColor = true;
        btnCalculate.Click += btnCalculate_Click;
        //
        // btnSaveOrder
        //
        btnSaveOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnSaveOrder.Location = new Point(170, 328);
        btnSaveOrder.Name = "btnSaveOrder";
        btnSaveOrder.Size = new Size(140, 38);
        btnSaveOrder.TabIndex = 6;
        btnSaveOrder.Text = "Save Order";
        btnSaveOrder.UseVisualStyleBackColor = true;
        btnSaveOrder.Click += btnSaveOrder_Click;
        //
        // btnEmailInvoice
        //
        btnEmailInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnEmailInvoice.Location = new Point(320, 328);
        btnEmailInvoice.Name = "btnEmailInvoice";
        btnEmailInvoice.Size = new Size(150, 38);
        btnEmailInvoice.TabIndex = 7;
        btnEmailInvoice.Text = "Email Invoice";
        btnEmailInvoice.UseVisualStyleBackColor = true;
        btnEmailInvoice.Click += btnEmailInvoice_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnPrint.Location = new Point(480, 328);
        btnPrint.Name = "btnPrint";
        btnPrint.Size = new Size(120, 38);
        btnPrint.TabIndex = 8;
        btnPrint.Text = "Print";
        btnPrint.UseVisualStyleBackColor = true;
        btnPrint.Click += btnPrint_Click;
        //
        // lblTotal
        //
        lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblTotal.AutoSize = true;
        lblTotal.Location = new Point(20, 382);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(54, 20);
        lblTotal.TabIndex = 9;
        lblTotal.Text = "Total:";
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(771, 421);
        Controls.Add(lblTotal);
        Controls.Add(btnPrint);
        Controls.Add(btnEmailInvoice);
        Controls.Add(btnSaveOrder);
        Controls.Add(btnCalculate);
        Controls.Add(dgvItems);
        Controls.Add(cmbDiscountType);
        Controls.Add(lblDiscount);
        Controls.Add(txtCustomerEmail);
        Controls.Add(lblEmail);
        MinimumSize = new Size(700, 420);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Order Desk";
        ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblEmail;
    private TextBox txtCustomerEmail;
    private Label lblDiscount;
    private ComboBox cmbDiscountType;
    private DataGridView dgvItems;
    private DataGridViewTextBoxColumn Product;
    private DataGridViewTextBoxColumn Price;
    private DataGridViewTextBoxColumn Qty;
    private Button btnCalculate;
    private Button btnSaveOrder;
    private Button btnEmailInvoice;
    private Button btnPrint;
    private Label lblTotal;
}

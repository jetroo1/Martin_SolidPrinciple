using OrderDesk.Discounts;
using OrderDesk.Invoicing;
using OrderDesk.Models;
using OrderDesk.Persistence;
using OrderDesk.Services;

namespace OrderDesk;

public partial class Form1 : Form
{
    private readonly IOrderCalculator calculator;
    private readonly IDiscountStrategyFactory discountFactory;
    private readonly IOrderRepository repository;
    private readonly IInvoiceSender invoiceSender;
    private readonly IInvoicePrinter invoicePrinter;

    // Part 5 (DIP): five interfaces, zero concrete services.
    // This form cannot reach a database or a mail server even if it
    // wanted to - it does not know their types.
    public Form1(
        IOrderCalculator calculator,
        IDiscountStrategyFactory discountFactory,
        IOrderRepository repository,
        IInvoiceSender invoiceSender,
        IInvoicePrinter invoicePrinter)
    {
        this.calculator = calculator;
        this.discountFactory = discountFactory;
        this.repository = repository;
        this.invoiceSender = invoiceSender;
        this.invoicePrinter = invoicePrinter;

        InitializeComponent();
        Load += Form1_Load;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        cmbDiscountType.Items.Clear();
        foreach (string name in discountFactory.AvailableNames())
        {
            cmbDiscountType.Items.Add(name);
        }

        cmbDiscountType.SelectedIndex = 0;
    }

    // -------------------------------------------------------------- Buttons

    private void btnCalculate_Click(object sender, EventArgs e)
    {
        lblTotal.Text = BuildOrder().Total.ToString("C");
    }

    private void btnSaveOrder_Click(object sender, EventArgs e)
    {
        repository.Save(BuildOrder());
        MessageBox.Show("Saved!");
    }

    private void btnEmailInvoice_Click(object sender, EventArgs e)
    {
        invoiceSender.Send(BuildOrder());
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        invoicePrinter.Print(BuildOrder());
    }

    // -------------------------------------------------------------- Helpers

    private List<OrderItem> ReadItems()
    {
        List<OrderItem> items = new List<OrderItem>();

        foreach (DataGridViewRow row in dgvItems.Rows)
        {
            if (row.Cells["Price"].Value == null) continue;

            items.Add(new OrderItem
            {
                Product = Convert.ToString(row.Cells["Product"].Value),
                Price = Convert.ToDecimal(row.Cells["Price"].Value),
                Qty = Convert.ToInt32(row.Cells["Qty"].Value)
            });
        }

        return items;
    }

    private Order BuildOrder()
    {
        string name = cmbDiscountType.SelectedItem?.ToString() ?? "None";
        IDiscountStrategy discount = discountFactory.Create(name);
        List<OrderItem> items = ReadItems();

        return new Order
        {
            CustomerEmail = txtCustomerEmail.Text.Trim(),
            Items = items,
            DiscountName = discount.Name,
            Total = calculator.Calculate(items, discount)
        };
    }
}

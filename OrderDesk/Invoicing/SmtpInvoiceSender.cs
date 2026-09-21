using System.Net.Mail;
using OrderDesk.Models;

namespace OrderDesk.Invoicing;

// The SMTP that used to sit inside btnEmailInvoice_Click.
public class SmtpInvoiceSender : IInvoiceSender
{
    private readonly string host;
    private readonly string fromAddress;

    public SmtpInvoiceSender(string host, string fromAddress)
    {
        this.host = host;
        this.fromAddress = fromAddress;
    }

    public void Send(Order order)
    {
        using (SmtpClient smtp = new SmtpClient(host))
        using (MailMessage mail = new MailMessage(fromAddress, order.CustomerEmail))
        {
            mail.Body = $"Your total is {order.Total:C}";
            smtp.Send(mail);
        }
    }
}

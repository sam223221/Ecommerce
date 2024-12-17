using System.Threading.Tasks;

namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}

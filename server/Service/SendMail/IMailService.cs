using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Services
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailData mailData, CancellationToken ct);
    }
}
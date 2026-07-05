namespace GiveAID.Services.Abstractions;

public interface IEmailService
{
    public Task<bool> SendEmailAsync(string receiverEmail, string subject, string body, CancellationToken ct = default);
}
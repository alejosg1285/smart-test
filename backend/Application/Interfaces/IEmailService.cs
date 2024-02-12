namespace Application;

public interface IEmailService
{
    Task Send(EmailMetadata emailMetadata);
}

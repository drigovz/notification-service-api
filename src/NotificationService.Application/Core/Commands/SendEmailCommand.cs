using MediatR;

namespace NotificationService.Application.Core.Commands
{
    public class SendEmailCommand: IRequest<GenericResponse>
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Attach { get; set; }
    }
}

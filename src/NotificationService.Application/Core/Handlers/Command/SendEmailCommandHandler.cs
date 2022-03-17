using FluentEmail.Core;
using MediatR;
using NotificationService.Application.Core.Commands;
using NotificationService.Application.Notifications;

namespace NotificationService.Application.Core.Handlers.Command
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, GenericResponse>
    {
        private readonly IMediator _mediator;
        private readonly NotificationContext _notification;
        private readonly IFluentEmail _fluentEmail;

        public SendEmailCommandHandler(IMediator mediator, NotificationContext notification, IFluentEmail fluentEmail)
        {
            _mediator = mediator;
            _notification = notification;
            _fluentEmail = fluentEmail;
        }

        public async Task<GenericResponse> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var email = _fluentEmail.To(request.To)
                        .Subject(request.Subject)
                        .Body(request.TemplateBody);

            if (!string.IsNullOrWhiteSpace(request.Cc))
                email.CC(request.Cc);

            if (!string.IsNullOrWhiteSpace(request.Bcc))
                email.BCC(request.Bcc);

            //if (!string.IsNullOrWhiteSpace(request.Attach))
            //    email.Attach(request.Attach);

            var emailResult = await email.SendAsync();

            return new GenericResponse
            {
                Result = null,
            };
        }
    }
}

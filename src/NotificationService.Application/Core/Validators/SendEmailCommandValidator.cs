﻿using FluentValidation;
using NotificationService.Application.Core.Commands;

namespace NotificationService.Application.Core.Validators
{
    public class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
    {
        public SendEmailCommandValidator()
        {
            RuleFor(x => x.To).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.Subject).NotNull().NotEmpty();
            RuleFor(x => x.TemplateBody).NotNull().NotEmpty();
        }
    }
}
using FluentValidation;
using News.Application.DTOs;

public class NewsDTOValidator : AbstractValidator<NewsDTO>
{
    public NewsDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");

        RuleFor(x => x.CreatedDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date cannot be in the future.");

        RuleFor(x => x.Image)
            .Must(images => images == null || images.All(file => file.ContentType.StartsWith("image/")))
            .WithMessage("All uploaded files must be images.");

        RuleFor(x => x.Translation1Title)
            .NotEmpty().WithMessage("Translation for Language1Title is required.")
            .MaximumLength(100).WithMessage("Translation1Title cannot exceed 100 characters.");

        RuleFor(x => x.Translation1Content)
            .NotEmpty().WithMessage("Translation for Language1Content is required.");

        RuleFor(x => x.Translation2Title)
            .MaximumLength(100).WithMessage("Translation2Title cannot exceed 100 characters.");

        RuleFor(x => x.Translation2Content)
            .MaximumLength(500).WithMessage("Translation2Content cannot exceed 500 characters.");
    }
}

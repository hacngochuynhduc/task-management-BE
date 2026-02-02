using FluentValidation;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Commands;

namespace STEAMHOUSE.Dashboard.TaskServices.Task_Management.Validator;

public class CreateTaskListValidator : AbstractValidator<CreateTaskList>
{
    public CreateTaskListValidator()
    {

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Tiêu đề không được để trống")
            .MinimumLength(3).WithMessage("Tiêu đề phải từ 3 ký tự trở lên");
        
        RuleFor(x => x.Status)
            .NotNull().WithMessage("Trạng thái là bắt buộc");
    }
}
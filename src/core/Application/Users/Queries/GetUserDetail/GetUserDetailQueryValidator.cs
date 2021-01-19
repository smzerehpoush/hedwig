using FluentValidation;

namespace Application.Users.Queries.GetUser
{
    public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>
    {
        public GetUserDetailQueryValidator()
        {
            RuleFor(u => u.UserId).NotNull();
        }
    }
}
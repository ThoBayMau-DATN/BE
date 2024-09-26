using Microsoft.AspNetCore.Identity;

namespace BACK_END.Data
{
    public class CustomIdentityErrorDescriber: IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = $"Mật khẩu phải có ít nhất {length} ký tự."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "Mật khẩu phải chứa ký tự đặc biệt."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = "Mật khẩu phải chứa ít nhất một chữ số."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "Mật khẩu phải chứa ít nhất một chữ thường."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "Mật khẩu phải chứa ít nhất một chữ hoa."
            };
        }
    }
}

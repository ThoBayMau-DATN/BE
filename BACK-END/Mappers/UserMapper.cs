using BACK_END.DTOs.UserDto;
using BACK_END.Models;
using MimeKit;
using System.Net.Mail;
using System.Text;


namespace BACK_END.Mappers
{
    public static class UserMapper
	{
		public static string RandomNewPassword()
		{
			Random random = new Random();

			int randomValue = random.Next(1000);

			return "Password@" + randomValue.ToString("D3");
		}

		public static bool SenderEmail(string content, string email)
		{
			using (MailMessage emailMessage = new MailMessage())
			{
				MailAddress emailFrom = new MailAddress("dunghtpk02825@fpt.edu.vn", "dunghtpk02825@fpt.edu.vn");

				emailMessage.From = emailFrom;

				emailMessage.To.Add(new MailAddress(email));

				emailMessage.IsBodyHtml = true;

				emailMessage.Subject = "Thông tin tài khoản";

				BodyBuilder emailBodyBuilder = new BodyBuilder();

				emailMessage.Body = content;


				using (var mailClient = new MailKit.Net.Smtp.SmtpClient())
				{
					mailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

					mailClient.Authenticate("dunghtpk02825@fpt.edu.vn", "htbi cobu egyo orik");

					mailClient.Send((MimeMessage)emailMessage);

					mailClient.Disconnect(true);
				}
			}

			return true;
		}

		public static string GenerateRandomNumericString(int length)
		{
			const string digits = "0123456789";
			StringBuilder result = new StringBuilder(length);
			Random random = new Random();

			for (int i = 0; i < length; i++)
			{
				int index = random.Next(digits.Length);
				result.Append(digits[index]);
			}

			return result.ToString();
		}

		public static GetAllUserRepositoryDto MapToGetAllUserRepository(this User model)
		{
			var User = new GetAllUserRepositoryDto
			{
				Id = model.Id,
				FullName = model.FullName,
				Phone = model.Phone,
				Email = model.Email,
				Avatar = model.Avatar,
				TimeCreated = model.CreateDate,
				Status = model.Status

			};
			return User;

		}
    }
}

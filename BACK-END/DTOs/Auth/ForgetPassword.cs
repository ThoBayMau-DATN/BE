namespace BACK_END.DTOs.Auth
{
    public class ForgetPassword
	{
		public string PhoneNumber {  get; set; } = string.Empty;

	}

	public class ChangePassWord
	{
		public string Password { get; set; } = string.Empty;

		public string ConfimPassWord { get; set; } = string.Empty;
	}
}

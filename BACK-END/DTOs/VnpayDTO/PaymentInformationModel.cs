namespace BACK_END.Repositories.VnpayDTO
{
    public class PaymentInformationModel
    {
        public string OrderId { get; set; }
        public double Amount { get; set; }
        public string? ReturnUrl { get; set; }
    }
}

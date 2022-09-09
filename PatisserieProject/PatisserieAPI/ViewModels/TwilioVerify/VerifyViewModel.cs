namespace PatisserieAPI.ViewModels
{   
    public record VerifyViewModel
    {
        public string VerificationCode { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}

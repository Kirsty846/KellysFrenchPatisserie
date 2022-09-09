namespace PatisserieAPI.Options
{
    public sealed record TwilioOptions
    {
        public string AccountSid { get; set; } = null!;
        public string AuthenticationToken { get; set; } = null!;
        public string VerificationSid { get; set; } = null!;
    }
}

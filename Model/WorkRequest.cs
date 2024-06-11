namespace MetallFactorUI.Model
{
    public class WorkRequest
    {
        public int Id { get; set; }
        public string? SelectedCategory { get; set; }
        public string? SelectedBudgetRange { get; set; }
        public int Quantity { get; set; }
        public string? ExampleData { get; set; }
        public string? SelectedPaymentMethod { get; set; }
        public string? SelectedMaterialSource { get; set; }
        public string? SelectedDeliveryOption { get; set; }
        public DateTime DeliveryDeadline { get; set; }
        public bool PenaltyAgreement { get; set; }
        public bool BonusAgreement { get; set; }
        public bool ArbitrationAgreement { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingState { get; set; }
    }
}

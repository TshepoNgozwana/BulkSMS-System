namespace AA.BulkSMS.Core.Data.ViewModels
{
    public class SaveContactVM
    {
        public int? Id { get; set; }
        public string EmailAddress { get; set; }
        public string CellphoneNumber { get; set; }
        public string? AlternativeCellNumber { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public string LastName { get; set; }
        public bool? CellphoneConfirmed { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string AddedBy { get; set; }
    }
}

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public class ColleagueViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }
        public bool IsRemoved { get; set; }
        public string CreatingDate {  get; set; }
    }
}

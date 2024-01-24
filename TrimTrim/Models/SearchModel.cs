namespace TrimTrim.Models
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }
    public class SearchModel
    {
        public string SearchTerm { get; set; }
        public double? MinPrice { get; set; }

        public SortOrder? SortOrder { get; set; }
    }
}

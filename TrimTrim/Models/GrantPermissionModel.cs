namespace TrimTrim.Models
{
    public class UserPermissionRequest
    {
        public string Id { get; set; }
        public string Name { get; set; } // Add other properties as needed
    }
    public class GrantPermissionModel
    {
        public List<UserPermissionRequest> Users { get; set; }
        public int ProductId { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace TodoList.Api.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}

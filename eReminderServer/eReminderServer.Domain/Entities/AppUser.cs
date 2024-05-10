using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eReminderServer.Domain.Entities
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public string FirstName {  get; set; }=string.Empty;
        public string LastName {  get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName + LastName);
    }
}

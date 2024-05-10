using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eReminderServer.Domain.Entities
{
    public sealed class Gardener
    {
        public Gardener()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }  
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName =>string.Join(" ", FirstName, LastName);
        public string Mail { get; set; } = string.Empty;

    }
}

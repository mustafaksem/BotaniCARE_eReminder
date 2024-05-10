using eReminderServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eReminderServer.Application.Services
{
    public interface IJwtProvider
    {
        string CreateToken(AppUser user);
    }
}

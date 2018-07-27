using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoMeAFavor.Models;

namespace DoMeAFavor.Services
{
    public interface IUserMissionService
    {
        Task UpdateAsync(Mission mission);
        Task AddAsync(Mission mission);
    }
}

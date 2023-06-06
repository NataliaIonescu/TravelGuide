using TravelGuide.Models;
using TravelGuide.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelGuide.Repositories
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(TravelContext context) : base(context) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;

namespace TsBlog.Services
{
    public interface IUserService : IService<User>
    {
        User FindByLoginName(string loginName);
    }
}

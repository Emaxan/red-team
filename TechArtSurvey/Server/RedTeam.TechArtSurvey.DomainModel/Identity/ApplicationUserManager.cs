using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.DomainModel.Identity
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
                : base(store)
        {
        }
    }
}

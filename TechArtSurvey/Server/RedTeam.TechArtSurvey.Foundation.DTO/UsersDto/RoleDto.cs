using System;
using JetBrains.Annotations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.Foundation.Dto.UsersDto
{
    [UsedImplicitly]
    public class RoleDto
    {
        private string _roleType;


        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty( _roleType) || !Enum.IsDefined(typeof(RoleTypes), _roleType))
                {
                    return default(RoleTypes).ToString();
                }
                return _roleType;
            }
            set { _roleType = value; }
        }
    }
}

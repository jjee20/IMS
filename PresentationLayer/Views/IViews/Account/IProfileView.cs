using DomainLayer.Enums;
using System.Xml.Linq;

namespace PresentationLayer.Views.IViews.Account
{
    public interface IProfileView
    {
        string AppUserName { set ; }
        string UserName { set ; }
        string Email { set; }
        string Phone { set; }
        string Department { set; }
        public void GetTaskRoles(List<TaskRoles> taskRoles);

        event EventHandler ShowEditProfile;
        event EventHandler ShowChangePassword;
    }
}
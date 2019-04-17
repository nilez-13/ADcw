using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentManagementCourseWork.Startup))]
namespace StudentManagementCourseWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

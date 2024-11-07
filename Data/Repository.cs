using GraphQLApiDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApiDemo.Data
{
    public class Repository
    {
        private readonly UserDbContext context;
        public Repository(UserDbContext context)
        {
            this.context = context;
        }
        public  List<UserDetailsModel> GetAllUser()=>
             context.DemoUserDetails.ToList();
        public UserDetailsModel GetUserByEmpcode(string EmpCode) =>
             context.DemoUserDetails.Where(u =>u.EmpCode == EmpCode).FirstOrDefault();

        public UserDetailsModel LogIn(UserDetailsModel user)
        {
            return context.DemoUserDetails
                          .FirstOrDefault(u => u.EmpCode == user.EmpCode && u.FirstName == user.FirstName);
        }

        public UserDetailsModel AddUser(UserDetailsModel User)
        {
            context.DemoUserDetails.Add(User);
             context.SaveChanges();
            return User;
        }
        public UserDetailsModel UpdateUser(UserDetailsModel User, string EmpCode)
        {
            var us =  GetUserByEmpcode(EmpCode);
            us.FirstName = User.FirstName;
            us.LastName = User.LastName;
            us.Address = User.Address;

             context.SaveChanges();
            return us;
        }

        public void DeleteUser(string EmpCode)
        {
            var us =  GetUserByEmpcode(EmpCode);

            context.DemoUserDetails.Remove(us);
            context.SaveChanges();
        }
    }
}

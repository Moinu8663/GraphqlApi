using GraphQLApiDemo.Model;

namespace GraphQLApiDemo.Data
{
    public class UserDetailsRepository
    {
        private readonly MoinuContext context;
        public UserDetailsRepository(MoinuContext context)
        {
            this.context = context;
        }
        public List<UserDetail> GetAll() =>
             context.UserDetails.ToList();
        public UserDetail GetByEmpcode(string EmpCode) =>
             context.UserDetails.Where(u => u.EmpCode == EmpCode).FirstOrDefault();



        public UserDetail Add(UserDetail User)
        {
            context.UserDetails.Add(User);
            context.SaveChanges();
            return User;
        }
        public UserDetail Update(UserDetail User, string EmpCode)
        {
            var us = GetByEmpcode(EmpCode);
            us.FirstName = User.FirstName;
            us.LastName = User.LastName;
            us.Address = User.Address;

            context.SaveChanges();
            return us;
        }

        public void Delete(string EmpCode)
        {
            var us = GetByEmpcode(EmpCode);

            context.UserDetails.Remove(us);
            context.SaveChanges();
        }
    }
}

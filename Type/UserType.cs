using GraphQL.Types;
using GraphQLApiDemo.Model;

namespace GraphQLApiDemo.Type
{
    public class UserType: ObjectGraphType<UserDetailsModel>
    {
        public UserType()
        {
            Field(x => x.EmpCode).Description("The Employee Code of the user");
            Field(x => x.FirstName).Description("The first name of the user");
            Field(x => x.LastName).Description("The last name of the user");
            Field(x => x.Address).Description("The address of the user");
        }
    }
}

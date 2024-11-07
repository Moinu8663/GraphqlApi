using GraphQL.Types;
using GraphQLApiDemo.Model;

namespace GraphQLApiDemo.Type
{
    public class UserInputType: InputObjectGraphType<UserDetailsModel>
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field(x => x.EmpCode).Description("Employee Code of the user");
            Field(x => x.FirstName).Description("First name of the user");
            Field(x => x.LastName).Description("Last name of the user");
            Field(x => x.Address).Description("Address of the user");
        }
    }
}

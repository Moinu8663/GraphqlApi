using GraphQL;
using GraphQL.Types;
using GraphQLApiDemo.Data;
using GraphQLApiDemo.UserDetails.Type;

namespace GraphQLApiDemo.UserDetails
{
    public class UserDetailsQuery : ObjectGraphType
    {
        public UserDetailsQuery(UserDetailsRepository urepo)
        {
            Field<ListGraphType<UserDetailsType>>("UsersDetails").Resolve(context => urepo.GetAll());

            Field<UserDetailsType>("UserDeatail").Arguments(new QueryArguments(new QueryArgument<StringGraphType> { Name = "empCode" }))
                .Resolve(context =>
                {
                    var empCode = context.GetArgument<string>("empCode");
                    return urepo.GetByEmpcode(empCode);
                });
        }
    }
}

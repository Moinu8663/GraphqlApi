using GraphQL;
using GraphQL.Types;
using GraphQLApiDemo.Data;
using GraphQLApiDemo.Type;

namespace GraphQLApiDemo.GraphQL
{
    public class UserQuery: ObjectGraphType
    {

        public UserQuery(Repository repo)
        {
            Field<ListGraphType<UserType>>("users")
                .Resolve(context => repo.GetAllUser());

            Field<UserType>("user")
                .Arguments(new QueryArguments(new QueryArgument<StringGraphType> { Name = "empCode" }))
                .Resolve(context =>
                {
                    var empCode = context.GetArgument<string>("empCode");
                    return repo.GetUserByEmpcode(empCode);
                });
        }
    }
}

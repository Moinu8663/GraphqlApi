using GraphQL;
using GraphQL.Types;
using GraphQLApiDemo.Data;
using GraphQLApiDemo.Model;
using GraphQLApiDemo.Token;
using GraphQLApiDemo.Type;

namespace GraphQLApiDemo.GraphQL
{
    public class UserMutation: ObjectGraphType
    {
        public UserMutation(Repository repo, ITokenGenerator tokenGenerator)
        {
            Field<AuthPayloadType>("LogIn")
                .Arguments(new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "empCode" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "firstName" }
                ))
                .Resolve(context =>
                {
                    var empCode = context.GetArgument<string>("empCode");
                    var firstName = context.GetArgument<string>("firstName");

                    // Fetch user details from the repository
                    var user = repo.LogIn(new UserDetailsModel { EmpCode = empCode, FirstName = firstName });

                    if (user == null)
                    {
                        context.Errors.Add(new ExecutionError("Invalid employee code or first name"));
                        return null;
                    }

                    // Generate JWT token
                    var token = tokenGenerator.GenerateToken(user);

                    // Return both the token and the employee code
                    return new
                    {
                        token,
                        empCode = user.EmpCode
                    };
                });

            Field<UserType>("addUser")
                .Arguments(new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ))
                .Resolve(context =>
                {
                    var user = context.GetArgument<UserDetailsModel>("user");
                    return repo.AddUser(user);
                });

            Field<UserType>("updateUser")
                .Arguments(new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "empCode" }
                ))
                .Resolve(context =>
                {
                    var user = context.GetArgument<UserDetailsModel>("user");
                    var empCode = context.GetArgument<string>("empCode");
                    return repo.UpdateUser(user, empCode);
                });

            Field<StringGraphType>("deleteUser")
                .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "empCode" }))
                .Resolve(context =>
                {
                    var empCode = context.GetArgument<string>("empCode");
                    repo.DeleteUser(empCode);
                    return $"User with EmpCode {empCode} was deleted.";
                });
        }
    }

}

using GraphQL.Types;
using GraphQLApiDemo.GraphQL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GraphQLApiDemo.UserDetails
{
    public class UserDetailsSchema : Schema
    {
        public UserDetailsSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<UserDetailsQuery>();
            //Mutation = provider.GetRequiredService<UserDetailsMutation>();
        }
    }
}

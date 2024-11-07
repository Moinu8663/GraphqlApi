using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
namespace GraphQLApiDemo.GraphQL
{
    public class AppSchema:Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<UserQuery>();
            Mutation = provider.GetRequiredService<UserMutation>();
        }
    }

}

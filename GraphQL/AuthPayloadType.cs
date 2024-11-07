using GraphQL.Types;

namespace GraphQLApiDemo.GraphQL
{
    public class AuthPayloadType:ObjectGraphType
    {
        public AuthPayloadType()
        {
            Field<StringGraphType>("token", description: "JWT token");
            Field<StringGraphType>("empCode", description: "User employee code");
        }
    }
}

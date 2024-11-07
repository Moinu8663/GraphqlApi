using GraphQL.Types;
using GraphQLApiDemo.Model;

namespace GraphQLApiDemo.UserDetails.Type
{
    public class UserDetailsInputType : InputObjectGraphType<UserDetail>
    {
        public UserDetailsInputType()
        {
            Name = "UserDetailsInput";
            Field(e => e.EmpCode).Description("The Employee Code of the user");
            Field(e => e.FirstName).Description("The first name of the user");
            Field(e => e.LastName).Description("The last name of the user");
            Field(e => e.Company).Description("The Company of the user");
            Field(e => e.CompanyAddress).Description("The CompanyAddress of the user");
            Field(e => e.CompanyImage).Description("The CompanyImage of the user");
            Field(e => e.Department).Description("The Department of the user");
            Field(e => e.Dob).Description("The Dob of the user");
            Field(e => e.EmailId).Description("The EmailId of the user");
            Field(e => e.Grade).Description("The Grade of the user");
            Field(e => e.JobTitle).Description("The JobTitle of the user");
            Field(e => e.Address).Description("The address of the user");
            Field(e => e.MobileNo).Description("The MobileNo of the user");
        }
    }
}

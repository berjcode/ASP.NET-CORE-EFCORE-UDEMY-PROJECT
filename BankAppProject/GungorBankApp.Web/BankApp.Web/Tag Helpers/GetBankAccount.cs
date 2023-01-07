using BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BankApp.Web.Tag_Helpers
{
    [HtmlTargetElement("getBankAccount")]
    public class GetBankAccount : TagHelper
    {
        public int UserID { get; set; }
        private readonly BankContext _context;

        public GetBankAccount(BankContext context)
        {
            _context = context;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x=> x.UserID == UserID);
            var html = $"<span class='badge bg-success'> {accountCount} </span>";
            output.Content.SetHtmlContent(html);
        }
    }
}

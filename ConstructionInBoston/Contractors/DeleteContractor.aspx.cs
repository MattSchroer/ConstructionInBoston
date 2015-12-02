using System;
using System.Linq;
using System.Web;

namespace ConstructionInBoston.Contractors
{
    public partial class DeleteContractor : System.Web.UI.Page
    {
        protected string Id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = string.Empty;
            var queryStrings = Request.QueryString.GetValues("id");
            if (queryStrings != null && queryStrings.Length > 0)
            {
                id = HttpUtility.UrlDecode(queryStrings.First());
            }

            if (!string.IsNullOrEmpty(id))
            {
                Id = id;
                this.AreYouSure.Text = "Are you sure you want to delete the contractor: " + Id + "?";
            }
        }

        protected void CancelButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(string.Concat("/Contractors/ContractorDetail.aspx?id=", HttpUtility.UrlEncode(Id)), true);
        }

        protected void DeleteButton_OnClick(object sender, EventArgs e)
        {

            var result = DatabaseConnections.DeleteContractor(Id);
            if (result)
            {
                Response.Redirect("/Contractors/", true);
            }

            this.ErrorMessage.Text = "There was an issue deleting this contractor. Please try again later.";

        }
    }
}
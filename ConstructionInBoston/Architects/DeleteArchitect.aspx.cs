using System;
using System.Linq;
using System.Web;

namespace ConstructionInBoston.Architects
{
    public partial class DeleteArchitect : System.Web.UI.Page
    {
        protected static string Id = string.Empty;

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
                this.AreYouSure.Text = "Are you sure you want to delete the architect: " + Id + "?";
            }
        }

        protected void CancelButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(string.Concat("/Architects/ArchitectDetail.aspx?id=", HttpUtility.UrlEncode(Id)), true);
        }

        protected void DeleteButton_OnClick(object sender, EventArgs e)
        {

            var result = DatabaseConnections.DeleteArchitect(Id);
            if (result)
            {
                Response.Redirect("/Architects/", true);
            }

            this.ErrorMessage.Text = "There was an issue deleting this architect. Please try again later.";

        }
    }
}
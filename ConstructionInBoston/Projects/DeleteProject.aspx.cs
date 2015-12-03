using System;
using System.Linq;
using System.Web;

namespace ConstructionInBoston.Projects
{
    public partial class DeleteProject : System.Web.UI.Page
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
                this.AreYouSure.Text = "Are you sure you want to delete the project: " + Id + "?";
            }
        }

        protected void CancelButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(string.Concat("/Projects/ProjectDetail.aspx?id=", HttpUtility.UrlEncode(Id)), true);
        }

        protected void DeleteButton_OnClick(object sender, EventArgs e)
        {

            var result = DatabaseConnections.DeleteProject(Id);
            if (result)
            {
                Response.Redirect("/Projects/", true);
            }

            this.ErrorMessage.Text = "There was an issue deleteing this project. Please try again later.";

        }
    }
}
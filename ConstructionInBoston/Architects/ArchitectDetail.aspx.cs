using System;
using System.Linq;
using System.Web;

namespace ConstructionInBoston.Architects
{
    public partial class ArchitectDetail : System.Web.UI.Page
    {
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
                LoadArchitect(id);
                this.UpdateLink.NavigateUrl = "./UpdateArchitect.aspx?id=" + HttpUtility.UrlEncode(id);
                this.DeleteLink.NavigateUrl = "./DeleteArchitect.aspx?id=" + HttpUtility.UrlEncode(id);
            }
        }

        protected void LoadArchitect(string id)
        {
            var list = DatabaseConnections.GetArchitects(id);
            if (list.Any())
            {
                var arch = list.First();
                this.ArchitectName.Text = arch.Name;
                this.AddressLabel.Text = arch.Address;
                this.YearLabel.Text = arch.YearEstablished.ToString();
                this.ArchitectImage.ImageUrl = !string.IsNullOrEmpty(arch.ImagePath)
                    ? arch.ImagePath
                    : "/images/logo.png";
            }
        }
    }
}
using System;
using System.Linq;
using System.Web;

namespace ConstructionInBoston.Developers
{
    public partial class DeveloperDetail : System.Web.UI.Page
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
                LoadDeveloper(id);
                this.UpdateLink.NavigateUrl = "./UpdateDeveloper.aspx?id=" + HttpUtility.UrlEncode(id);
                this.DeleteLink.NavigateUrl = "./DeleteDeveloper.aspx?id=" + HttpUtility.UrlEncode(id);
            }
        }

        protected void LoadDeveloper(string id)
        {
            var list = DatabaseConnections.GetDevelopers(id);
            if (list.Any())
            {
                var dev = list.First();
                this.DeveloperName.Text = dev.Name;
                this.AddressLabel.Text = dev.Address;
                this.YearLabel.Text = dev.YearEstablished.ToString();
                this.DeveloperImage.ImageUrl = !string.IsNullOrEmpty(dev.ImagePath)
                    ? dev.ImagePath
                    : "/images/logo.png";
            }
        }
    }
}
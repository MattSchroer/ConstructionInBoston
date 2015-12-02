using System;
using System.Web;
using System.Web.UI.WebControls;
using ConstructionInBoston.Models;

namespace ConstructionInBoston.Developers
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var developers = DatabaseConnections.GetDevelopers(string.Empty);
            this.DeveloperList.DataSource = developers;
            this.DeveloperList.DataBind();
        }

        protected void DeveloperList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var developer = e.Item.DataItem as Developer;
            if (developer == null)
            {
                return;
            }

            var header = (Literal) e.Item.FindControl("DeveloperHeader");
            if (header != null)
            {
                header.Text = developer.Name;
            }

            var description = (Literal)e.Item.FindControl("DeveloperDescription");
            if (description != null)
            {
                description.Text = "Est: " + developer.YearEstablished;
            }

            var image = (Image)e.Item.FindControl("DeveloperImage");
            if (image != null)
            {
                if (!string.IsNullOrEmpty(developer.ImagePath))
                {
                    image.ImageUrl = developer.ImagePath;
                }
                else
                {
                    image.ImageUrl = "/images/logo.png";
                }
            }

            var link = (HyperLink)e.Item.FindControl("DeveloperLink");
            if (link != null)
            {
                link.NavigateUrl = "./DeveloperDetail.aspx?id=" + HttpUtility.UrlEncode(developer.Name);
            }
        }
    }
}
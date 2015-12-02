using System;
using System.Web;
using System.Web.UI.WebControls;
using ConstructionInBoston.Models;

namespace ConstructionInBoston.Architects
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var architects = DatabaseConnections.GetArchitects(string.Empty);
            this.ArchitectsList.DataSource = architects;
            this.ArchitectsList.DataBind();
        }

        protected void ArchitectList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var architect = e.Item.DataItem as Architect;
            if (architect == null)
            {
                return;
            }

            var header = (Literal) e.Item.FindControl("ArchitectHeader");
            if (header != null)
            {
                header.Text = architect.Name;
            }

            var description = (Literal)e.Item.FindControl("ArchitectDescription");
            if (description != null)
            {
                description.Text = "Est: " + architect.YearEstablished;
            }

            var image = (Image)e.Item.FindControl("ArchitectImage");
            if (image != null)
            {
                if (!string.IsNullOrEmpty(architect.ImagePath))
                {
                    image.ImageUrl = architect.ImagePath;
                }
                else
                {
                    image.ImageUrl = "/images/logo.png";
                }
            }

            var link = (HyperLink)e.Item.FindControl("ArchitectLink");
            if (link != null)
            {
                link.NavigateUrl = "./ArchitectDetail.aspx?id=" + HttpUtility.UrlEncode(architect.Name);
            }
        }
    }
}
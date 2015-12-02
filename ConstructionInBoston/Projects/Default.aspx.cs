using System;
using System.Web;
using System.Web.UI.WebControls;
using ConstructionInBoston.Models;

namespace ConstructionInBoston.Projects
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var projects = DatabaseConnections.GetProjects(string.Empty);
            this.ProjectList.DataSource = projects;
            this.ProjectList.DataBind();
        }

        protected void ProjectList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var project = e.Item.DataItem as Project;
            if (project == null)
            {
                return;
            }

            var header = (Literal) e.Item.FindControl("ProjectHeader");
            if (header != null)
            {
                header.Text = project.Name;
            }

            var description = (Literal)e.Item.FindControl("ProjectDescription");
            if (description != null)
            {
                description.Text = project.Neighborhood + ": " + project.Status;
            }

            var image = (Image)e.Item.FindControl("ProjectImage");
            if (image != null)
            {
                if (!string.IsNullOrEmpty(project.ImagePath))
                {
                    image.ImageUrl = project.ImagePath;
                }
                else
                {
                    image.ImageUrl = "/images/building.jpg";
                }
            }

            var link = (HyperLink)e.Item.FindControl("ProjectLink");
            if (link != null)
            {
                link.NavigateUrl = "./ProjectDetail.aspx?id=" + HttpUtility.UrlEncode(project.Name);
            }
        }
    }
}
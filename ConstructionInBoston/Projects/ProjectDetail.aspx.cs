using System;
using System.Linq;
using System.Web;

namespace ConstructionInBoston.Projects
{
    public partial class ProjectDetail : System.Web.UI.Page
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
                LoadProject(id);
                this.UpdateLink.NavigateUrl = "./UpdateProject.aspx?id=" + HttpUtility.UrlEncode(id);
                this.DeleteLink.NavigateUrl = "./DeleteProject.aspx?id=" + HttpUtility.UrlEncode(id);
            }
        }

        protected void LoadProject(string id)
        {
            var list = DatabaseConnections.GetProjects(id);
            if (list.Any())
            {
                var proj = list.First();
                this.ProjectName.Text = proj.Name;
                this.AddressLabel.Text = proj.Address;
                this.FloorsLabel.Text = proj.Floors.ToString();
                this.FootageLabel.Text = proj.SquareFootage.ToString();
                this.PermitLabel.Text = proj.PermitNumber;
                this.NeighborhoodLabel.Text = proj.Neighborhood;

                if (!string.IsNullOrEmpty(proj.Architect))
                {
                    this.ArchitectLink.Text = proj.Architect;
                    this.ArchitectLink.NavigateUrl = string.Concat("/Architects/ArchitectDetail.aspx?id=",
                        HttpUtility.UrlEncode(proj.Architect));
                }

                if (!string.IsNullOrEmpty(proj.Developer))
                {
                    this.DeveloperLink.Text = proj.Developer;
                    this.DeveloperLink.NavigateUrl = string.Concat("/Developers/DeveloperDetail.aspx?id=",
                        HttpUtility.UrlEncode(proj.Developer));
                }

                if (!string.IsNullOrEmpty(proj.Contractor))
                {
                    this.ContractorLink.Text = proj.Contractor;
                    this.ContractorLink.NavigateUrl = string.Concat("/Contractors/ContractorDetail.aspx?id=",
                        HttpUtility.UrlEncode(proj.Contractor));
                }

                this.StatusLabel.Text = proj.Status;
                this.ProjectImage.ImageUrl = !string.IsNullOrEmpty(proj.ImagePath)
                    ? proj.ImagePath
                    : "/images/building.jpg";
            }
        }
    }
}
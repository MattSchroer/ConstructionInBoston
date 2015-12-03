using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ConstructionInBoston.Models;

namespace ConstructionInBoston.Projects
{
    public partial class UpdateProject : System.Web.UI.Page
    {
        protected static string Id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ClearFields();
                BindCombos();

                var id = string.Empty;
                var queryStrings = Request.QueryString.GetValues("id");
                if (queryStrings != null && queryStrings.Length > 0)
                {
                    id = HttpUtility.UrlDecode(queryStrings.First());
                }

                if (!string.IsNullOrEmpty(id))
                {
                    Id = id;
                    LoadProject(id);
                }
            }
        }

        protected void LoadProject(string id)
        {
            var list = DatabaseConnections.GetProjects(id);
            if (list.Any())
            {
                var proj = list.First();
                this.NameBox.Text = proj.Name;
                this.AddressBox.Text = proj.Address;
                this.FloorBox.Text = proj.Floors.ToString();
                this.FootageBox.Text = proj.SquareFootage.ToString();
                this.PermitBox.Text = proj.PermitNumber;
                this.NeighborhoodBox.Text = proj.Neighborhood;

                this.ArchitectCombo.SelectedValue = proj.Architect;
                this.DeveloperCombo.SelectedValue = proj.Developer;
                this.ContractorCombo.SelectedValue = proj.Contractor;
                this.StatusCombo.SelectedValue = proj.Status;

            }
        }

        protected void BindCombos()
        {
            var contList = new ListItemCollection { new ListItem("--Select a contractor--", string.Empty) };
            var contractors = DatabaseConnections.GetContractors(string.Empty);
            foreach (var contractor in contractors)
            {
                contList.Add(new ListItem(contractor.Name));
            }

            this.ContractorCombo.DataSource = contList;
            this.ContractorCombo.DataBind();

            var archList = new ListItemCollection { new ListItem("--Select an architect--", string.Empty) };
            var architects = DatabaseConnections.GetArchitects(string.Empty);
            foreach (var architect in architects)
            {
                archList.Add(new ListItem(architect.Name));
            }

            this.ArchitectCombo.DataSource = archList;
            this.ArchitectCombo.DataBind();

            var devList = new ListItemCollection { new ListItem("--Select a developer--", string.Empty) };
            var developers = DatabaseConnections.GetDevelopers(string.Empty);
            foreach (var developer in developers)
            {
                devList.Add(new ListItem(developer.Name));
            }

            this.DeveloperCombo.DataSource = devList;
            this.DeveloperCombo.DataBind();

            var statusList = new ListItemCollection
            {
                new ListItem("--Select a status--", string.Empty),
                new ListItem("Proposed", "Proposed"),
                new ListItem("Approved", "Approved"),
                new ListItem("Under Construction", "Under Construction"),
                new ListItem("Completed", "Completed"),
                new ListItem("Stale", "Stale"),
            };

            this.StatusCombo.DataSource = statusList;
            this.StatusCombo.DataBind();
        }

        protected void ClearFields()
        {

        }

        protected void CancelButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(string.Concat("/Projects/ProjectDetail.aspx?id=", HttpUtility.UrlEncode(Id)), true);
        }

        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameBox.Text))
            {
                return;
            }

            int floors;
            int footage;

            if (!int.TryParse(this.FloorBox.Text, out floors))
            {
                floors = 0;
            }

            if (!int.TryParse(this.FootageBox.Text, out footage))
            {
                footage = 0;
            }

            var submitted = new Project
            {
                Name = this.NameBox.Text,
                Address = this.AddressBox.Text,
                Floors = floors,
                SquareFootage = footage,
                PermitNumber = this.PermitBox.Text,
                Neighborhood = this.NeighborhoodBox.Text,
                Architect = this.ArchitectCombo.SelectedIndex != 0 ? this.ArchitectCombo.SelectedValue : string.Empty,
                Developer = this.DeveloperCombo.SelectedIndex != 0 ? this.DeveloperCombo.SelectedValue : string.Empty,
                Contractor = this.ContractorCombo.SelectedIndex != 0 ? this.ContractorCombo.SelectedValue : string.Empty,
                Status = this.StatusCombo.SelectedIndex != 0 ? this.StatusCombo.SelectedValue : "Proposed",
                ImagePath = string.Empty
            };

            bool result = DatabaseConnections.UpdateProject(submitted);

            if (result)
            {
                Response.Redirect(string.Concat("/Projects/ProjectDetail.aspx?id=", HttpUtility.UrlEncode(Id)), true);
            }

            this.ErrorMessage.Text = "There was an error with your submission.";
        }
    }
}
using System;
using System.Linq;
using System.Web;
using ConstructionInBoston.Models;

namespace ConstructionInBoston.Contractors
{
    public partial class UpdateContractor : System.Web.UI.Page
    {
        protected string Id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ClearFields();

                var id = string.Empty;
                var queryStrings = Request.QueryString.GetValues("id");
                if (queryStrings != null && queryStrings.Length > 0)
                {
                    id = HttpUtility.UrlDecode(queryStrings.First());
                }

                if (!string.IsNullOrEmpty(id))
                {
                    Id = id;
                    LoadContractor(id);
                }
            }
        }

        protected void LoadContractor(string id)
        {
            var list = DatabaseConnections.GetContractors(id);
            if (list.Any())
            {
                var cont = list.First();
                this.NameBox.Text = cont.Name;
                this.AddressBox.Text = cont.Address;
                this.YearBox.Text = cont.YearEstablished.ToString();
            }
        }

        protected void ClearFields()
        {

        }

        protected void CancelButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(string.Concat("/Contractors/ContractorDetail.aspx?id=", HttpUtility.UrlEncode(Id)), true);
        }

        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameBox.Text))
            {
                return;
            }

            int years;

            if (!int.TryParse(this.YearBox.Text, out years))
            {
                years = 0;
            }

            var submitted = new Contractor
            {
                Name = this.NameBox.Text,
                Address = this.AddressBox.Text,
                YearEstablished = years,
                ImagePath = string.Empty
            };

            bool result = DatabaseConnections.UpdateContractor(submitted);

            if (result)
            {
                Response.Redirect(string.Concat("/Contractors/ContractorDetail.aspx?id=", HttpUtility.UrlEncode(Id)), true);
            }

            this.ErrorMessage.Text = "There was an error with your submission.";
        }
    }
}
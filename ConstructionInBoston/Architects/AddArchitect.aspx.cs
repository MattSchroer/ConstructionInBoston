using System;
using ConstructionInBoston.Models;

namespace ConstructionInBoston.Architects
{
    public partial class AddArchitect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ClearFields();
            }
        }

        protected void ClearFields()
        {
            this.NameBox.Text = string.Empty;
            this.AddressBox.Text = string.Empty;
            this.YearBox.Text = string.Empty;
        }

        protected void CancelButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Architects/", true);
        }

        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameBox.Text))
            {
                return;
            }

            int year;

            if (!int.TryParse(this.YearBox.Text, out year))
            {
                year = 2015;
            }

            var submitted = new Architect
            {
                Name = this.NameBox.Text,
                Address = this.AddressBox.Text,
                YearEstablished = year,
                ImagePath = string.Empty
            };

            bool result = DatabaseConnections.AddArchitect(submitted);

            if (result)
            {
                Response.Redirect("/Architects/", true);
            }

            this.ErrorMessage.Text = "There was an error with your submission.";
        }
    }
}
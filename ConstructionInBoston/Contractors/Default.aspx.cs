using System;
using System.Web;
using System.Web.UI.WebControls;
using ConstructionInBoston.Models;

namespace ConstructionInBoston.Contractors
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var contractors = DatabaseConnections.GetContractors(string.Empty);
            this.ContractorsList.DataSource = contractors;
            this.ContractorsList.DataBind();
        }

        protected void ContractorList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var contractor = e.Item.DataItem as Contractor;
            if (contractor == null)
            {
                return;
            }

            var header = (Literal) e.Item.FindControl("ContractorHeader");
            if (header != null)
            {
                header.Text = contractor.Name;
            }

            var description = (Literal)e.Item.FindControl("ContractorDescription");
            if (description != null)
            {
                description.Text = "Est: " + contractor.YearEstablished;
            }

            var image = (Image)e.Item.FindControl("ContractorImage");
            if (image != null)
            {
                if (!string.IsNullOrEmpty(contractor.ImagePath))
                {
                    image.ImageUrl = contractor.ImagePath;
                }
                else
                {
                    image.ImageUrl = "/images/logo.png";
                }
            }

            var link = (HyperLink)e.Item.FindControl("ContractorLink");
            if (link != null)
            {
                link.NavigateUrl = "./ContractorDetail.aspx?id=" + HttpUtility.UrlEncode(contractor.Name);
            }
        }
    }
}
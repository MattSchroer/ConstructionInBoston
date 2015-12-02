using System;
using System.Linq;
using System.Web;

namespace ConstructionInBoston.Contractors
{
    public partial class ContractorDetail : System.Web.UI.Page
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
                LoadContractor(id);
                this.UpdateLink.NavigateUrl = "./UpdateContractor.aspx?id=" + HttpUtility.UrlEncode(id);
                this.DeleteLink.NavigateUrl = "./DeleteContractor.aspx?id=" + HttpUtility.UrlEncode(id);
            }
        }

        protected void LoadContractor(string id)
        {
            var list = DatabaseConnections.GetContractors(id);
            if (list.Any())
            {
                var cont = list.First();
                this.ContractorName.Text = cont.Name;
                this.AddressLabel.Text = cont.Address;
                this.YearLabel.Text = cont.YearEstablished.ToString();
                this.ContractorImage.ImageUrl = !string.IsNullOrEmpty(cont.ImagePath)
                    ? cont.ImagePath
                    : "/images/logo.png";
            }
        }
    }
}
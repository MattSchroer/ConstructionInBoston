namespace ConstructionInBoston.Models
{
    public enum Status
    {
        Proposed, Approved, UnderContruction, Completed
    }

    public class Project
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PermitNumber { get; set; }

        public int SquareFootage { get; set; }

        public int Floors { get; set; }

        public string Status { get; set; }

        public string Architect { get; set; }

        public string Developer { get; set; }

        public string Contractor { get; set; }

        public string Neighborhood { get; set; }

        public string ImagePath { get; set; }
    }
}
namespace basic.wpf.Model
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("FirstName: {0}, LastName: {1}, Company: {2}, Address: {3}, City: {4}, County: {5}, PostCode: {6}, Telephone1: {7}, Telephone2: {8}, Web: {9}, Email: {10}", this.FirstName, this.LastName, this.Company, this.Address, this.City, this.County, this.PostCode, this.Telephone1, this.Telephone2, this.Web, this.Email);
        }
    }
}

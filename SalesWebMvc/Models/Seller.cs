namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(string name, string email, double baseSalary, DateTime birthDate, Department department, ICollection<SalesRecord> sales)
        {
            Name = name;
            this.email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddSales(SalesRecord salesRecord)
        {
        Sales.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
        Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}

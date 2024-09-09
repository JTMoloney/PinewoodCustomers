namespace PinewoodCustomers.Common.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        public bool IsCreate { get {  return Id == Guid.Empty; } }
    }
}

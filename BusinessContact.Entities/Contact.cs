
namespace BusinessContact.Entities
{
    public class Contact : EntityBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int BusinessId { get; set; }
        public virtual Business Business { get; set; }
    }
}

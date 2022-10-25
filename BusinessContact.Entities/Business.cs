
namespace BusinessContact.Entities
{
    public class Business : EntityBase
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual District District { get; set; }

    }
}

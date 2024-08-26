using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Storage : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }    


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Models
{
    public class TaskPerson
    {
        [Key]
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int CountryId { get; set;}
        public int StateId { get; set;}
        public int CityId { get; set; }
        public int AddressID { get; set; }
    }
}

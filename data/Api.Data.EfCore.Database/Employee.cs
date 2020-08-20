using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.EfCore.Database
{
    [Table("Employee")]
    public class Employee : TEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

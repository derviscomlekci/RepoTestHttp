using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("User")]
    public class User:IEntity
    {

        public Guid Id { get; set; }
        public int CounterNumber { get; set; }
    }
}

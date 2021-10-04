using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetEFAutoLot.DAL.Models
{
    public partial class Inventory
    {
        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";

        public override string ToString()
        {
            return $"{this.PetName ?? "*** No Name ***"} is {this.Color}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetEFAutoLot.DAL.Models.MetaData;

namespace DotNetEFAutoLot.DAL.Models
{
    [MetadataType(typeof (InventoryMetaData))]
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

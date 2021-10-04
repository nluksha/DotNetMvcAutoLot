namespace DotNetEFAutoLot.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using DotNetEFAutoLot.DAL.Models.Base;

    public partial class Order : EntityBase
    {
        public int CunstomerId { get; set; }

        public int CarId { get; set; }

        [ForeignKey(nameof(CunstomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(CarId))]
        public virtual Inventory Inventory { get; set; }
    }
}

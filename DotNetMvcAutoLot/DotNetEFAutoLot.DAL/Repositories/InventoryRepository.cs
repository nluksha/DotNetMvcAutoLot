using DotNetEFAutoLot.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetEFAutoLot.DAL.Repositories
{
    public class InventoryRepository: BaseRepository<Inventory>
    {
        public override List<Inventory> GetAll() => Context.Inventory.OrderBy(x => x.PetName).ToList();
    }
}

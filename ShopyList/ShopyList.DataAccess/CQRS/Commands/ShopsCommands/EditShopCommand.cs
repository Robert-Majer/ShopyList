using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.CQRS.Commands.ShopsCommands
{
    public class EditShopCommand : CommandBase<Shop, Shop>
    {
        public override async Task<Shop> Execute(ShopyListStorageContext context)
        {
            var editShop = await context.Shops.SingleOrDefaultAsync(x => x.Id == this.Parameter.Id);
            editShop.Name = this.Parameter.Name;
            //editShop.TypeOfSection = this.Parameter.TypeOfSection;
            //editShop.SectionNumber = this.Parameter.SectionNumber;

            await context.SaveChangesAsync();
            return editShop;
        }
    }
}
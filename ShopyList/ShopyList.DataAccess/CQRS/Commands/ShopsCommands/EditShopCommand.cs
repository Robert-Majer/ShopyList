﻿using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Commands.ShopsCommands
{
    public class EditShopCommand : CommandBase<Shop, Shop>
    {
        public override async Task<Shop> Execute(ShopyListStorageContext context)
        {
            var editShop = await context.Shops.SingleOrDefaultAsync(x => x.Id == this.Parameter.Id);
            if (editShop == null)
            {
                return null;
            }
            editShop.Name = this.Parameter.Name;
            //editShop.TypeOfSection = this.Parameter.TypeOfSection;
            //editShop.SectionNumber = this.Parameter.SectionNumber;

            await context.SaveChangesAsync();
            return editShop;
        }
    }
}
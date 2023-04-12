﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse
{
    public class DeleteShopByIdRequest : IRequest<DeleteShopByIdResponse>
    {
        public int ShopId { get; set; }
    }
}
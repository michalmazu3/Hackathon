 ﻿using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;
using System.Collections.Generic;
 ﻿using Hackathon.Garbage.Dal.Models;
using System;
 
namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IOrdersRepository
    {
        int CreateOrUpdate(OrderBllModel order);
         List<OrderEntity> GetAll();
         Byte[] GetPhotos(int orderId, int index);
     }
}
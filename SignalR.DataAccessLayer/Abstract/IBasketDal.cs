﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal:IEntityRepository<Basket>
    {
        List<Basket> GetBasketByTableNumber(int id);
        Basket AddBasketToProduct(int id,int count);   
    }
}

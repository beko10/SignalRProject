﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Concrete
{
    public class EfSocialMediaDal : EfEntityRepositoryBase<SocialMedia>, ISocialMediaDal
    {
        public EfSocialMediaDal(SignalRContex contex) : base(contex)
        {
        }
    }
}

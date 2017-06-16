using Dafy.OnlineTran.Entity;
//using Dafy.DataBase.Context;
using Dafy.OnlineTran.IService;
using GiveU.Infrastructure.Configuration;
using GiveU.Infrastructure.Configuration.OAuthApp;
using GiveU.Infrastructure.Redis;
using System;
using System.Configuration;

namespace Dafy.OnlineTran.ServiceImpl
{
    public class InitService : IInitService
    {
        public bool Init()
        {
            return true;
        }
    }
}

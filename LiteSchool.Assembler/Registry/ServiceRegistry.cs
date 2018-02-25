using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using LiteSchool.Core.IServices;
using LiteSchool.Services;
using LiteSchool.Core.IPresentation;
using LiteSchool.Presentation;
using StructureMap.Pipeline;
using System.ServiceModel;
using System.Configuration;
using LiteSchool.Entities;
using LiteSchool.Dtos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StructureMap;

namespace LiteSchool.Assembler
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry(ILifecycle lifecycle)
        {            
            Scan(x =>
            {
                x.Assembly("LiteSchool.Services");
                x.Include(t => !t.IsAbstract && t.Name.EndsWith("Service"));
                x.WithDefaultConventions().OnAddedPluginTypes(c => c.LifecycleIs(lifecycle));
            });

           // For<IUserStore<UserDto, string>>().LifecycleIs(lifecycle).Use<UserStoreService>(); //Front
           // For<UserStore<AppUser, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>>().LifecycleIs(lifecycle); //Service
        }
    }
}

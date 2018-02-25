using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using LiteSchool.Core.IRepository;
using System.Configuration;
using LiteSchool.Repositories;
using System.Data.Entity;
using StructureMap;
using StructureMap.Web.Pipeline;
using StructureMap.Pipeline;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using LiteSchool.Entities;
using StructureMap.Graph;
using LiteSchool.Dtos;

namespace LiteSchool.Assembler
{
    public class RepositoryRegistry : Registry
    {             
        public RepositoryRegistry(ILifecycle lifecycle)
        {
            Scan(x =>
            {
                x.Assembly("LiteSchool.Repositories");
                x.Include(t => !t.IsAbstract && t.Name.EndsWith("Repository"));
                x.WithDefaultConventions().OnAddedPluginTypes(c => c.LifecycleIs(lifecycle));
            });
        }
    }
}

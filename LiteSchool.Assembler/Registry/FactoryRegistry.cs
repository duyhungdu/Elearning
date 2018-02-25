using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Assembler
{
    public class FactoryRegistry : Registry
    {
        public FactoryRegistry()
        {
            Scan(x =>
            {
                x.Assembly("LiteSchool.Core");
                x.IncludeNamespace("LiteSchool.Core.Factories");
                x.WithDefaultConventions();
            });
        }
    }
}

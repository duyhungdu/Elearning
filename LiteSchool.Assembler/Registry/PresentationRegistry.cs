using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using LiteSchool.Core.IPresentation;
using LiteSchool.Presentation;
using StructureMap;

namespace LiteSchool.Assembler
{
    public class PresentationRegistry : Registry
    {
        public PresentationRegistry()
        {
            Scan(x =>
            {
                x.Assembly("LiteSchool.Presentation");
                x.Include(t => !t.IsAbstract);
                x.WithDefaultConventions();
            });                        
        }
    }
}

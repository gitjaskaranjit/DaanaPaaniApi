using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.infrastructure
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class SortableAttribute:Attribute
    {

    }
}

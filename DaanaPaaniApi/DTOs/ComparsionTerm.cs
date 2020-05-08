using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class ComparsionTerm
    {
        public Expression left { get; set; }
        public ConstantExpression right { get; set; }
    }
}

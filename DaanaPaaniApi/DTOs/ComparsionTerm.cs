using System.Linq.Expressions;

namespace DaanaPaaniApi.DTOs
{
    public class ComparsionTerm
    {
        public Expression left { get; set; }
        public ConstantExpression right { get; set; }
    }
}
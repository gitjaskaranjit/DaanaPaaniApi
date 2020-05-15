using DaanaPaaniApi.infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DaanaPaaniApi.DTOs
{
    public class SortingOptions<T, TEntity> : IValidatableObject
    {
        public string[] OrderBy { get; set; }

        //To validate incoming sort optiions
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var proccessor = new SortingOptionsProcessor<T, TEntity>(OrderBy);

            var validTerms = proccessor.GetValidTerms().Select(x => x.Name);

            var invalidTerms = proccessor.GetAllTerms().Select(x => x.Name).Except(validTerms, StringComparer.OrdinalIgnoreCase);

            foreach (var term in invalidTerms)
            {
                yield return new ValidationResult(
                    $"Invalid sort term '{term}'", new[] { nameof(OrderBy) }
                    );
            }
        }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> query)
        {
            var processor = new SortingOptionsProcessor<T, TEntity>(OrderBy);
            return processor.Apply(query);
        }
    }
}
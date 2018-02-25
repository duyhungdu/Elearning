using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteSchool.Library.Domain;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace LiteSchool.Entities
{
    [DataContract]
    public abstract class BaseEntity<TId> : IBaseEntity<TId>
    {
        public abstract TId Id { get; set; }

        public BaseEntity()
        {
            BrokenRules = new List<ValidationRule>();
        }

        private List<ValidationRule> _brokenRules;
        public virtual List<ValidationRule> BrokenRules
        {
            get { return _brokenRules; }
            set { _brokenRules = value; }
        }

        /*http://www.codeproject.com/Tips/680381/Data-validation-framework-at-entity-level-using-Da*/
        public virtual bool Validate()
        {
            BrokenRules.Clear();

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, validationContext, validationResults, true);
            foreach (var error in validationResults)            
                BrokenRules.Add(new ValidationRule(error.MemberNames.First(), error.ErrorMessage));
            
            return (BrokenRules.Count == 0);
        }
    }
}

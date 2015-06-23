using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Spa.Data.Infrastructure
{
    public class EfStatus
    {
        private List<ValidationResult> _errors;

        /// <summary>
        /// If there are no errors then it is valid
        /// </summary>
        public bool IsValid
        {
            get { return _errors == null; }
        }

        public IReadOnlyList<ValidationResult> EfErrors
        {
            get { return _errors ?? new List<ValidationResult>(); }
        }

        /// <summary>
        /// This converts the Entity framework errors into Validation errors
        /// </summary>
        public EfStatus SetErrors(IEnumerable<DbEntityValidationResult> errors)
        {
            _errors =
                errors.SelectMany(
                    x => x.ValidationErrors.Select(y =>
                        new ValidationResult(y.ErrorMessage, new[] {y.PropertyName})))
                    .ToList();

            return this;
        }

        public EfStatus SetErrors(IEnumerable<ValidationResult> errors)
        {
            _errors = errors.ToList();
            return this;
        }

        private static readonly Dictionary<int, string> SqlErrorTextDict = new Dictionary<int, string>
        {
            {
                547,
                "This operation failed because another data entry uses this entry."
            },
            {
                2601,
                "One of the properties is marked as Unique index and there is already an entry with that value."
            }
        };

        /// <summary>
        /// This decodes the DbUpdateException. If there are any errors it can
        /// handle then it returns a list of errors. Otherwise it returns null
        /// which means rethrow the error as it has not been handled
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>null if cannot handle errors, otherwise a list of errors</returns>
        public IEnumerable<ValidationResult> TryDecodeDbUpdateException(DbUpdateException ex)
        {
            if (!(ex.InnerException is System.Data.Entity.Core.UpdateException) ||
                !(ex.InnerException.InnerException is System.Data.SqlClient.SqlException))

                return null;

            var sqlException = (System.Data.SqlClient.SqlException) ex.InnerException.InnerException;
            var result = new List<ValidationResult>();

            for (int i = 0; i < sqlException.Errors.Count; i++)
            {
                var errorNum = sqlException.Errors[i].Number;
                string errorText;
                if (SqlErrorTextDict.TryGetValue(errorNum, out errorText))
                    result.Add(new ValidationResult(errorText));
            }

            return result.Any() ? result : null;
        }
    }
}
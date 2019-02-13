using CertificatesModel.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CertificatesModel.Validation
{
    internal class ValidationModel : IValidationModel
    {
        public string ValidateDataModel(Certificate cert)
        {
            StringBuilder builder = new StringBuilder();
            var validationResult = new List<ValidationResult>();
            var context = new ValidationContext(cert);
            if (!Validator.TryValidateObject(cert, context, validationResult, true))
            {
                foreach (var result in validationResult)
                {
                    if (result.MemberNames.FirstOrDefault() != "CertificateNumber")
                        builder.AppendLine(result.ErrorMessage);
                }
            }
            return builder.ToString();
        }

        public string ValidateDataModelForZip(Certificate cert)
        {
            StringBuilder builder = new StringBuilder();
            var validationResult = new List<ValidationResult>();
            var context = new ValidationContext(cert);
            if (!Validator.TryValidateObject(cert, context, validationResult, true))
            {
                foreach (var result in validationResult)
                {
                    builder.AppendLine(result.ErrorMessage);
                }
            }
            return builder.ToString();
        }
    }
}

using CertificatesModel.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CertificatesModel.Validation
{
    internal class ValidationModel : IValidationModel
    {
        // Валидация данных для свидетельств
        public string ValidateDataModel(Certificate cert)
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

        // Валидация данных для извещения о непригодности
        public string ValidateDataModelForFaultNotification(Certificate notification)
        {
            StringBuilder builder = new StringBuilder();
            var validationResult = new List<ValidationResult>();
            var context = new ValidationContext(notification);
            if (!Validator.TryValidateObject(notification, context, validationResult, true))
            {
                foreach (var result in validationResult)
                {
                    if (result.MemberNames.FirstOrDefault() != "CalibrationExpireDate")
                        builder.AppendLine(result.ErrorMessage);
                }
            }
            return builder.ToString();
        }
    }
}

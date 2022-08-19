using Contracts;
using System.ComponentModel.DataAnnotations;

namespace PresentationRest.Test
{
    //CHECK: This way or DojoWay?
    public class ValidationTests
    {
        private bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);

            return Validator.TryValidateObject(model, context, validationResults, true);
        }

        [Theory]
        [InlineData(true, "title", "companyName", "description", "email", "addresse", null, null)]        
        public void ModelValidation(bool isValid, string title, string companyName, string description, string email, string addresse, DateTimeOffset? avaibility, DateTimeOffset? expiration)
        {
            var newOffer = new OfferCreationRequest
            {
                Title = title,
                CompanyName = companyName,
                Description = description,
                Email = email,
                Addresse = addresse,
                Avaibility = avaibility,
                Expiration = expiration
            };
            Assert.Equal(isValid, ValidateModel(newOffer)); 
        }
    }
}

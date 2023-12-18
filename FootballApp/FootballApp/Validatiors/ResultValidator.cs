using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FootballApp.Models;

namespace FootballApp.Validatiors
{
    public class ResultValidator : ValidationAttribute
    {
        private readonly string _scoredName;
        private readonly string _concededName;

        public ResultValidator(string scored, string conceded)
        {
            _scoredName = scored;
            _concededName = conceded;
        }

        protected override ValidationResult IsValid(object result, ValidationContext validationContext) {
            int scoredValue = (int)validationContext.ObjectType.GetProperty(_scoredName).GetValue(validationContext.ObjectInstance, null);
            int concededValue = (int)validationContext.ObjectType.GetProperty(_concededName).GetValue(validationContext.ObjectInstance, null);

            if (scoredValue < 0 || concededValue < 0) {
                return new ValidationResult("Goals conceded and Goals scored must be more than 0!");
            }

            if (scoredValue > concededValue && ((PlayedMatch.Result)result == PlayedMatch.Result.win)) {
                return ValidationResult.Success;
            }
            else if (scoredValue < concededValue && ((PlayedMatch.Result)result == PlayedMatch.Result.lose))
            {
                return ValidationResult.Success;
            }
            else if (scoredValue ==concededValue && ((PlayedMatch.Result)result == PlayedMatch.Result.draw))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HotsScores
{
    class PlayerBattleTagValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var playerBattleTag = value as string;
            if (String.IsNullOrEmpty(playerBattleTag))
            {
                return new ValidationResult(false,
                    "Please enter player battle tag");
            }

            return new ValidationResult(true, null);
        }
    }
}

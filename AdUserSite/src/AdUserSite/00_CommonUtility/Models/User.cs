using System.ComponentModel.DataAnnotations;
using AdUserSite._00_CommonUtility.CustomValidationAttribute;

namespace AdUserSite._00_CommonUtility.Models
{
    public class User
    {
        [Key]
        [RequiredIf("DoubleUserIsOk", false)]
        public string AccountName { get; set; }
        public string FirstName { get; set; }
        public string LastNamePrefix { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //[System.ComponentModel.DefaultValue(false)] C#5
        public bool DoubleUserIsOk { get; set; } = false;//C#6
    }
}

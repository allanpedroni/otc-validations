using Otc.ComponentModel.DataAnnotations;

namespace Otc.Validations.Tests.Data
{
    public class Model
    {
        [Required]
        public SubClass SubClass { get; set; }
    }

    public class SubClass
    {
        public string Name { get; set; }
    }
}

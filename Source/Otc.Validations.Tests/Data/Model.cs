using System;
using System.Collections.Generic;
using Otc.ComponentModel.DataAnnotations;

namespace Otc.Validations.Tests.Data
{
    public class Model
    {
        //[Required(ErrorKey ="TEste", ErrorMessage ="testandooo")]
        public SubClass SubClass { get; set; }

        public List<SubClass> SubClasses { get; set; }

        public int A { get; set; }
        public string B { get; set; }
        public string[] C { get; set; }
        [Required(ErrorKey = "FieldD", ErrorMessage = "testandoooD")]
        public string[] D { get; set; }
    }

    public class SubClass
    {
        [Required(ErrorKey = "SubClass_Name", ErrorMessage = "O nome é obrigatório.", AllowEmptyStrings = false)]
        public string Nome { get; set; }


        [Required(ErrorKey = "SubClass_Numero", ErrorMessage = "Numero é obrigatório.", AllowEmptyStrings = false)]
        public int? Numero { get; set; }
    }
}

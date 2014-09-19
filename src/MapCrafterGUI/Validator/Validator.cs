using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MapCrafterGUI.Validator
{
    public static class Validator
    {
        public static ValidationError[] Validate<T>(T objectToValidate) where T : ValidatableClass
        {
            var r = typeof(T).GetProperties();
            var f = typeof(T).GetFields();

            foreach (PropertyInfo property in r)
            {
                var attrs = property.GetCustomAttributes<ValidatableFieldAttribute>();

                foreach (ValidatableFieldAttribute attribute in attrs)
                {
                    var rodrigo = f.Where(field => field.Name == attribute.func);


                }
            }



            return new ValidationError[0];
        }
    }
}

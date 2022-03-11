using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {

            //PropertyInfo[] properties = obj//намираме протъртитата
            //    .GetType()
            //    .GetProperties();

            //foreach (var prop in properties)
            //{
            //    var attributes = prop
            //        .GetCustomAttributes()
            //        .Where(a => a
            //        .GetType()
            //        .IsSubclassOf(typeof(MyValidationAttribute)))
            //        .ToArray();

            //    foreach (MyValidationAttribute item in attributes)
            //    {
            //        bool isValid = item.IsValid(prop.GetValue(obj));
            //        if (!isValid)
            //        {
            //            return false;
            //        }
            //    }
            //}
            //return true;



            PropertyInfo[] properties = obj//намираме протъртитата
                .GetType()
                .GetProperties();

            foreach (var propertytype in properties)
            {
                //за всяко пропърти намираме атрибутите му + наследниците -> връща object[]
                //затова го кастваме към най абстрактния атрибут

                var attributes = propertytype
                    .GetCustomAttributes(typeof(MyValidationAttribute), true);

                foreach (MyValidationAttribute attribute in attributes)
                {
                    //за всеки атрибут си правим проверка като влизаме в неговата проверка

                    //взимаме стойността на пропъртито на обекта за този атрибут
                    var value = propertytype.GetValue(obj);

                    //и му подаваме стойностите на текущото пропърти
                    bool isValid = attribute.IsValid(value);
                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
    /// <summary>
    /// Класс <see cref="ValueValidator"/> предназначен для 
    /// проверки корректности значений перед их использованием
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Метод предназначен для проверки числа 
        /// на вхождение в определенных диапазон
        /// </summary>
        /// <param name="number">Проверяемое число</param>
        /// <param name="minLimit">Минимальное допустимое 
        /// значение числа</param>
        /// <param name="maxLimit">Максимальное допустимое 
        /// значение числа</param>
        /// <returns>Значение показывает, 
        /// входит ли число в допустимый диапазон </returns>
        private static bool IsValueInRange(double number,
            double minLimit, double maxLimit)
        {
            return minLimit <= number && maxLimit >= number;
        }

        /// <summary>
        /// Метод предназначен для проверки длины строки на
        /// допустимое количество
        /// </summary>
        /// <param name="value">Проверяемая строка</param>
        /// <param name="minLength">Минимальная допустимая 
        /// длина строки</param>
        /// <param name="maxLength">Максимальная допустимая 
        /// длина строки</param>
        /// <returns>Значение показывает, 
        /// является ли длина строки допустимой для использования</returns>
        private static bool IsLengthInRange(string value, int minLength,
            int maxLength)
        {
            return minLength <= value.Length
                && maxLength >= value.Length;
        }

        /// <summary>
        /// Метод предназначен для генерации исключения
        /// в случае, если число не входит в допустимый диапазон
        /// </summary>
        /// <param name="value">Проверяемое число</param>
        /// <param name="minLimit">Минимальное допустимое 
        /// значение числа</param>
        /// <param name="maxLimit">Максимальное допустимое
        /// значение числа</param>
        /// <param name="context">Поле объекта, которое будет 
        /// инициализировано проверяемым значением 
        /// в именительном падеже</param>
        public static void AssertValueInRange(double value,
            double minLimit, double maxLimit, string context)
        {
            if (!IsValueInRange(value, minLimit, maxLimit))
            {
                throw new ArgumentException("ИСКЛЮЧЕНИЕ: Число "
                    + value
                    + "\nне входит в допустимый дипапазон ["
                    + minLimit + ", " + maxLimit + "]"
                    + "\nи не может определять " + context);
            }
        }

        /// <summary>
        /// Метод предназначен для генерации исключения
        /// в случае, если количество символов в строке не входит
        /// в допустимый диапазон
        /// </summary>
        /// <param name="value">Проверяемая строка</param>
        /// <param name="minLength">Минимальное количество 
        /// символов в строке</param>
        /// <param name="maxLength">Максимальное количество 
        /// символов в строке</param>
        /// <param name="context">Поле объекта, которое будет 
        /// инициализировано проверяемым значением 
        /// в именительном падеже</param>
        public static void AssertLengthInRange(string value,
            int minLength, int maxLength, string context)
        {
            if (!IsLengthInRange(value, minLength, maxLength))
            {
                throw new ArgumentException("ИСКЛЮЧЕНИЕ: \""
                    + value + "\"\n превышает допустимую длину ["
                    + minLength + ", " + maxLength + "]"
                    + "\nи не может определять " + context);
            }
        }
    }
}

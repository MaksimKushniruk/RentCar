using System;

namespace Rent
{
    public static class Extensions
    {
        // Приводит к нужному типу объект, возвращаемый из БД, если объект null, возвращает значение по умолчанию
        public static T CastDbValue<T>(this object value)
        {
            try
            {
                return value == DBNull.Value ? default(T) : (T)value;
            }
            catch
            {
                // игнорируем
            }

            return default(T);
        }
        // Проверка на равенство строк, с удаление пробелов, учетом языка, региональных параметров и без учета регистра
        public static bool IsEquals(this string strA, string strB)
        {
            // если А null, то возвращаем true, если В null, и false если B не null
            if (string.IsNullOrEmpty(strA))
            {
                return string.IsNullOrEmpty(strB);
            }
            // если А ну null, а В null, то возвращаем false
            if (string.IsNullOrEmpty(strB))
            {
                return false;
            }
            // сравниваем строки с обрезанием пробелов, учетом языка, без учета регистра
            return strA.Trim().Equals(strB.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        // Формат обратного преобразования даты и времени. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzzz"
        public static string FormatDateTime(this DateTime datetime)
        {
            return datetime.ToString("o");
        }
        // Возвращает строку, где число представлено в виде формата N(2 цифры после запятой)  -12,445.68
        public static string FormatDecimal(this decimal value)
        {
            return value.ToString("N2");
        }
        // Возвращает строку с разницой во времени 
        public static string GetTimeDifference(DateTime start, DateTime end)
        {
            var diff = end.Subtract(start);
            return $"{diff.Hours} hrs {diff.Minutes} mins {diff.Seconds} secs";
        }
    }
}

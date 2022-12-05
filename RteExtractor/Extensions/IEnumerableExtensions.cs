using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RteExtractor
{
    public static class IEnumerableExtensions
    {
        private static readonly char _columnSeperator = ';';

        public static void ExportToTextFile<T>(this IEnumerable<T> data, string fileName)
        {
            using var sw = File.CreateText(fileName);

            var plist = typeof(T).GetProperties().Where(p => p.CanRead && (p.PropertyType.IsValueType || p.PropertyType == typeof(string)) && p.GetIndexParameters().Length == 0).ToList();
            if (plist.Count > 0)
            {
                var seperator = _columnSeperator.ToString();
                sw.WriteLine(string.Join(seperator, plist.Select(p => p.Name)));
                foreach (var item in data)
                {
                    var values = new List<object>();
                    foreach (var p in plist) values.Add(p.GetValue(item, null));
                    sw.WriteLine(string.Join(seperator, values));
                }
            }
        }
    }
}

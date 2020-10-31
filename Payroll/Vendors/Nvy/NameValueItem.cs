using System;
using System.Collections.Generic;
using System.Linq;

namespace Nvy {
    public class Item<N, V>
        where N : class
        where V : class {

        protected N InternalName { get; set; }
        protected V InternalValue { get; set; }
    }


    [Serializable]
    public class NameValueItem : Item<String, String> {
        public const String NameProperty = "Name";
        public const String ValueProperty = "Value";
        public const Char ListDelimiter = '·'; // ALT+250
        public const Char ItemDelimiter = '•'; // ALT+7

        public String Name {
            get {
                return InternalName;
            }

            private set {
                InternalName = value;
            }
        }

        public String Value {
            get {
                return InternalValue;
            }

            private set {
                InternalValue = value;
            }
        }

        public static NameValueItem Empty => new NameValueItem();

        public NameValueItem(String name, String value) {
            InternalName = name;
            InternalValue = value;
        }

        public NameValueItem() : this(String.Empty, String.Empty) { }
    }

    public static class NameValueItemExt {
        public static IEnumerable<NameValueItem> AsNameValueList(this String delimitedString) {
            String[] splittedList = delimitedString.Split(NameValueItem.ListDelimiter);
            return splittedList
                .Select(item => item.Split(NameValueItem.ItemDelimiter))
                .Select(splittedItem => new NameValueItem(splittedItem[0], splittedItem[1]));
        }

        public static IEnumerable<NameValueItem> AsNameValueList<T>(this IEnumerable<T> dataList, Func<T, String> nameSelector, Func<T, String> valueSelector) where T : class =>
            dataList.Select(data => new NameValueItem(nameSelector(data), valueSelector(data)));

        public static String AsDelimitedString(this IEnumerable<NameValueItem> nameValueList) {
            String[] delimitedStringList = nameValueList.Select(item => item.Name + NameValueItem.ItemDelimiter + item.Value).ToArray();
            String delimitedString = String.Join(NameValueItem.ListDelimiter.ToString(), delimitedStringList);

            return delimitedString;
        }
    }

    public static class ObjectExt {
        public static String AsDelimitedString<T>(this T t, String itemDelimiter, params Func<T, String>[] tSelector) where T : class =>
            String.Join(itemDelimiter, tSelector.Select(selector => selector(t)).ToArray());

        public static String AsDelimitedString<T>(this IEnumerable<T> tList, String itemDelimiter, String listDelimiter, params Func<T, String>[] tSelector) where T : class {
            IEnumerable<String> delimitedStringList = tList.Select(t => t.AsDelimitedString(itemDelimiter, tSelector));
            String delimitedString = String.Join(listDelimiter, delimitedStringList.ToArray());

            return delimitedString;
        }
    }
}
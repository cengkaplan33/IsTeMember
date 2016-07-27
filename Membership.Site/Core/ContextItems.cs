using System.Collections;
using System.Web;

namespace Membership.Site
{
    /// <summary>
    ///   Helper class to access a hashtable for current request, or a global hashtable if this is not
    ///   a web application.</summary>
    public class ContextItems
    {
        /// <summary>
        ///   Internal hashtable for non-web applications.</summary>
        private static Hashtable _internalItems = new Hashtable();

        /// <summary>
        ///   Gets a value by its key from current HTTP context items, or if it is not a web application, from the
        ///   global hash table.</summary>
        /// <param name="key">
        ///   Key object (required).</param>
        /// <returns>
        ///   Key value.</returns>
        public static object Get(object key)
        {
            var context = HttpContext.Current;
            if (context == null)
                lock (_internalItems)
                    return _internalItems[key];
            return context.Items[key];
        }

        /// <summary>
        ///   Gets a value by its key from current HTTP context items, or if it is not a web application, from the
        ///   global hash table.</summary>
        /// <param name="key">
        ///   Key object (required).</param>
        /// <param name="defaultValue">
        ///   Default value to return if the value is null.</param>
        /// <returns>
        ///   Key value.</returns>
        public static T Get<T>(object key, T defaultValue)
        {
            var context = HttpContext.Current;
            object value;
            if (context == null)
            {
                lock (_internalItems)
                    value = _internalItems[key];
            }
            else
                value = context.Items[key];
            if (value == null)
                return defaultValue;
            else
                return (T)(value);
        }

        /// <summary>
        ///   Sets a value by its key in current HTTP context items, or if it is not a web application, in the
        ///   global hash table.</summary>
        /// <param name="key">
        ///   Key object (required).</param>
        /// <param name="value">
        ///   Key value.</param>
        public static void Set(object key, object value)
        {
            var context = HttpContext.Current;
            if (context == null)
                lock (_internalItems)
                    _internalItems[key] = value;
            else
                context.Items[key] = value;
        }

        /// <summary>
        ///   Gets current HTTP context items, or if it is not a web application, the global hash table.</summary>
        /// <returns>
        ///   A hashtable.</returns>
        public static IDictionary Dictionary
        {
            get
            {
                var context = HttpContext.Current;
                if (context == null)
                    lock (_internalItems)
                        return _internalItems;
                else
                    return context.Items;
            }
        }
    }
}

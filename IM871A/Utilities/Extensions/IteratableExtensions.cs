using System;
using System.Collections.Generic;
using System.Text;

namespace IM871A.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for lists and so on.
    /// </summary>
    public static class IteratableExtensions
    {
        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">the type.</typeparam>
        /// <param name="iList">the list.</param>
        /// <param name="collection">the collection.</param>
        public static void AddRange<T>(this IList<T> iList, IEnumerable<T> collection)
        {
            if (iList == null)
            {
                throw new ArgumentNullException(nameof(iList));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (iList is List<T> list)
            {
                list.AddRange(collection);
            }
            else
            {
                foreach (T item in collection)
                {
                    iList.Add(item);
                }
            }
        }

    }
}
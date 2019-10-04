using System.Collections.Generic;

namespace DotNetUniversalPatcher.Extensions
{
    public static class ListExtensions
    {
        internal static void MoveUp<T>(this List<T> list, int index)
        {
            if (index == 0)
            {
                return;
            }

            var temp = list[index - 1];
            list[index - 1] = list[index];
            list[index] = temp;
        }

        internal static void MoveDown<T>(this List<T> list, int index)
        {
            int count = list.Count;

            if (index == count - 1)
            {
                return;
            }

            var temp = list[index + 1];
            list[index + 1] = list[index];
            list[index] = temp;
        }
    }
}
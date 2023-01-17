using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaDepotDownloader;
internal static class Extensions
{
    public static bool Matches<T>(this T item, params T[] choices)
    {
        foreach (var choice in choices)
            if (item.Equals(choice))
                return true;
        return false;
    }
}

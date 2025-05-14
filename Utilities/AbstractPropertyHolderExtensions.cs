using CUE4Parse.GameTypes.PUBG.Assets.Exports;
using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUE4Parse.Utilities
{
    public static class AbstractPropertyHolderExtensions
    {
        public static T? GetOrDefaultFromDataList<T>(this AbstractPropertyHolder propHolder, string name, T? defaultValue = default, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (!propHolder.TryGetValue(out FInstancedStruct[] dataList, "DataList"))
            {
                return defaultValue;
            }
            var dataListEntry = dataList.FirstOrDefault(i=>i.NonConstStruct?.Properties.Exists(p => p.Name.Text == name) == true);
            if (dataListEntry is null)
            {
                return defaultValue;
            }
            return PropertyUtil.GetOrDefault(dataListEntry.NonConstStruct!, name, defaultValue, comparisonType);
        }
    }
}

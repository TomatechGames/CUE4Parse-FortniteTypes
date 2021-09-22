using CUE4Parse.FN.Exports.Fortnite;
using CUE4Parse.UE4;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Assets.Utils;

namespace CUE4Parse.FN.Structs.Fortnite
{
    [StructFallback]
    public class FFortWeaponModSlot : IUStruct
    {
        public UFortWeaponModItemDefinition WeaponMod;
        public bool bIsDynamic;

        public FFortWeaponModSlot(FStructFallback fallback)
        {
            WeaponMod = fallback.GetOrDefault<UFortWeaponModItemDefinition>(nameof(WeaponMod));
            bIsDynamic = fallback.GetOrDefault<bool>(nameof(bIsDynamic));
        }
    }
}
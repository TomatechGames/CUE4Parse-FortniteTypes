using CUE4Parse.UE4;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Assets.Utils;
using CUE4Parse.UE4.Objects.GameplayTags;

namespace CUE4Parse.FN.Structs.FortniteGame
{
    [StructFallback]
    public class FCosmeticVariantInfo 
    {
        public FGameplayTag? VariantChannelTag;
        public FGameplayTag? ActiveVariantTag;

        public FCosmeticVariantInfo(FStructFallback fallback)
        {
            VariantChannelTag = fallback.GetOrDefault<FGameplayTag>(nameof(VariantChannelTag));
            ActiveVariantTag = fallback.GetOrDefault<FGameplayTag>(nameof(ActiveVariantTag));
        }
    }
}
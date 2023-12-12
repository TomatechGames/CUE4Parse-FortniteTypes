using CUE4Parse.FN.Enums.FortniteGame;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Assets.Utils;
using CUE4Parse.UE4.Objects.GameplayTags;

namespace CUE4Parse.FN.Structs.FortniteGame
{
    [StructFallback]
    public class FInlineObjectiveStatTagCheckEntry
    {
        public FGameplayTag Tag;
        public EInlineObjectiveStatTagCheckEntryType Type;
        public bool Require;

        public FInlineObjectiveStatTagCheckEntry(FStructFallback fallback)
        {
            Tag = fallback.GetOrDefault<FGameplayTag>(nameof(Tag));
            Type = fallback.GetOrDefault<EInlineObjectiveStatTagCheckEntryType>(nameof(Type));
            Require = fallback.GetOrDefault<bool>(nameof(Require));
        }
    }
}
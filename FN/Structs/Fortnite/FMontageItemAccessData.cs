using CUE4Parse.FN.Exports.Fortnite;
using CUE4Parse.FN.Structs.GT;
using CUE4Parse.UE4;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Assets.Utils;

namespace CUE4Parse.FN.Structs.Fortnite
{
    [StructFallback]
    public class FMontageItemAccessData : IUStruct
    {
        public FGameplayTag AccessTag;
        public UFortItemAccessTokenType AccessToken;

        public FMontageItemAccessData(FStructFallback fallback)
        {
            AccessTag = fallback.GetOrDefault<FGameplayTag>(nameof(AccessTag));
            AccessToken = fallback.GetOrDefault<UFortItemAccessTokenType>(nameof(AccessToken));
        }
    }
}
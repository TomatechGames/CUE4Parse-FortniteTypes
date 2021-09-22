using System;
using System.Collections.Generic;
using CUE4Parse.FN.Enums.Fortnite;
using CUE4Parse.FN.Enums.PhysicsCore;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Assets.Readers;
using CUE4Parse.UE4.Objects.UObject;

namespace CUE4Parse.FN.Exports.Fortnite
{
    public class UFortWeaponMeleeDualWieldItemDefinition : UFortWeaponMeleeItemDefinition
    {
        public FSoftObjectPath WeaponMeshOffhandOverride; // USkeletalMesh
        public FSoftObjectPath IdleEffectOffhand; // UParticleSystem
        public FSoftObjectPath IdleEffectOffhandNiagara; // UNiagaraSystem
        public FSoftObjectPath SwingEffectOffhand; // UParticleSystem
        public FSoftObjectPath SwingEffectOffhandNiagara; // UNiagaraSystem
        public FSoftObjectPath AnimTrailsOffhand; // UParticleSystem
        public FSoftObjectPath AnimTrailsNiagaraOffhand; // UNiagaraSystem
        public FSoftObjectPath OffhandGenericImpactSound; // USoundBase
        public Dictionary<EPhysicalSurface, FSoftObjectPath> OffhandImpactPhysicalSurfaceSoundsMap = new(); // USoundBase
        public Dictionary<EPhysicalSurface, FSoftObjectPath> OffhandImpactPhysicalSurfaceEffects = new(); // UParticleSystem
        public Dictionary<EPhysicalSurface, FSoftObjectPath> OffhandImpactNiagaraPhysicalSurfaceEffects = new(); // UNiagaraSystem
        public Dictionary<EFortWeaponSoundState, FSoftObjectPath> OffhandPrimaryFireSoundMap = new(); // USoundBase
        public FName AnimTrailsOffhandFirstSocketName;
        public FName AnimTrailsOffhandSecondSocketName;
        public float AnimTrailsOffhandWidth;
        public bool bUseAnimTrailsOffhand;
        public bool bAttachAnimTrailsOffhandToWeapon;
        public FName IdleFXOffhandSocketName;
        public FName SwingFXOffhandSocketName;

        public override void Deserialize(FAssetArchive Ar, long validPos)
        {
            base.Deserialize(Ar, validPos);

            WeaponMeshOffhandOverride = GetOrDefault<FSoftObjectPath>(nameof(WeaponMeshOffhandOverride));
            IdleEffectOffhand = GetOrDefault<FSoftObjectPath>(nameof(IdleEffectOffhand));
            IdleEffectOffhandNiagara = GetOrDefault<FSoftObjectPath>(nameof(IdleEffectOffhandNiagara));
            SwingEffectOffhand = GetOrDefault<FSoftObjectPath>(nameof(SwingEffectOffhand));
            SwingEffectOffhandNiagara = GetOrDefault<FSoftObjectPath>(nameof(SwingEffectOffhandNiagara));
            AnimTrailsOffhand = GetOrDefault<FSoftObjectPath>(nameof(AnimTrailsOffhand));
            AnimTrailsNiagaraOffhand = GetOrDefault<FSoftObjectPath>(nameof(AnimTrailsNiagaraOffhand));
            OffhandGenericImpactSound = GetOrDefault<FSoftObjectPath>(nameof(OffhandGenericImpactSound));

            var offImpPhysSounds = GetOrDefault<UScriptMap>(nameof(OffhandImpactPhysicalSurfaceSoundsMap));
            foreach (var (key, value) in offImpPhysSounds.Properties)
            {
                if (key is EnumProperty k && Enum.TryParse(k.Value.Text, true, out EPhysicalSurface surface) &&
                    value?.GenericValue is FSoftObjectPath path)
                {
                    OffhandImpactPhysicalSurfaceSoundsMap.Add(surface, path);
                }
            }

            var offImpPhysEffects = GetOrDefault<UScriptMap>(nameof(OffhandImpactPhysicalSurfaceEffects));
            foreach (var (key, value) in offImpPhysEffects.Properties)
            {
                if (key is EnumProperty k && Enum.TryParse(k.Value.Text, true, out EPhysicalSurface surface) &&
                    value?.GenericValue is FSoftObjectPath path)
                {
                    OffhandImpactPhysicalSurfaceEffects.Add(surface, path);
                }
            }

            var offImpNiagaraPhysEffects = GetOrDefault<UScriptMap>(nameof(OffhandImpactNiagaraPhysicalSurfaceEffects));
            foreach (var (key, value) in offImpNiagaraPhysEffects.Properties)
            {
                if (key is EnumProperty k && Enum.TryParse(k.Value.Text, true, out EPhysicalSurface surface) &&
                    value?.GenericValue is FSoftObjectPath path)
                {
                    OffhandImpactNiagaraPhysicalSurfaceEffects.Add(surface, path);
                }
            }

            var offPrimaryFire = GetOrDefault<UScriptMap>(nameof(OffhandPrimaryFireSoundMap));
            foreach (var (key, value) in offPrimaryFire.Properties)
            {
                if (key is EnumProperty k && Enum.TryParse(k.Value.Text, true, out EFortWeaponSoundState state) &&
                    value?.GenericValue is FSoftObjectPath path)
                {
                    OffhandPrimaryFireSoundMap.Add(state, path);
                }
            }

            AnimTrailsOffhandFirstSocketName = GetOrDefault<FName>(nameof(AnimTrailsOffhandFirstSocketName));
            AnimTrailsOffhandSecondSocketName = GetOrDefault<FName>(nameof(AnimTrailsOffhandSecondSocketName));
            AnimTrailsOffhandWidth = GetOrDefault<float>(nameof(AnimTrailsOffhandWidth));
            bUseAnimTrailsOffhand = GetOrDefault<bool>(nameof(bUseAnimTrailsOffhand));
            bAttachAnimTrailsOffhandToWeapon = GetOrDefault<bool>(nameof(bAttachAnimTrailsOffhandToWeapon));
            IdleFXOffhandSocketName = GetOrDefault<FName>(nameof(IdleFXOffhandSocketName));
            SwingFXOffhandSocketName = GetOrDefault<FName>(nameof(SwingFXOffhandSocketName));
        }
    }
}
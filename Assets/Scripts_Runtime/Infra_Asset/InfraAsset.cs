using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Act {
    public static class InfraAsset {
        public static void LoadAll(InfraAssetContext ctx) {
            var ptr = Addressables.LoadAssetsAsync<GameObject>("Entities", null);
            var list = ptr.WaitForCompletion();
            foreach (var va in list) {
                ctx.Entity_Add(va.name, va);
            }
            ctx.entityPtr = ptr;
        }

        public static void Unload(InfraAssetContext ctx) {
            if (ctx.entityPtr.IsValid()) {
                Addressables.Release(ctx.entityPtr);
            }
        }
    }
}

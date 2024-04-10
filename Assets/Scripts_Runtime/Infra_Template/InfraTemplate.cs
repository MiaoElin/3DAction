using UnityEngine;
using UnityEngine.AddressableAssets;
namespace Act {
    public static class InfraTemplate {
        public static void LoadAll(TemplateContext ctx) {
            {
                var ptr = Addressables.LoadAssetsAsync<RoleTM>("RoleTM", null);
                var list = ptr.WaitForCompletion();
                foreach (var tm in list) {
                    ctx.RoleTM_Add(tm);
                }
                ctx.rolePtr = ptr;
            }
            {
                var ptr = Addressables.LoadAssetsAsync<LootTM>("LootTM", null);
                ctx.lootPtr = ptr;
                var list = ptr.WaitForCompletion();
                foreach (var tm in list) {
                    ctx.LootTM_Add(tm);
                }
            }
        }

        public static void Unload(TemplateContext ctx) {
            if (ctx.rolePtr.IsValid()) {
                Addressables.Release(ctx.rolePtr);
            }
            if (ctx.lootPtr.IsValid()) {
                Addressables.Release(ctx.lootPtr);
            }
        }
    }
}
using UnityEngine;
using UnityEngine.AddressableAssets;
namespace Act {
    public static class InfraTemplate {
        public static void LoadAll(TemplateContext ctx) {
            var ptr = Addressables.LoadAssetsAsync<RoleTM>("RoleTM", null);
            var list = ptr.WaitForCompletion();
            foreach (var tm in list) {
                ctx.RoleTM_Add(tm);
            }
            ctx.ptr = ptr;
        }

        public static void Undoad(TemplateContext ctx) {
            if (ctx.ptr.IsValid()) {
                Addressables.Release(ctx.ptr);
            }
        }
    }
}
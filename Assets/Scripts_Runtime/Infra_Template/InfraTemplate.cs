using UnityEngine;
using UnityEngine.AddressableAssets;
namespace Act {
    public static class InfraTemplate {
        public static void LoadAll(TemplateContext ctx) {
            var list = Addressables.LoadAssetsAsync<RoleTM>("RoleTM", null).WaitForCompletion();
            foreach (var tm in list) {
                ctx.RoleTM_Add(tm);
            }
        }
    }
}
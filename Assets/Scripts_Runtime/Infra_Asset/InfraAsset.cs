using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Act {
    public static class InfraAsset {
        public static void LoadAll(InfraAssetContext ctx) {
            var list = Addressables.LoadAssetsAsync<GameObject>("Entities", null).WaitForCompletion();
            foreach (var va in list) {
                ctx.Entity_Add(va.name, va);
                Debug.Log(list.Count);
            }
        }
    }
}

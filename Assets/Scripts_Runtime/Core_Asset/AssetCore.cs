using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

namespace Act {
    public static class AssetCore {

        public static void LoadAll(AssetContext ctx) {
            Action<GameObject> handle = (GameObject game) => { Deg(game); };
            var ptr = Addressables.LoadAssetsAsync<GameObject>("Entities", handle);
            Debug.Log("add");
            var list = ptr.WaitForCompletion();
            foreach (var va in list) {
                ctx.Entity_Add(va.name, va);
            }
            ctx.entityPtr = ptr;
        }

        public static void Deg(GameObject game) {
            // game.transform.localScale = new Vector3(2, 2, 2);
            // Debug.Log("1");
        }
        public static void Unload(AssetContext ctx) {
            if (ctx.entityPtr.IsValid()) {
                Addressables.Release(ctx.entityPtr);
            }
        }
    }
}

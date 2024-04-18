using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Act {

    public static class SoundCore {

        public static void Load(SoundCoreContext ctx) {
            var gameObject = Addressables.LoadAssetAsync<GameObject>("AudioSource").WaitForCompletion();
            ctx.prefab = gameObject.GetComponent<AudioSource>();
            GameObject sfxRoot = new GameObject("SFXRoot");
            ctx.BgmPlayer = GameObject.Instantiate<AudioSource>(ctx.prefab, sfxRoot.transform);
            ctx.openBagPlayer = GameObject.Instantiate<AudioSource>(ctx.prefab, sfxRoot.transform);
        }

        public static void BGMPlay(SoundCoreContext ctx, AudioClip clip) {
            var player = ctx.BgmPlayer;
            player.loop = true;
            player.clip = clip;
            player.Play();
        }

        public static void OpenBagPlayer(SoundCoreContext ctx, AudioClip clip) {
            var player = ctx.openBagPlayer;
            player.clip = clip;
            player.Play();
        }

        // public static 
    }
}
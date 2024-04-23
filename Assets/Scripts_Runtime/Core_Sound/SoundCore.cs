using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Act {

    public static class SoundCore {

        public static void Load(SoundCoreContext ctx) {
            var gameObject = Addressables.LoadAssetAsync<GameObject>("AudioSource").WaitForCompletion();
            ctx.prefab = gameObject.GetComponent<AudioSource>();
            // 运行的时候生成一个SFXRoot
            GameObject sfxRoot = new GameObject("SFXRoot");
            ctx.bgmPlayer = GameObject.Instantiate<AudioSource>(ctx.prefab, sfxRoot.transform);
            ctx.openBagPlayer = GameObject.Instantiate<AudioSource>(ctx.prefab, sfxRoot.transform);
            ctx.rolePickPlayer = GameObject.Instantiate<AudioSource>(ctx.prefab, sfxRoot.transform);
            ctx.roleRunPlayer = GameObject.Instantiate<AudioSource>(ctx.prefab, sfxRoot.transform);
        }

        public static void BGMPlay(SoundCoreContext ctx, AudioClip clip) {
            var player = ctx.bgmPlayer;
            player.loop = true;
            player.clip = clip;
            player.Play();
        }

        public static void OpenBagPlayer(SoundCoreContext ctx, AudioClip clip) {
            var player = ctx.openBagPlayer;
            player.clip = clip;
            player.Play();
        }

        public static void PickPlayer(SoundCoreContext ctx, AudioClip clip) {
            var player = ctx.rolePickPlayer;
            player.clip = clip;
            player.Play();
        }

        public static void RoleRunPlayer(SoundCoreContext ctx, AudioClip clip) {
            var player = ctx.roleRunPlayer;
            player.loop = true;
            if (!player.isPlaying) {
                player.clip = clip;
                player.Play();
            }
        }
        public static void RoleRunStop(SoundCoreContext ctx, AudioClip clip) {
            var player = ctx.roleRunPlayer;
            player.clip = clip;
            player.Stop();
        }
    }
}
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Act.UI;
namespace Act {
    public static class UIApp {
        public static void LoadAll(UIContext ctx) {
            var list = Addressables.LoadAssetsAsync<GameObject>("UI", null).WaitForCompletion();
            foreach (var ui in list) {
                ctx.UI_Add(ui.name, ui);

            }
        }
        public static void Panel_Login_Open(UIContext ctx) {
            var panel = UIFactory.UI_Create<Panel_Login>(ctx);
            panel.Ctor();
            panel.OnStartHandle += () => {/* 进入游戏 */ctx.uIEvent.Login_StarGame(); };
            panel.OnExitHandle += () => {/* 退出游戏程序 */ ctx.uIEvent.Login_ExitGame(); };
        }
        public static void Panel_Login_Close(UIContext ctx) {
            var name = typeof(Panel_Login).Name;
            var panel = ctx.openedUI_TryGet<Panel_Login>();
            if (panel == null) {
                return;
            }
            ctx.openedUI_Remove(name);
            GameObject.Destroy(panel.gameObject);
        }

        public static void Panel_Login_Tick(UIContext ctx) {
            var name = typeof(Panel_Login).Name;
            var panel = ctx.openedUI_TryGet<Panel_Login>();
            panel?.VideoPlay();
        }

        // Hud_HpBar
        public static void HUD_HpBar_Open(UIContext ctx, int id, int hpMax) {
            HUD_HpBarDomain.Open(ctx, id, hpMax);
        }

        public static void HUD_HpBar_Update(UIContext ctx, int id, int hp, Vector3 rolePos, float headOffset,Vector3 forward) {
            HUD_HpBarDomain.Update_Tick(ctx, id, hp, rolePos, headOffset,forward);
        }
    }
}
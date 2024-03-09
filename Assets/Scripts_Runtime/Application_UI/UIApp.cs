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
            var panel = UIFactory.Panel_Open<Panel_Login>(ctx);
            panel.Ctor();
            panel.OnStartHandle += () => {/* 进入游戏 */ctx.uIEvent.Login_StarGame(); };
            panel.OnExitHandle += () => {/* 退出游戏程序 */ ctx.uIEvent.Login_ExitGame(); };
        }
        public static void Panel_Login_Close(UIContext ctx) {
            var name = typeof(Panel_Login).Name;
            ctx.openedUI_TryGet(name, out MonoBehaviour panel);
            if (panel == null) {
                return;
            }
            ctx.openedUI_Remove(name);
            GameObject.Destroy(panel.gameObject);
        }
    }
}
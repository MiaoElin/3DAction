using UnityEngine;
namespace Act {
    public static class UIFactory {
        public static T UI_Create<T>(UIContext ctx) where T : MonoBehaviour {
            string name = typeof(T).Name;
            var has = ctx.UI_TrygetValue(name, out GameObject prefab);
            var panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<T>();
            ctx.OpenedUI_Add(name, panel);
            return panel;
        }

        public static HUD_HpBar HUD_HpBarCreate(UIContext ctx, int id) {
            var has = ctx.UI_TrygetValue(typeof(HUD_HpBar).Name, out var prefab);
            var hud = GameObject.Instantiate(prefab, ctx.worldCanvas.transform).GetComponent<HUD_HpBar>();
            ctx.HpBarDic_Add(id, hud);
            return hud;
        }
    }
}

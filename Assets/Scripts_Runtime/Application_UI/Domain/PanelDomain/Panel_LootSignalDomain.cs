using UnityEngine;

namespace Act {

    public static class Panel_LootSignalDomain {
        public static void Open(UIContext ctx, int id, string lootName, Vector3 worldPos) {
            bool hasAdd = ctx.LootSignal_Tryget(id, out var panel);
            if (panel == null) {
                var has = ctx.UI_TrygetValue(typeof(Panel_LootSignal).Name, out var value);
                if (!has) {
                    Debug.Log("Don't have Panel_LootSignal");
                }
                panel = GameObject.Instantiate(value, ctx.screenCanvas.transform).GetComponent<Panel_LootSignal>();
                panel.Ctor(lootName);
                ctx.LootSignal_Add(id, panel);
            }
            panel.SetPos(worldPos);
            panel.gameObject.SetActive(true);

        }

        public static void Hide(UIContext ctx, int id) {
            ctx.LootSignal_Tryget(id, out var panel);
            panel?.gameObject.SetActive(false);
        }

        public static void Close(UIContext ctx, int id) {
            ctx.LootSignal_Tryget(id, out var Panel);
            if (Panel != null) {
                ctx.LootSignal_Remove(id);
                Panel.Close();
            }

        }

    }
}
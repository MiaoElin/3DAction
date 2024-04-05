using UnityEngine;

namespace Act.UI {

    public static class HUD_HpBarDomain {

        public static void Open(UIContext ctx, int id, int hpMax) {
            var hud = UIFactory.HUD_HpBarCreate(ctx, id);
            hud.SetHpMax(hpMax);
        }

        public static void Update_Tick(UIContext ctx, int id, int hp, Vector3 rolePos, float headOffset,Vector3 forward) {
            ctx.HpBarDic_Tryget(id, out var hud);
            hud?.Update_Tick(hp, rolePos, headOffset,forward);
        }

        // public static void Hide()
    }
}
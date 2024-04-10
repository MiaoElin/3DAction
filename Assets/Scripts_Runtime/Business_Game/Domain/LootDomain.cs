using UnityEngine;

namespace Act {

    public static class LootDomain {
        public static void Spawn(GameContext ctx, int typeID, Vector3 pos) {
            var loot = GameFactory.CreateLoot(ctx, pos, typeID);
            ctx.lootRepo.Add(loot);
        }

        public static void ShowPanel_LootSignal(GameContext ctx, LootEntity loot, Vector3 pos, float radius) {
            bool isInRange = PFMath.IsInRange(loot.GetPos(), pos, radius);
            if (isInRange) {
                UIApp.Panel_LootSignal_Open(ctx.uICtx, loot.id, loot.lootName, loot.GetPos());
            } else {
                UIApp.Panel_LootSignal_Hide(ctx.uICtx, loot.id);
            }
        }
    }
}
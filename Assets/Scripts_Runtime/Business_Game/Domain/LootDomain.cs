using UnityEngine;

namespace Act {

    public static class LootDomain {
        public static void Spawn(GameContext ctx, int typeID, Vector3 pos) {
            var loot = GameFactory.CreateLoot(ctx, pos, typeID);
            ctx.lootRepo.Add(loot);
        }
    }
}
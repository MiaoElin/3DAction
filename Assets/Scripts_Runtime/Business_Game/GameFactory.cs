using UnityEngine;
namespace Act {
    public static class GameFactory {
        public static RoleEntity CreateRole(GameContext ctx, Vector3 pos, int typeID, Ally ally) {
            bool has = ctx.tempCtx.RoleTM_Tryget(typeID, out RoleTM tM);
            if (!has) {
                Debug.Log($"Factory.CreateRole:{typeID} not found");
            }
            ctx.infraCtx.Entity_Tryget(typeof(RoleEntity).Name, out GameObject prefab);
            var role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
            role.Ctor();
            role.Set_Pos(pos);
            role.ally = ally;
            role.typeID = typeID;
            role.entityID = ctx.iDService.roleRecord++;
            role.moveSpeed = tM.moveSpeed;
            role.hp = tM.hpMax;
            role.hpMax = tM.hpMax;
            role.moveType = tM.moveType;
            role.searchRange = tM.searchRange;
            return role;
        }

        public static LootEntity CreateLoot(GameContext ctx, Vector3 pos, int typeID) {
            bool has = ctx.tempCtx.LootTM_Tryget(typeID, out var tM);
            if (!has) {
                Debug.Log($"Factory.CreateLoot:{typeID} not found");
            }
            ctx.infraCtx.Entity_Tryget(typeof(LootEntity).Name, out GameObject prefab);
            var loot = GameObject.Instantiate(prefab).GetComponent<LootEntity>();
            loot.Ctor();
            loot.SetPos(pos);
            loot.typeId = typeID;
            loot.lootName = tM.lootName;
            loot.id = ctx.iDService.lootRecord++;
            loot.meshFilter.mesh = tM.mesh;
            loot.mr.material = tM.material;
            return loot;
        }
    }
}
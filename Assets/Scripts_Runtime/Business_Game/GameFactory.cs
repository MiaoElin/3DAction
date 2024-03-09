using UnityEngine;
namespace Act {
    public static class GameFactory {
        public static RoleEntity CreateRole(GameContext ctx, Vector3 pos, int typeID, Ally ally) {
            bool has = ctx.tempCtx.RoleTM_Tryget(typeID, out RoleTM tM);
            if (!has) {
                Debug.Log($"Factory.CreateRole:{typeID} not found");
            }
            ctx.infraCtx.Entity_Tryget("Role", out GameObject prefab);
            var role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
            role.Ctor();
            role.Set_Pos(pos);
            role.typeID = typeID;
            role.entityID = ctx.iDService.RoleRecord++;
            role.moveSpeed = tM.moveSpeed;
            role.moveType = tM.moveType;
            return role;
        }
    }
}
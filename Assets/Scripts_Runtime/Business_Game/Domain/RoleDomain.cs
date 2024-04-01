using UnityEngine;

namespace Act {
    public static class RoleDomain {
        public static RoleEntity Spawn(GameContext ctx, int typeID, Vector3 pos, Ally ally) {
            var role = GameFactory.CreateRole(ctx, pos, typeID, ally);
            ctx.roleRepo.Add(role);
            return role;
        }
        public static void Move(GameContext ctx, RoleEntity role, float dt) {
            if (role.moveType == moveType.ByInput) {
                Vector3 dir = ctx.inputEntity.moveAxis;
                role.Move(dir, dt);
            }
        }
        public static void Falling(RoleEntity role, float dt) {
            role.Falling(dt);

        }

        public static void Jump(RoleEntity role,bool isJumpKeyDown) {
            if (role.ally == Ally.Player) {
                role.Jump(isJumpKeyDown);
            }
        }


    }
}
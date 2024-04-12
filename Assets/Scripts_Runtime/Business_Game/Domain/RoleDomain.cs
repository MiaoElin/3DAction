using UnityEngine;

namespace Act {
    public static class RoleDomain {
        public static RoleEntity Spawn(GameContext ctx, int typeID, Vector3 pos, Ally ally) {
            var role = GameFactory.CreateRole(ctx, pos, typeID, ally);
            ctx.roleRepo.Add(role);
            UIApp.HUD_HpBar_Open(ctx.uICtx, role.entityID, role.hpMax);
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

        public static void Jump(RoleEntity role, bool isJumpKeyDown) {
            if (role.ally == Ally.Player) {
                role.Jump(isJumpKeyDown);
            }
        }

        // roleHp_Bar
        public static void HUD_HpBar_Update(GameContext ctx, RoleEntity role) {
            UIApp.HUD_HpBar_Update(ctx.uICtx, role.entityID, role.hp, role.Get_Pos(), GameConst.ROLE_HEADOFFSET, ctx.cameraEntity.GetForward());
        }

        // 
        public static void PickNearlyLoot(GameContext ctx, RoleEntity owner) {

            Vector3 pos = owner.Get_Pos();
            float radius = owner.searchRange;
            float nearlyDistance = radius * radius;
            LootEntity nearlyLoot = null;

            int lootLen = ctx.lootRepo.TakeAll(out var loots);
            for (int i = 0; i < lootLen; i++) {
                var loot = loots[i];

                // 判定loot是否在搜索范围内
                bool isInRange = PFMath.IsInRange(loot.GetPos(), pos, radius, out var distance);
                if (isInRange) {

                    // 在范围内显示采集信号
                    UIApp.Panel_LootSignal_Open(ctx.uICtx, loot.id, loot.lootName, loot.GetPos());
                    if (distance <= nearlyDistance) {
                        nearlyDistance = distance;
                    }
                    nearlyLoot = loot;

                } else {
                    // 不在范围内隐藏采集信号
                    UIApp.Panel_LootSignal_Hide(ctx.uICtx, loot.id);
                }
            }
            PickStuff(ctx, owner, nearlyLoot);

        }

        public static void PickStuff(GameContext ctx, RoleEntity owner, LootEntity nearlyLoot) {
            if (nearlyLoot != null) {
                if (owner.isAllowPick) {
                    Debug.Log("in");
                    // 生成Stuff，添加进RoleStuffComponent、
                    //==== todo === 生成多个的情况待解决 ， 生成一个stuff数组；
                    var stuff = GameFactory.CreateStuffModel(ctx, nearlyLoot.typeID, nearlyLoot.stuffCount);
                    bool allpick = owner.stuffCom.IsAdd(stuff, stuff.count, out int overCount);
                    if (allpick) {
                        // 销毁loot，Panel_LootSignal
                        ctx.lootRepo.Remove(nearlyLoot);
                        nearlyLoot.Destroy();
                        UIApp.Panel_LootSignal_Close(ctx.uICtx, nearlyLoot.id);
                    } else {
                        Debug.Log("背包满了");
                        if (overCount < stuff.count) {
                            // 装了一点进去了
                            // todo 修改loot的stuffcount；
                        }
                    }
                }
            }
        }

    }
}
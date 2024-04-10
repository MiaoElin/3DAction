using System;
using UnityEngine;

namespace Act {
    public static class GameBusiness {
        public static void EnterGame(GameContext ctx) {
            // 生成owner
            var owner = RoleDomain.Spawn(ctx, 100, new Vector3(0, 6, 0), Ally.Player);
            ctx.playerEntity.OwnerEntityID = owner.entityID;
            
            // 生成LootEntity
            LootDomain.Spawn(ctx, 100, new Vector3(1, 0, 0));
            LootDomain.Spawn(ctx, 100, new Vector3(1, 0, 1));
            LootDomain.Spawn(ctx, 101, new Vector3(2, 0, 2));
            LootDomain.Spawn(ctx, 101, new Vector3(2, 0, 1));
            
            //  进入游戏循环主体
            var game = ctx.gameEntity;
            game.status = GameStatus.InGame;
        }
        public static void Tick(GameContext ctx, float dt) {
            var game = ctx.gameEntity;
            if (game.status == GameStatus.InGame) {
                InGame_Tick(ctx, dt);
            }
        }
        public static void FixedTick(GameContext ctx, float fixdt) {
            var game = ctx.gameEntity;
            if (game.status == GameStatus.InGame) {
                InGame_FixedTick(ctx, fixdt);
            }
        }

        private static void InGame_FixedTick(GameContext ctx, float fixdt) {
            int roleLen = ctx.roleRepo.TakeAll(out RoleEntity[] roles);
            for (int i = 0; i < roleLen; i++) {
                var role = roles[i];
                role.Set_lastPos(role.Get_Pos());
                RoleDomain.Move(ctx, role, fixdt);
                RoleDomain.Falling(role, fixdt);
                RoleDomain.Jump(role, ctx.inputEntity.isJumpKeyDown);
                RoleDomain.HUD_HpBar_Update(ctx, role);
            }
            ctx.cameraEntity.Tick(ctx.inputEntity.mouseWheel, fixdt);
        }

        public static void LateTcik(GameContext ctx, float dt) {
            var game = ctx.gameEntity;
            if (game.status == GameStatus.InGame) {
                InGame_LateTick(ctx, dt);
            }
        }
        public static void InGame_Tick(GameContext ctx, float dt) {

        }
        private static void InGame_LateTick(GameContext ctx, float dt) {
            var owner = ctx.GetOwner();

            // ctx.cameraEntity.GetMovedPosInSphere(mouseAxis.x, mouseAxis.y, owner.Get_Pos(), 10);
            ctx.cameraEntity.isCamera_VerticalMove = ctx.inputEntity.isCamera_VerticalMove;
            ctx.cameraEntity.isCamera_HorizonalRound = ctx.inputEntity.isCamera_HorizonalRound;

            ctx.cameraEntity.FollowSet(owner, ctx.inputEntity.MouseAxis, dt);
        }
    }

}
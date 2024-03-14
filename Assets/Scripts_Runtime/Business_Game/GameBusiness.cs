using System;
using UnityEngine;

namespace Act {
    public static class GameBusiness {
        public static void EnterGame(GameContext ctx) {
            var owner = RoleDomain.Spawn(ctx, 100, new Vector3(0, 0, 0), Ally.Player);
            ctx.playerEntity.OwnerEntityID = owner.entityID;
            var game = ctx.gameEntity;
            game.status = GameStatus.InGame;
        }
        public static void Tick(GameContext ctx, float fixdt) {
            var game = ctx.gameEntity;
            if (game.status == GameStatus.InGame) {
                InGame_Tick(ctx, fixdt);
            }
        }
        public static void LateTcik(GameContext ctx) {
            var game = ctx.gameEntity;
            if (game.status == GameStatus.InGame) {
                InGame_LateTick(ctx);
            }
        }
        public static void InGame_Tick(GameContext ctx, float fixdt) {
            int roleLen = ctx.roleRepo.TakeAll(out RoleEntity[] roles);
            for (int i = 0; i < roleLen; i++) {
                var role = roles[i];
                role.Set_lastPos(role.Get_Pos());
                RoleDomain.Move(ctx, role, fixdt);
            }
            ctx.cameraEntity.Tick(ctx.inputEntity.mouseWheel, fixdt);
        }
        private static void InGame_LateTick(GameContext ctx) {
            var owner = ctx.GetOwner();

            // ctx.cameraEntity.GetMovedPosInSphere(mouseAxis.x, mouseAxis.y, owner.Get_Pos(), 10);
            ctx.cameraEntity.isVertical = ctx.inputEntity.isVertical;
            ctx.cameraEntity.FollowSet(owner, ctx.inputEntity.left_MouseAxis);
        }
    }

}
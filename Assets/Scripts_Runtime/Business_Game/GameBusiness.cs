using System;
using UnityEngine;

namespace Act {
    public static class GameBusiness {
        public static void EnterGame(GameContext ctx) {
            var owner = RoleDomain.Spawn(ctx, 100, new Vector3(0, 5, 0), Ally.Player);
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
        public static void InGame_Tick(GameContext ctx, float fixdt) {
            int roleLen = ctx.roleRepo.TakeAll(out RoleEntity[] roles);
            for (int i = 0; i < roleLen; i++) {
                var role = roles[i];
                RoleDomain.Move(ctx, role, fixdt);
                // Debug.Log(role.rb.velocity + " " + role.transform.position);
            }
            var owner = ctx.GetOwner();
            ctx.cameraEntity.FollowSet(owner.Get_Pos());
        }
    }

}
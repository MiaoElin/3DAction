using UnityEngine;
namespace Act {
    public static class LoginBusiness {
        public static void Enter(LoginContext ctx) {
            UIApp.Panel_Login_Open(ctx.uiCtx);
        }
        public static void Close(LoginContext ctx) {
            UIApp.Panel_Login_Close(ctx.uiCtx);
        }
        public static void ExitGame(LoginContext ctx) {
            Close(ctx);
            Application.Quit();
            Debug.Log("退出游戏");
        }

        public static void Tick(LoginContext ctx) {
            UIApp.Panel_Login_Tick(ctx.uiCtx);
        }
    }
}
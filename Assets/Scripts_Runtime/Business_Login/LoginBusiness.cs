using UnityEngine;
namespace Act {
    public static class LoginBusiness {
        public static void Enter(UIContext ctx) {
            UIApp.Panel_Login_Open(ctx);
        }
        public static void Close(UIContext ctx) {
            UIApp.Panel_Login_Close(ctx);
        }
        public static void ExitGame(UIContext ctx) {
            Close(ctx);
            Application.Quit();
            Debug.Log("退出游戏");
        }

        public static void Tick(UIContext ctx) {
            UIApp.Panel_Login_Tick(ctx);
        }
    }
}
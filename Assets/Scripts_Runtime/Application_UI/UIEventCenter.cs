using System;
using UnityEngine;
namespace Act.UI {
    public class UIEventCenter {
        // Login
        public Action Login_OnStarGame;
        public void Login_StarGame() {
            Login_OnStarGame.Invoke();
        }
        public Action Login_OnExitGame;
        public void Login_ExitGame() {
            Login_OnExitGame.Invoke();
        }
    }
}
using System;
namespace Act {
    public class Event {
        public Action OnExitGame;
        public void ExitGame() {
            OnExitGame.Invoke();
        }
    }
}
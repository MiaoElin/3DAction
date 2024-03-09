using UnityEngine;
namespace Act {
    public class MainContext {
        // public Camera mainCamera;
        public UIContext uICtx;
        public GameContext gameCtx;
        public MainContext() {
            uICtx = new UIContext();
        }
        public void Inject(Canvas canvas) {
            uICtx.Inject(canvas);
        }
    }
}
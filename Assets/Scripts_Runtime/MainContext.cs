using UnityEngine;
namespace Act {
    public class MainContext {
        // public Camera mainCamera;
        public UIContext uiCtx;
        public GameContext gameCtx;
        public inputEntity inputEntity;
        public TemplateContext tempCtx;
        public AssetContext assetCtx;
        public LoginContext loginCtx;
        public SoundCoreContext soundCtx;
        public MainContext() {
            uiCtx = new UIContext();
            inputEntity = new inputEntity();
            tempCtx = new TemplateContext();
            gameCtx = new GameContext();
            assetCtx = new AssetContext();
            loginCtx = new LoginContext();
            soundCtx = new SoundCoreContext();
        }
        public void Inject(Canvas screenCanvas, Canvas worldCanvas, Camera camera) {
            uiCtx.Inject(screenCanvas, worldCanvas, soundCtx);
            gameCtx.Inject(inputEntity, tempCtx, assetCtx, uiCtx, camera);
            loginCtx.Inject(uiCtx, soundCtx);
        }
    }
}
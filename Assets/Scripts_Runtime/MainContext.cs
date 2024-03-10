using UnityEngine;
namespace Act {
    public class MainContext {
        // public Camera mainCamera;
        public UIContext uICtx;
        public GameContext gameCtx;
        public inputEntity inputEntity;
        public TemplateContext tempCtx;
        public InfraAssetContext infraCtx;
        public MainContext() {
            uICtx = new UIContext();
            inputEntity = new inputEntity();
            tempCtx = new TemplateContext();
            gameCtx = new GameContext();
            infraCtx = new InfraAssetContext();
        }
        public void Inject(Canvas canvas, Camera camera) {
            uICtx.Inject(canvas);
            gameCtx.Inject(inputEntity, tempCtx, infraCtx, camera);
        }
    }
}
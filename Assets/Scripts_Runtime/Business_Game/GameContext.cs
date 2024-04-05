using UnityEngine;
namespace Act {
    public class GameContext {
        public inputEntity inputEntity;
        public TemplateContext tempCtx;
        public InfraAssetContext infraCtx;
        public UIContext uICtx;
        public IDService iDService;
        public RoleRepo roleRepo;
        public GameEntity gameEntity;
        public CameraEntity cameraEntity;
        public PlayerEntity playerEntity;

        public GameContext() {
            iDService = new IDService();
            roleRepo = new RoleRepo();
            gameEntity = new GameEntity();
            cameraEntity = new CameraEntity();
            playerEntity = new PlayerEntity();
        }
        public void Inject(inputEntity inputEntity, TemplateContext tempCtx, InfraAssetContext infraCtx, UIContext uICtx, Camera camera) {
            this.inputEntity = inputEntity;
            this.tempCtx = tempCtx;
            this.infraCtx = infraCtx;
            this.uICtx = uICtx;
            cameraEntity.camera = camera;
            cameraEntity.Ctor();
        }
        public RoleEntity GetOwner() {
            roleRepo.Tryget(playerEntity.OwnerEntityID, out RoleEntity role);
            return role;
        }
    }
}
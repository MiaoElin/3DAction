using UnityEngine;
namespace Act {
    public class GameContext {
        // === Context ===
        public TemplateContext tempCtx;
        public AssetContext assetCtx;
        public UIContext uICtx;

        public IDService iDService;

        // === Repository ===
        public RoleRepo roleRepo;
        public LootRepo lootRepo;

        // === Entity ===
        public inputEntity inputEntity;
        public GameEntity gameEntity;
        public CameraEntity cameraEntity;
        public PlayerEntity playerEntity;

        public GameContext() {
            iDService = new IDService();
            roleRepo = new RoleRepo();
            lootRepo = new LootRepo();
            gameEntity = new GameEntity();
            cameraEntity = new CameraEntity();
            playerEntity = new PlayerEntity();
        }
        public void Inject(inputEntity inputEntity, TemplateContext tempCtx, AssetContext assetCtx, UIContext uICtx, Camera camera) {
            this.inputEntity = inputEntity;
            this.tempCtx = tempCtx;
            this.assetCtx = assetCtx;
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
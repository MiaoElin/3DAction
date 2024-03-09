namespace Act {
    public class GameContext {
        public inputEntity inputEntity;
        public int OwnerEntityID;
        public TemplateContext tempCtx;
        public InfraAssetContext infraCtx;
        public IDService iDService;
        public RoleRepo roleRepo;
        public GameEntity gameEntity;
        public GameContext() {
            iDService = new IDService();
            roleRepo = new RoleRepo();
            gameEntity = new GameEntity();
        }
        public void Inject(inputEntity inputEntity, TemplateContext tempCtx, InfraAssetContext infraCtx) {
            this.inputEntity = inputEntity;
            this.tempCtx = tempCtx;
            this.infraCtx = infraCtx;
        }
        // public RoleEntity GetOwner() {

        // }
    }
}
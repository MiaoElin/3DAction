namespace Act {

    public class LoginContext {

        public UIContext uiCtx;
        public SoundCoreContext soundCtx;

        public void Inject(UIContext uiCtx, SoundCoreContext soundCtx) {
            this.uiCtx = uiCtx;
            this.soundCtx = soundCtx;
        }
    }
}
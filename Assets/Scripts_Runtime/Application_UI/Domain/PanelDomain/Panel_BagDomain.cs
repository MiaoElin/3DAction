namespace Act {

    public static class Panel_BagDomain {
        public static void Open(UIContext ctx, StuffComponent stuffCom) {
            var panel = ctx.openedUI_TryGet<Panel_Bag>();
            if (panel == null) {
                panel = UIFactory.UI_Create<Panel_Bag>(ctx);
                panel.Ctor();
            }
            stuffCom.Foreach((stuff) => {
                if (stuff != null) {
                    panel.Init(stuff.index, stuff.id, stuff.sprite, stuff.count);
                }
            });
            panel.Show();


            SoundCore.OpenBagPlayer(ctx.soundCtx, panel.clip);

        }

        public static void Init(UIContext ctx, StuffComponent stuffCom) {
            var panel = ctx.openedUI_TryGet<Panel_Bag>();
            if (panel == null) {
                return;
            }
            stuffCom.Foreach((stuff) => {
                if (stuff != null) {
                    panel.Init(stuff.index, stuff.id, stuff.sprite, stuff.count);
                }
            });
        }

        public static void Hide(UIContext ctx) {
            var panel = ctx.openedUI_TryGet<Panel_Bag>();
            panel?.Hide();

            SoundCore.OpenBagPlayer(ctx.soundCtx, panel.clip);
        }
    }
}
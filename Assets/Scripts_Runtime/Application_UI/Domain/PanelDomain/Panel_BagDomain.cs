namespace Act {

    public static class Panel_BagDomain {
        public static void Open(UIContext ctx, StuffComponent stuffCom) {
            var panel = ctx.openedUI_TryGet<Panel_Bag>();
            if (panel == null) {
                panel = UIFactory.UI_Create<Panel_Bag>(ctx);
                panel.Ctor();
            }
            panel.Init();
            panel.Show();
        }

        public static void Hide(UIContext ctx) {
            var panel = ctx.openedUI_TryGet<Panel_Bag>();
            panel?.Hide();
        }


    }
}
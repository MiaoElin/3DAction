namespace Act {

    public static class PanelBagDomain {
        public static void Open(UIContext ctx) {
            var panel = ctx.openedUI_TryGet<Panel_Bag>();
            if (panel == null) {
                panel = UIFactory.UI_Create<Panel_Bag>(ctx);
                panel.Ctor();
            }
            panel.Init();

        }
    }
}
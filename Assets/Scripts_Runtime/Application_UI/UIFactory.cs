using UnityEngine;
namespace Act {
    public static class UIFactory {
        public static T Panel_Open<T>(UIContext ctx) where T : MonoBehaviour {
            string name = typeof(T).Name;
            var has = ctx.UI_TrygetValue(name, out GameObject prefab);
            var panel = GameObject.Instantiate(prefab, ctx.panelCanvas.transform).GetComponent<T>();
            ctx.openedUI_Add(name, panel);
            return panel;
        }
    }
}

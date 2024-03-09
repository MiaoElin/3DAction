using System.Collections.Generic;
using UnityEngine;
using Act.UI;
namespace Act {
    public class UIContext {
        Dictionary<string, GameObject> uIDict;
        Dictionary<string, MonoBehaviour> openedUIDict;
        public UIEventCenter uIEvent;
        public Canvas panelCanvas;

        public UIContext() {
            uIDict = new Dictionary<string, GameObject>();
            openedUIDict = new Dictionary<string, MonoBehaviour>();
            uIEvent = new UIEventCenter();
        }
        public void Inject(Canvas canvas) {
            panelCanvas = canvas;
        }
        // ui
        public void UI_Add(string name, GameObject gameObject) {
            uIDict.Add(name, gameObject);
        }

        public void UI_Remove(string name) {
            uIDict.Remove(name);
        }
        public bool UI_TrygetValue(string name, out GameObject value) {
            return uIDict.TryGetValue(name, out value);
        }
        // openedUI 
        public void openedUI_Add(string name, MonoBehaviour gameObject) {
            openedUIDict.Add(name, gameObject);
        }
        public void openedUI_Remove(string name) {
            openedUIDict.Remove(name);
        }
        public bool openedUI_TryGet(string name, out MonoBehaviour value) {
            return openedUIDict.TryGetValue(name, out value);
        }
    }
}
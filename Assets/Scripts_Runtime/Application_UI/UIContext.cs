using System.Collections.Generic;
using UnityEngine;
using Act.UI;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Act {

    public class UIContext {
        Dictionary<string, GameObject> uIDict;
        Dictionary<string, MonoBehaviour> openedUIDict;

        Dictionary<int, HUD_HpBar> hpBarDic; // HpBar有很多，要跟role的entityid对应
        Dictionary<int, Panel_LootSignal> lootSignalDic; // 角色附近的loot都会显示 与lootEntity对应唯一id；
        public UIEventCenter uIEvent;
        public Canvas screenCanvas;
        public Canvas worldCanvas;
        public AsyncOperationHandle uiPtr;

        public UIContext() {
            uIDict = new Dictionary<string, GameObject>();
            openedUIDict = new Dictionary<string, MonoBehaviour>();
            uIEvent = new UIEventCenter();
            hpBarDic = new Dictionary<int, HUD_HpBar>();
            lootSignalDic = new Dictionary<int, Panel_LootSignal>();
        }
        public void Inject(Canvas screenCanvas, Canvas worldCanvas) {
            this.screenCanvas = screenCanvas;
            this.worldCanvas = worldCanvas;
        }

        // UI
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
        public void OpenedUI_Add(string name, MonoBehaviour gameObject) {
            openedUIDict.Add(name, gameObject);
        }

        public void openedUI_Remove(string name) {
            openedUIDict.Remove(name);
        }

        public T openedUI_TryGet<T>() where T : MonoBehaviour {
            openedUIDict.TryGetValue(typeof(T).Name, out MonoBehaviour comp);
            if (comp == null) {
                return null;
            }
            var panel = comp as T;
            return panel;
        }

        // hpBarDic
        public void HpBarDic_Add(int id, HUD_HpBar hpBar) {
            hpBarDic.Add(id, hpBar);
        }

        public void HpBarDic_Remove(int id) {
            hpBarDic.Remove(id);
        }

        public bool HpBarDic_Tryget(int id, out HUD_HpBar hUD_HpBar) {
            return hpBarDic.TryGetValue(id, out hUD_HpBar);
        }

        // LootSignalDic
        public void LootSignal_Add(int id, Panel_LootSignal lootSignal) {
            lootSignalDic.Add(id, lootSignal);
        }

        public void LootSignal_Remove(int id) {
            lootSignalDic.Remove(id);
        }

        public bool LootSignal_Tryget(int id, out Panel_LootSignal lootSignal) {
            return lootSignalDic.TryGetValue(id, out lootSignal);
        }

    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Act {

    public class Panel_LootSignal : MonoBehaviour {
        [SerializeField] Text lootNameTxt;
        [SerializeField] Image bg;
        Vector2 offset;

        public void Ctor(string lootName) {
            offset = new Vector2(0, 1);
            lootNameTxt.text = lootName;
            float txtWith = lootNameTxt.preferredWidth;
            bg.rectTransform.sizeDelta = new Vector2(txtWith + 20, bg.rectTransform.sizeDelta.y);
        }

        public void SetPos(Vector3 worldPos) {
            transform.position = Camera.main.WorldToScreenPoint(worldPos);
        }

        public void Close() {
            Destroy(gameObject);
        }
    }
}
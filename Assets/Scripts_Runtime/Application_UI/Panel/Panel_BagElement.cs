using System;
using UnityEngine;
using UnityEngine.UI;

namespace Act {

    public class Panel_BagElement : MonoBehaviour {
        public int id;
        public int count;
        [SerializeField] Image image;
        [SerializeField] Button btn;
        Action OnAddHandle;

        public void Ctor() {
            btn.onClick.AddListener(() => {
                OnAddHandle.Invoke();
            });
        }

        public void Init(int id, Sprite sprite, int count) {
            this.id = id;
            
            // 有东西才替换图片
            if (id != -1) {
                image.sprite = sprite;
            }
            this.count += count;

            // 有东西才显示数量
            if (count != 0) {
                btn.GetComponentInChildren<Text>().text = $"X{count}";
            }
        }
    }
}
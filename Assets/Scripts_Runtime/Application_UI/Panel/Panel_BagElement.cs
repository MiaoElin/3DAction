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
            // 不是空格才替换图片
            if (id != -1) {
                image.sprite = sprite;
            }
            this.count += count;
            btn.GetComponentInChildren<Text>().text = $"X{count}";
        }
    }
}
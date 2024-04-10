using System;
using UnityEngine;
using UnityEngine.UI;

namespace Act {

    public class Panle_BagElement {
        public int id;
        [SerializeField] Image image;
        [SerializeField] Button btn;
        Action OnAddHandle;

        public void Ctor() {
            btn.onClick.AddListener(() => {
                OnAddHandle.Invoke();
            });
        }

        public void Init(int id, Sprite sprite) {
            this.id = id;
            image.sprite = sprite;
        }
    }
}
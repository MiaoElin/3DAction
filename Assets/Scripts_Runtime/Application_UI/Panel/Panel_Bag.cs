using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Act {

    public class Panel_Bag : MonoBehaviour {
        [SerializeField] Text title;
        [SerializeField] Transform elementGroup;
        [SerializeField] GameObject prefab;
        List<Panel_BagElement> elements;
        Action<int> OnUseHandle;

        int elementsCount;

        public Panel_Bag() {
            elements = new List<Panel_BagElement>();
            elementsCount = GameConst.BAG_NORMAL_MAXSLOT;
        }

        internal void Ctor() {
            // 生成空的背包格子
            for (int i = 0; i < elementsCount; i++) {
                var ele = GameObject.Instantiate(prefab, elementGroup).GetComponent<Panel_BagElement>();
                ele.Ctor();
                ele.Init(-1, null, 0);
                elements.Add(ele);
            }
        }

        public void Init() {

        }

        public void Add() {

        }

        internal void Show() {
            gameObject.SetActive(true);
        }

        internal void Hide() {
            gameObject.SetActive(false);
        }


    }
}
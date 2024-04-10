using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Act {

    public class Panel_Bag : MonoBehaviour {
        [SerializeField] Text title;
        [SerializeField] Transform elementGroup;
        [SerializeField] GameObject prefab;
        List<Panle_BagElement> elements;
        Action<int> OnUseHandle;

        public Panel_Bag() {
            elements = new List<Panle_BagElement>();
        }

        internal void Ctor() {
            
        }

        // public void Add()

    }
}
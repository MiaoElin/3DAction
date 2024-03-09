using UnityEngine;
using System.Collections.Generic;

namespace Act {
    public class InfraAssetContext {
        Dictionary<string, GameObject> entityDict;
        public InfraAssetContext() {
            entityDict = new Dictionary<string, GameObject>();

        }
        public void UI_Add(GameObject gameObject) {
        }
    }
}

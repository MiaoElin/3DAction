using UnityEngine;
using System.Collections.Generic;

namespace Act {
    public class InfraAssetContext {
        Dictionary<string, GameObject> entityDict;
        public InfraAssetContext() {
            entityDict = new Dictionary<string, GameObject>();

        }
        public void Entity_Add(string name, GameObject gameObject) {
            entityDict.Add(name, gameObject);
        }
        public bool Entity_Tryget(string name, out GameObject value) {
            return entityDict.TryGetValue(name, out value);
        }
    }
}

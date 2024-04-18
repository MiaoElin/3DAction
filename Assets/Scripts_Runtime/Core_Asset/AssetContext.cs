using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Act {
    public class AssetContext {
        Dictionary<string, GameObject> entityDict;
        public AsyncOperationHandle entityPtr;

        public AssetContext() {
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
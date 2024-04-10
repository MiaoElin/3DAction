using System;
using UnityEngine;

namespace Act {

    public class LootEntity : MonoBehaviour {
        public int typeId;
        public int id;
        [SerializeField] public MeshRenderer mr;
        [SerializeField] public MeshFilter meshFilter;

        internal void Ctor() {
        }

        internal void SetPos(Vector3 pos) {
            transform.position = pos;
        }
    }
}
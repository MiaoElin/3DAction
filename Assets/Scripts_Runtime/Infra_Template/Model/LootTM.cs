using UnityEngine;

namespace Act {

    [CreateAssetMenu(fileName = "LootTM_", menuName = "TM/LootTM")]
    public class LootTM : ScriptableObject {
        public int typeID;
        public Mesh mesh;
        public Material material;
    }
}
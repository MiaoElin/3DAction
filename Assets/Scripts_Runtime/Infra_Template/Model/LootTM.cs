using UnityEngine;

namespace Act {

    [CreateAssetMenu(fileName = "LootTM_", menuName = "TM/LootTM")]
    public class LootTM : ScriptableObject {
        public int typeID;
        public string lootName;
        public int stuffCount;
        public Mesh mesh;
        public Material material;
    }
}
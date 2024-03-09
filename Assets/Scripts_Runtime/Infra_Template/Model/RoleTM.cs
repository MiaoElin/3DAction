using UnityEngine;
namespace Act {
    [CreateAssetMenu(fileName = "RoleTM_", menuName = "TM/RoleTM")]
    public class RoleTM : ScriptableObject {
        public int typeID;
        public float moveSpeed;
        public moveType moveType;
    }

}
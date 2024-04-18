using UnityEngine;

namespace Act {

    [CreateAssetMenu(fileName = "StuffTM", menuName = "TM/StuffTM")]
    public class StuffTM : ScriptableObject {
        public int typeID;
        public string stuffName;
        public Sprite sprite;
        public int maxCount;


        // 是否可回血
        public bool isReHp;
        public int reHp;

        // 是否可恢复活力值 vitality
        public bool isReVIT;
        public float reVITPercent;
    }
}
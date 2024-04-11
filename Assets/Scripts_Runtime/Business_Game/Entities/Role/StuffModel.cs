using UnityEngine;

namespace Act {
    
    public class StuffModel {

        public int id;
        public int typeID;
        public Sprite sprite;
        public int count;
        public int maxCount;

        // 是否可回血
        public bool isReHp;
        public int reHp;

        // 是否可恢复活力值 vitality
        public bool isReVIT;
        public float reVITPercent;

        public void Ctor(int id) {
            this.id = id;
        }
    }
}
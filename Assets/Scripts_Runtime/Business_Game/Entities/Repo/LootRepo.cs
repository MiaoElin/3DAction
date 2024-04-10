using System.Collections.Generic;

namespace Act {

    public class LootRepo {
        Dictionary<int, LootEntity> loots;
        LootEntity[] tempArray;
        public LootRepo() {
            loots = new Dictionary<int, LootEntity>();
            tempArray = new LootEntity[1000];
        }

        public void Add(LootEntity loot) {
            loots.Add(loot.id, loot);
        }

        public void Remove(LootEntity loot) {
            loots.Remove(loot.id);
        }

        public bool Tryget(int entityID, out LootEntity loot) {
            return loots.TryGetValue(entityID, out loot);
        }
        public int TakeAll(out LootEntity[] allloot) {
            if (loots.Count >= tempArray.Length) {
                tempArray = new LootEntity[loots.Count * 2];
            }
            loots.Values.CopyTo(tempArray, 0);
            allloot = tempArray;
            return loots.Count;
        }

    }
}
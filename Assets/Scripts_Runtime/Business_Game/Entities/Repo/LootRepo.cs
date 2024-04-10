using System.Collections.Generic;

namespace Act {

    public class LootRepo {
        Dictionary<int, LootEntity> loots;

        public LootRepo() {
            loots = new Dictionary<int, LootEntity>();
        }

        public void Add(LootEntity loot) {
            loots.Add(loot.id, loot);
        }

        public void Remove(LootEntity loot) {
            loots.Remove(loot.id);
        }

    }
}
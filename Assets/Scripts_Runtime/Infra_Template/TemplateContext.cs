using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Act {
    public class TemplateContext {
        Dictionary<int, RoleTM> roleTMs;
        public AsyncOperationHandle rolePtr;

        Dictionary<int, LootTM> lootTMs;
        public AsyncOperationHandle lootPtr;

        Dictionary<int, StuffTM> stuffTMs;
        public AsyncOperationHandle stuffPtr;
        
        public TemplateContext() {
            roleTMs = new Dictionary<int, RoleTM>();
            lootTMs = new Dictionary<int, LootTM>();
            stuffTMs = new Dictionary<int, StuffTM>();

        }

        // RoleTM
        public void RoleTM_Add(RoleTM tM) {
            roleTMs.Add(tM.typeID, tM);
        }

        public void RoleTM_Remove(RoleTM tM) {
            roleTMs.Remove(tM.typeID);
        }

        public bool RoleTM_Tryget(int typeID, out RoleTM tM) {
            return roleTMs.TryGetValue(typeID, out tM);
        }

        // lootTM
        public void LootTM_Add(LootTM tM) {
            lootTMs.Add(tM.typeID, tM);
        }

        public void LootTM_Remove(LootTM tM) {
            lootTMs.Remove(tM.typeID);
        }

        public bool LootTM_Tryget(int typeID, out LootTM tM) {
            return lootTMs.TryGetValue(typeID, out tM);
        }

        // stuffTM
        public void StuffTM_Add(StuffTM tM) {
            stuffTMs.Add(tM.typeID, tM);
        }

        public void StuffTM_Remove(StuffTM tM) {
            stuffTMs.Remove(tM.typeID);
        }

        public bool StuffTM_Tryget(int typeID, out StuffTM tM) {
            return stuffTMs.TryGetValue(typeID, out tM);
        }
    }
}
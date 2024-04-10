using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Act {
    public class TemplateContext {
        Dictionary<int, RoleTM> roleTMs;
        public AsyncOperationHandle rolePtr;

        Dictionary<int, LootTM> LootTMs;
        public AsyncOperationHandle lootPtr;
        public TemplateContext() {
            roleTMs = new Dictionary<int, RoleTM>();
            LootTMs=new Dictionary<int, LootTM> ();
        }
        public void RoleTM_Add(RoleTM tM) {
            roleTMs.Add(tM.typeID, tM);
        }
        public void RoleTM_Remove(RoleTM tM) {
            roleTMs.Remove(tM.typeID);
        }
        public bool RoleTM_Tryget(int typeID, out RoleTM tM) {
            return roleTMs.TryGetValue(typeID, out tM);
        }

        public void LootTM_Add(LootTM tM) {
            LootTMs.Add(tM.typeID, tM);
        }
        public void LootTM_Remove(LootTM tM) {
            LootTMs.Remove(tM.typeID);
        }
        public bool LootTM_Tryget(int typeID, out LootTM tM) {
            return LootTMs.TryGetValue(typeID, out tM);
        }

    }
}
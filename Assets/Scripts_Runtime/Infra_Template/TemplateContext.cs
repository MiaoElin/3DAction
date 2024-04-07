using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Act {
    public class TemplateContext {
        Dictionary<int, RoleTM> roleTMs;
        public AsyncOperationHandle ptr;
        public TemplateContext() {
            roleTMs = new Dictionary<int, RoleTM>();
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
    }
}
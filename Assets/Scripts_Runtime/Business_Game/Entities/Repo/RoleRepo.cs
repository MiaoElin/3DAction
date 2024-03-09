using System.Collections.Generic;
using UnityEngine;
namespace Act {
    public class RoleRepo {
        Dictionary<int, RoleEntity> all;
        RoleEntity[] tempArray;
        public RoleRepo() {
            all = new Dictionary<int, RoleEntity>();
            tempArray = new RoleEntity[1000];
        }
        public void Add(RoleEntity role) {
            all.Add(role.entityID, role);
        }
        public int TakeAll(out RoleEntity[] allRole) {
            if (all.Count >= tempArray.Length) {
                tempArray = new RoleEntity[all.Count * 2];
            }
            all.Values.CopyTo(tempArray, 0);
            allRole = tempArray;
            return all.Count;
        }
    }
}
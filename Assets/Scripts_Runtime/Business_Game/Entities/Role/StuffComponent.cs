using UnityEngine;
using System;
using System.Collections.Generic;

namespace Act {

    public class StuffComponent {
        StuffModel[] all;//这里的一个StuffModel 相当于一个格子，每个格子能装多少是有容量的
        //为什么不作为一个stuff添加进all，到了Panel_Bag再结算数量，放几个格子里？ 因为捡了东西要马上结算背包能不能放的下，而背包的更新是在打开的时候才init的；
        public int maxSlot;
        public StuffComponent() {
            maxSlot = GameConst.BAG_NORMAL_MAXSLOT;
            all = new StuffModel[maxSlot];
        }

        public void init(int maxSlot) {
            all = new StuffModel[maxSlot];
        }

        public bool IsAdd(StuffModel stuff, int count, out int overCount) {
            // 是否存在相同类型的
            for (int i = 0; i < all.Length; i++) {
                var old = all[i];
                if (old != null && old.typeID == stuff.typeID) {
                    int allowCount = old.maxCount - old.count;
                    if (allowCount >= count) {
                        // 允许装的数量大于要装的
                        old.count += count;
                        overCount = 0;
                        return true;
                    } else {
                        old.count = old.maxCount;
                        // 不够装，多出来的数量
                        count -= allowCount;
                        overCount = count;
                    }
                }
            }

            // 旧格子没有该类型、不够装，要找个空的格子放 → 是否要考虑这次新的格子还不够装的情况？
            int index = -1;
            if (count > 0) {
                for (int i = 0; i < all.Length; i++) {
                    var stu = all[i];
                    // 有空的格子
                    if (stu == null) {
                        index = i;
                        break;
                    }
                }
                if (index != -1) {
                    all[index] = stuff;
                    stuff.count = count;
                    overCount = 0;
                    return true;
                }

                // 没空格子
                overCount = count;
                return false;

            } else {
                overCount = 0;
                return false;
            }
        }

        public void Foreach(Action<StuffModel> action) {
            foreach (var stuff in all) {
                action.Invoke(stuff);
            }
        }
    }
}
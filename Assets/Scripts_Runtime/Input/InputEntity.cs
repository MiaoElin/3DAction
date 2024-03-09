using System;
using UnityEngine;
using System.Collections.Generic;
namespace Act {
    public class inputEntity {
        public Vector3 moveAxis;
        public Vector3 mouseScreenPos;
        public Vector3 mouseWorldPos;
        public InputKey inputKey;
        Dictionary<InputKey, KeyCode[]> keyboardBindDic;
        public inputEntity() {
            keyboardBindDic = new Dictionary<InputKey, KeyCode[]>();
        }
        public void KeyboarBind(InputKey inputKey, KeyCode[] codes) {
            bool has = keyboardBindDic.TryAdd(inputKey, codes);
            if (!has) {
                keyboardBindDic[inputKey] = codes;
            }
        }
        public void Init() {
            KeyboarBind(InputKey.Up, new KeyCode[] { KeyCode.W, KeyCode.UpArrow });
            KeyboarBind(InputKey.Down, new KeyCode[] { KeyCode.S, KeyCode.DownArrow });
            KeyboarBind(InputKey.Left, new KeyCode[] { KeyCode.A, KeyCode.LeftArrow });
            KeyboarBind(InputKey.Right, new KeyCode[] { KeyCode.D, KeyCode.RightArrow });
            KeyboarBind(InputKey.Jump, new KeyCode[] { KeyCode.Space });
        }
        public void Process() {
            moveAxis = Vector3.zero;
            if (IsKeyPress(InputKey.Up)) {
                moveAxis.z = 1;
            }
            if (IsKeyPress(InputKey.Down)) {
                moveAxis.z = -1;
            }
            if (IsKeyPress(InputKey.Left)) {
                moveAxis.x = -1;
            }
            if (IsKeyPress(InputKey.Right)) {
                moveAxis.x = 1;
            }
        }

        public bool IsKeyPress(InputKey key) {
            keyboardBindDic.TryGetValue(key, out KeyCode[] codes);
            foreach (var kc in codes) {
                if (kc == default) {
                    continue;
                }
                if (Input.GetKey(kc)) {
                    return true;
                }
            }
            return false;
        }
        public bool IsKeyDown(InputKey key) {
            keyboardBindDic.TryGetValue(key, out KeyCode[] codes);
            foreach (var kc in codes) {
                if (kc == default) {
                    continue;
                }
                if (Input.GetKeyDown(kc)) {
                    return true;
                }
            }
            return false;
        }
    }
}
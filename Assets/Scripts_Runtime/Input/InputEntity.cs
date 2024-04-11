using System;
using UnityEngine;
using System.Collections.Generic;
namespace Act {
    public class inputEntity {
        // roleInput
        public bool isJumpKeyDown;
        public Vector3 moveAxis;
        public bool isAllowPick;


        public Vector3 mouseScreenPos;
        public Vector3 mouseWorldPos;
        public float mouseWheel;
        public InputKey inputKey;
        Dictionary<InputKey, KeyCode[]> keyboardBindDic;

        // CameraInput
        public Vector2 MouseAxis;
        public bool isCamera_VerticalMove;
        public bool isCamera_HorizonalRound;
        public bool isMouseRightPress;


        public inputEntity() {
            keyboardBindDic = new Dictionary<InputKey, KeyCode[]>();
            isJumpKeyDown = false;
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
        public void Process(Vector3 forward, Vector3 right) {

            // moveAxis
            moveAxis = Vector3.zero;
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();
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

            if (moveAxis.z != 0) {
                isCamera_VerticalMove = true;
            } else {
                isCamera_VerticalMove = false;
            }

            moveAxis = forward * moveAxis.z + right * moveAxis.x;

            // isMouseRightDown
            // 0 表示左按钮,1 表示右按钮,2 表示中间按钮
            isMouseRightPress = Input.GetMouseButton(1);

            if (isMouseRightPress) {
                // 按下相机就移
                isCamera_HorizonalRound = false;
            } else {
                // 没按下相机就转
                isCamera_HorizonalRound = true;
            }

            // mouseAxis
            MouseAxis = Vector2.zero;
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) {
                MouseAxis.x = Input.GetAxis("Mouse X");
                MouseAxis.y = Input.GetAxis("Mouse Y");
            }

            // mouseWheel
            mouseWheel = Input.GetAxis("Mouse ScrollWheel");

            // isJumpKeyDown
            if (Input.GetKeyDown(KeyCode.Space)) {
                isJumpKeyDown = true;
            } else {
                isJumpKeyDown = false;
            };

            // isAllowPick
            // if(inputKeyd)
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
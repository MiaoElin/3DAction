using System;
using UnityEngine;
namespace Act {
    public class CameraEntity {

        public Camera camera;
        Vector3 cameraPos;
        public Vector3 offset;
        public float angelX;
        public float angelY;
        public bool isCamera_VerticalMove;
        public bool isCamera_HorizonalRound;
        public float distance;
        public float mouseWheelSpeed;

        public CameraEntity() {
            angelX = 0;
            angelY = 30;
            isCamera_VerticalMove = false;
            isCamera_HorizonalRound = true;
            mouseWheelSpeed = 150;
        }
        public void Ctor() {
            offset = camera.transform.position;
            cameraPos = camera.transform.position;
            distance = Vector3.Distance(camera.transform.position, Vector3.zero);
        }
        public void LookAT(Vector3 target) {
            // camera.transform.LookAt(target);
            camera.transform.forward = target - camera.transform.position;

        }
        public void Tick(float mouseWheel, float dt) {
            distance -= mouseWheel * mouseWheelSpeed * dt;
            distance = Mathf.Clamp(distance, 3, 20);
        }
        public void GetMovedPosInSphere(float xOffset, float yOffset, Vector3 centerPos, float radius) {
            angelY = (angelY + yOffset * 2);
            angelX = (angelX + xOffset * 2) % 360;
            angelY = Mathf.Clamp(angelY, 0, 90);
            float dy = Mathf.Cos(angelY * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(angelY * Mathf.Deg2Rad) * radius;
            float z = Mathf.Cos(angelX * Mathf.Deg2Rad) * dy;
            float x = MathF.Sin(angelX * Mathf.Deg2Rad) * dy;
            Debug.Log(z);
            camera.transform.position = centerPos + new Vector3(x, y, -z);
            LookAT(centerPos);
        }

        public void FollowSet(RoleEntity owner, Vector2 mouseAxis, float dt) {
            var targetPos = Vector3.zero;
            if (isCamera_VerticalMove || !isCamera_HorizonalRound) {
                targetPos = owner.Get_LastPos();
            } else {
                targetPos = owner.Get_Pos();
            }
            mouseAxis = mouseAxis * dt;
            mouseAxis *= 1000;
            mouseAxis.y *= -1;
            var rotation = camera.transform.eulerAngles;
            // 0 < rotation.x + mouseAxis.y < 90
            // 0 < rotation.y + mouseAxis.x < 360
            // mouseAxis.x = Mathf.Clamp(mouseAxis.x, -rotation.y, 360 - rotation.y);
            // mouseAxis.y = Mathf.Clamp(mouseAxis.y, -rotation.x,90-rotation.y);
            var dir = (cameraPos - targetPos).normalized;
            if (mouseAxis.y > -rotation.x && mouseAxis.y < 90 - rotation.x && mouseAxis.y != 0) {
                Quaternion yRot = Quaternion.AngleAxis(mouseAxis.y, camera.transform.right);
                dir = yRot * dir;
            }
            Quaternion xRot = Quaternion.AngleAxis(mouseAxis.x, Vector3.up);
            dir = xRot * dir;
            dir *= distance;
            offset = dir;

            // Sine Wave
            // Phase 相位
            // float phase = 1;
            // Amplitude 振幅
            // float amplitude = 0.2f;
            // Frequency 振频
            // float frequency = 4f;
            // float sine = phase + Mathf.Sin(Time.time * frequency) * amplitude;
            // Vector3 shake = sine * Vector3.up;

            camera.transform.forward = -offset.normalized;
            cameraPos = owner.Get_Pos() + offset;
            camera.transform.position = cameraPos;




        }
    }
}
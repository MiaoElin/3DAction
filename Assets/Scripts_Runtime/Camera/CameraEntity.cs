using System;
using UnityEngine;
namespace Act {
    public class CameraEntity {
        public Camera camera;
        public Vector3 offset;
        public float angelX;
        public float angelY;
        public bool isVertical;
        public float distance;
        public float mouseWheelSpeed;
        public CameraEntity() {
            angelX = 0;
            angelY = 30;
            isVertical = false;
            mouseWheelSpeed = 10;
        }
        public void Ctor() {
            offset = camera.transform.position;
            distance = Vector3.Distance(camera.transform.position, Vector3.zero);
        }
        public void LookAT(Vector3 target) {
            // camera.transform.LookAt(target);
            camera.transform.forward = target - camera.transform.position;

        }
        public void Tick(float mouseWheel, float dt) {
            distance -= mouseWheel * mouseWheelSpeed;
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

        public void FollowSet(RoleEntity owner, Vector2 mouseAxis) {
            var targetPos = Vector3.zero;
            if (isVertical) {
                targetPos = owner.Get_LastPos();
            } else {
                targetPos = owner.Get_Pos();
            }
            mouseAxis *= 10;
            var rotation = camera.transform.eulerAngles;
            // 0 < rotation.x - mouseAxis.y < 90
            //  < rotation.y + mouseAxis.x < 360
            // mouseAxis.x = Mathf.Clamp(mouseAxis.x, -rotation.y, 360 - rotation.y);
            // mouseAxis.y = Mathf.Clamp(mouseAxis.y, rotation.x - 90, rotation.x);
            var dir = (camera.transform.position - targetPos).normalized;
            if (mouseAxis.y > rotation.x - 90 && mouseAxis.y < rotation.x && mouseAxis.y != 0) {
                Quaternion yRot = Quaternion.AngleAxis(-mouseAxis.y, camera.transform.right);
                dir = yRot * dir;
            } else {
            }
            if (mouseAxis.x > -rotation.y && mouseAxis.x < 360 - rotation.y && mouseAxis.x != 0) {
                Quaternion xRot = Quaternion.AngleAxis(mouseAxis.x, Vector3.forward);
                dir = xRot * dir;
            } else {
            }
            // dir = xRot * yRot * dir;
            dir *= distance;
            offset = dir;
            camera.transform.position = owner.Get_Pos() + offset;
            camera.transform.forward = (owner.Get_Pos() - camera.transform.position).normalized;

        }
    }
}
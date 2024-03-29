using System;
using UnityEngine;
namespace Act {
    public class RoleEntity : MonoBehaviour {
        public int entityID;
        public int typeID;
        public Ally ally;
        public moveType moveType;
        public Rigidbody rb;
        Vector3 lastPos;

        Vector3 oldForward;
        Vector3 startForward;
        Vector3 endForward;
        float time;
        float duration;

        // SpriteRenderer sr;
        public float moveSpeed;
        // public float 
        public bool isInGround;

        public RoleEntity() {
        }

        void OnCollisionEnter(Collision other) {
            if (other.gameObject.tag == "Ground") {
                isInGround = true;
            }
            // other.gameObject.GetComponent<TowerEntity>();
        }

        void OnCollisionStay(Collision other) {

        }

        void OnCollisionExit(Collision other) {
            if (other.gameObject.tag == "Ground") {
                isInGround = false;
            }
        }

        void OnTriggerEnter(Collider other) {

        }

        void OnTriggerStay(Collider other) {

        }

        void OnTriggerExit(Collider other) {

        }

        public void Ctor() {

            // Vector3 fwd = Vector3.forward; // (0, 0, 1) ↑
            // Vector3 right = Vector3.right; // (1, 0, 0) →
            // Vector3 normal = Vector3.Cross(fwd, right); // (0, 1, 0) 得到法线
            // Debug.Log("Normal: " + normal);

            // Vector3 leftUp = new Vector3(-100, 100, 0);
            // Vector3 rightDown = new Vector3(0, 0, 0);
            // Vector3 inDir = rightDown - leftUp;
            // Vector3 outDir = Vector3.Reflect(inDir, normal);
            // Debug.Log("OutDir: " + outDir);

            rb = GetComponentInChildren<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
        public void Set_FaceDir(Vector3 faceDir, float dt) {
            if (faceDir == Vector3.zero) {
                return;
            }
            // Vector3 startForward;
            // Vector3 endForward;
            // endForward = new Vector3(faceDir.x, 0, faceDir.z);
            // startForward = transform.forward;
            // if (oldForward != endForward) {
            //     time = 0;
            //     duration = 0.1f;
            // }
            // if (time <= duration) {
            //     time += dt;
            //     float t = time / duration;
            //     var startRot = Quaternion.LookRotation(startForward);
            //     var endRot = Quaternion.LookRotation(endForward);
            //     transform.rotation = Quaternion.Lerp(startRot, endRot, t);
            // }
            // // transform.forward = faceDir;


            // 根据正面进行旋转
            // old forward: (x0, y0, z1)
            // new forward: (moveAxis.x, 0, moveAxis.y)
            Vector3 newForward = new Vector3(faceDir.x, 0, faceDir.z).normalized;
            if (oldForward != newForward) {
                startForward = oldForward; // 缓动开始
                if (startForward == Vector3.zero) {
                    startForward = transform.forward;
                }
                endForward = newForward; // 缓动结束
                time = 0;
                duration = 0.25f;
                oldForward = newForward;
            }
            // transform.rotation = Quaternion.LookRotation(newForward);

            // 硬转
            // transform.forward = newForward;

            // 平滑转
            if (time <= duration) {
                time += dt;
                float t = time / duration;
                Quaternion startRot = Quaternion.LookRotation(startForward);
                Quaternion endRot = Quaternion.LookRotation(endForward);
                transform.rotation = Quaternion.Lerp(startRot, endRot, t);
            }


        }


        public void Set_Pos(Vector3 pos) {
            transform.position = pos;
        }
        public Vector3 Get_Pos() {
            return transform.position;
        }
        public Vector3 Get_LastPos() {
            return lastPos;
        }
        public void Set_lastPos(Vector3 pos) {
            lastPos = pos;
        }
        public void Move(Vector3 dir, float dt) {
            // if (dir == Vector3.zero) {
            //     rb.velocity = new Vector3(0, rb.velocity.y + Physics.gravity.y * dt, 0);
            //     return;
            // }
            Vector3 velo = rb.velocity;
            float y = velo.y;
            velo = dir.normalized * moveSpeed;
            velo.y = y;
            rb.velocity = velo;
            Set_FaceDir(dir, dt);
        }

        public void Falling(float dt) {
            if (isInGround) {
                var vel = rb.velocity;
                vel.y = 0;
                rb.velocity = vel;
                return;
            }
            Vector3 velo = rb.velocity;
            const float G = -9.81f;
            velo.y += G * dt;
            rb.velocity = velo;

        }

        public void Jump() {

        }

        public void Move_To(Vector3 targetPos, float dt) {
            if (targetPos == Vector3.zero) {
                return;
            }
            var dir = targetPos - Get_Pos();
            float constrainRange = moveSpeed * dt;
            // arrive
            if (dir.sqrMagnitude <= constrainRange * constrainRange) {
                rb.velocity = Vector3.zero;
                return;
            }
            rb.velocity = dir.normalized * moveSpeed * dt;
        }
    }
}
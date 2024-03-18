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
        public void Set_FaceDir(Vector3 faceDir) {
            transform.forward = faceDir;
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
            if (dir != Vector3.zero) {
                Set_FaceDir(dir);
            }
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

        public void Jump(){

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
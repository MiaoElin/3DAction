using System;
using UnityEngine;
namespace Act {
    public class RoleEntity : MonoBehaviour {
        public int entityID;
        public int typeID;
        public Ally ally;
        public moveType moveType;
        public Vector3 faceDir;

        // public Rigidbody rb;

        // SpriteRenderer sr;
        public float moveSpeed;

        public RoleEntity() {
        }
        public void Ctor() {
            // rb = GetComponentInChildren<Rigidbody>();
            // rb.velocity = Vector3.zero;
        }
        public void Set_FaceDir(Vector3 faceDir) {
            this.faceDir = faceDir;
        }


        public void Set_Pos(Vector3 pos) {
            transform.position = pos;
        }
        public Vector3 Get_Pos() {
            return transform.position;
        }
        public void Move(Vector3 dir, float dt) {

            transform.position += dir.normalized * moveSpeed * dt;
        }
        public void Move_To(Vector3 targetPos, float dt) {
            // if (targetPos == Vector3.zero) {
            //     return;
            // }
            // var dir = targetPos - Get_Pos();
            // float constrainRange = moveSpeed * dt;
            // // arrive
            // if (dir.sqrMagnitude <= constrainRange * constrainRange) {
            //     rb.velocity = Vector3.zero;
            //     return;
            // }
            // rb.velocity = dir.normalized * moveSpeed * dt;
        }
    }
}
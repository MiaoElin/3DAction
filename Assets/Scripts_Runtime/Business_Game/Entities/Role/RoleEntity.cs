using System;
using UnityEngine;

namespace Act {

    public class RoleEntity : MonoBehaviour {
        public int entityID;
        public int typeID;
        public Ally ally;
        public int hp;
        public int hpMax;
        public moveType moveType;
        public Rigidbody rb;
        public Animator animator;

        public float searchRange;


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
        public bool firtTimeInGround;

        // 跳；
        public bool isJumpKeyDown;
        float jumpForce;
        int jumpTimes;

        public StuffComponent stuffCom;
        public bool isAllowPick;

        public bool openBag;
        public bool isOpened;
        public RoleEntity() {
            stuffCom = new StuffComponent();
        }

        #region Collision
        void OnCollisionEnter(Collision other) {
            // if (other.gameObject.tag == "Ground") {
            //     var vel = rb.velocity;
            //     vel.y = 0;
            //     rb.velocity = vel;
            //     ResetJumpTimes();
            //     isInGround = true;
            // }
            // other.gameObject.GetComponent<TowerEntity>();
        }

        void OnCollisionStay(Collision other) {
            // if (other.gameObject.tag == "Ground") {
            //     if (!isInGround) {
            //         var vel = rb.velocity;
            //         vel.y = 0;
            //         rb.velocity = vel;
            //         ResetJumpTimes();
            //     }
            //     isInGround = true;
            // }
        }

        void OnCollisionExit(Collision other) {
            // if (other.gameObject.tag == "Ground") {
            //     isInGround = false;
            // }
        }

        void OnTriggerEnter(Collider other) {
            if (other.gameObject.tag == "Ground") {
                var vel = rb.velocity;
                vel.y = 0;
                rb.velocity = vel;
                ResetJumpTimes();
                isInGround = true;
            }
        }

        void OnTriggerStay(Collider other) {
            if (other.gameObject.tag == "Ground") {
                if (!isInGround) {
                    var vel = rb.velocity;
                    vel.y = 0;
                    rb.velocity = vel;
                    ResetJumpTimes();
                }
                isInGround = true;
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.gameObject.tag == "Ground") {
                isInGround = false;
            }
        }
        #endregion OnTriggerExit
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
            jumpForce = 5;
            jumpTimes = 1;
            isInGround = false;
        }
        public void Set_FaceDir(Vector3 faceDir, float dt) {

            // rb.angularVelocity = Vector3.zero; 可限制角速度对角色面向的影响
            // rb.angularVelocity = Vector3.up * 5;

            if (faceDir == Vector3.zero) {
                return;
            }

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

        void OnGUI() {
            GUILayout.Label("Angular: " + rb.angularVelocity);
        }

        // === SetPos ===
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

        // Move
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
            Anim_Run(dir);
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

        // === Falling ===
        public void Falling(float dt) {
            if (isInGround) {
                return;
            }
            Vector3 velo = rb.velocity;
            const float G = -9.81f;
            velo.y += G * dt;
            rb.velocity = velo;
            Anim_JumpAir();
        }

        // === Jump ===
        public void Jump(bool isJumpKeyDown) {
            if (isInGround && isJumpKeyDown && jumpTimes >= 1) {
                var vel = rb.velocity;
                vel.y += jumpForce;
                rb.velocity = vel;
                jumpTimes -= 1;
                // isInGround = false;
                Anim_JumpStart();
            }
        }

        public void ResetJumpTimes() {
            jumpTimes = 1;
            Anim_JumpEnd();
        }

        // === Animator ===
        // Run
        public void Anim_Run(Vector3 dir) {
            if (dir != Vector3.zero) {
                animator.SetFloat("F_MoveSpeed", rb.velocity.magnitude);
            } else {
                animator.SetFloat("F_MoveSpeed", 0);
            }
        }

        // Attack1
        public void Anim_Attack1() {
            animator.SetTrigger("T_Attack1");
        }

        public void Anim_JumpStart() {
            animator.SetTrigger("T_JumpStart");
        }

        public void Anim_JumpAir() {
            // animator.Play("JumpAir_Bow");
            animator.SetTrigger("T_JumpAir");
        }

        public void Anim_JumpEnd() {
            // animator.SetTrigger("T_JumpEnd");
            // animator.CrossFade("T_JumpEnd",0,0);
            animator.ResetTrigger("T_JumpAir");
            animator.Play("JumpEnd_Bow");
            // animator.SetBool("JumpEnd_Bow", true);
        }
    }
}
using System;
using UnityEngine;
namespace Act {
    public class CameraEntity {
        public Camera camera;
        public Vector3 offset;
        public CameraEntity() {
        }
        public void Ctor() {
            offset = camera.transform.position;
        }
        public void FollowSet(Vector3 targetPos) {
            camera.transform.position = targetPos + offset;
        }
    }
}
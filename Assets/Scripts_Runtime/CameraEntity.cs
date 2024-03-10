using System;
using UnityEngine;
namespace Act {
    public class CameraEntity {
        public Camera camera;
        public Vector3 offset;
        public CameraEntity() {
            offset = new Vector3(0, 9, -10);
        }
        // public void Init(Vector3 owenrPos)
        public void FollowSet(Vector3 targetPos) {
            camera.transform.position = targetPos + offset;
        }
    }
}
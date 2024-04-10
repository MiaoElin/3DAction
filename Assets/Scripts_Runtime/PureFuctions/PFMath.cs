using UnityEngine;

namespace Act {

    public static class PFMath {
        public static bool IsInRange(Vector3 pos1, Vector3 pos2, float radius) {
            return Vector3.SqrMagnitude(pos1 - pos2) <= (radius * radius);
        }
    }
}
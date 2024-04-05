using UnityEngine;
using UnityEngine.UI;

namespace Act {

    public class HUD_HpBar : MonoBehaviour {
        [SerializeField] Image hpBar;
        [SerializeField] Image hpBg;
        int hpMax;
        public void SetHpMax(int hpMax) {
            this.hpMax = hpMax;
        }

        public void Face(Vector3 forward) {
            transform.forward = forward;
        }

        public void Update_Tick(int hp, Vector3 pos, float headOffset,Vector3 forward) {
            // Hp
            if (hp <= 0) {
                Destroy(gameObject);
                return;
            }
            hpBar.fillAmount = hp / hpMax;

            // Pos 
            transform.position = pos + Vector3.up * headOffset;

            // Face
            Face(forward);
        }
    }
}
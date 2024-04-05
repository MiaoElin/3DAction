using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Act.UI {
    public class Panel_Login : MonoBehaviour {
        [SerializeField] Text titleTxt;
        [SerializeField] Button btn_Start;
        [SerializeField] Button btn_Setting;
        [SerializeField] Button btn_KeyboardBingding;
        [SerializeField] Button btn_JoystickBinding;
        [SerializeField] Button btn_Exit;
        public Action OnStartHandle;
        public Action OnSettingHandle;
        public Action OnKeyboardBindHandle;
        public Action OnJoystickBindHandle;
        public Action OnExitHandle;
        [SerializeField] VideoPlayer videoPlayer;
        public void Ctor() {
            btn_Start.onClick.AddListener(() => {
                OnStartHandle.Invoke();
            });
            btn_Exit.onClick.AddListener(() => {
                OnExitHandle.Invoke();
            });
        }

        public void VideoPlay() {
            videoPlayer.Play();
        }
    }
}
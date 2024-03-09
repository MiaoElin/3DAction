using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Act {
    public class ClientMain : MonoBehaviour {
        [SerializeField] Camera mainCamera;
        [SerializeField] Canvas panelCavas;
        MainContext ctx;
        // Start is called before the first frame update
        void Start() {
            ctx = new MainContext();
            ctx.Inject(panelCavas);
            BindEvent();
            Load();
            LoginBusiness.Enter(ctx.uICtx);
        }

        private void Load() {
            UIApp.LoadAll(ctx.uICtx);
        }

        private void BindEvent() {
            var uIEvent = ctx.uICtx.uIEvent;
            uIEvent.Login_OnStarGame += () => {
                LoginBusiness.Close(ctx.uICtx);
                // 进入游戏
                GameBusiness.EnterGame(ctx.gameCtx);
            };
            uIEvent.Login_OnExitGame += () => {
                LoginBusiness.ExitGame(ctx.uICtx);
            };
        }

        // Update is called once per frame
        void Update() {

        }
    }
}


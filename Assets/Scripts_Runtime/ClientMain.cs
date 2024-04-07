using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Act {
    public class ClientMain : MonoBehaviour {
        [SerializeField] Camera mainCamera;
        [SerializeField] Canvas screenCanvas;
        [SerializeField] Canvas worldCanvas;
        MainContext ctx;
        float restTime;
        bool isTearDown;

        // Start is called before the first frame update
        void Start() {

            isTearDown = false;

            ctx = new MainContext();

            // Inject
            ctx.Inject(screenCanvas, worldCanvas, mainCamera);

            // Binding
            BindEvent();

            // Load
            Load();

            // Iint
            ctx.inputEntity.Init();
            LoginBusiness.Enter(ctx.uICtx);
        }

        private void Load() {

            UIApp.LoadAll(ctx.uICtx);
            InfraTemplate.LoadAll(ctx.tempCtx);
            InfraAsset.LoadAll(ctx.infraCtx);
        }

        private void BindEvent() {

            var uIEvent = ctx.uICtx.uIEvent;

            // Login
            uIEvent.Login_OnStarGame += () => {
                LoginBusiness.Close(ctx.uICtx);
                // 进入游戏
                GameBusiness.EnterGame(ctx.gameCtx);
            };
            uIEvent.Login_OnExitGame += () => {
                // 退出游戏
                LoginBusiness.ExitGame(ctx.uICtx);
            };


        }

        // Update is called once per frame
        void Update() {

            // input
            ctx.inputEntity.Process(mainCamera.transform.forward, mainCamera.transform.right);

            float dt = Time.deltaTime;

            // Tick
            LoginBusiness.Tick(ctx.uICtx);
            GameBusiness.Tick(ctx.gameCtx, dt);

            // FixedTick
            restTime += dt;
            const float fixdt = 0.01f;
            if (dt <= fixdt) {
                FixedTick(fixdt);
                restTime = 0;
            } else {
                while (dt > fixdt) {
                    dt -= fixdt;
                    FixedTick(fixdt);
                }
            }

            // LateTick
            GameBusiness.LateTcik(ctx.gameCtx, dt);



        }
        void FixedTick(float fixdt) {

            // GameBusiness
            GameBusiness.FixedTick(ctx.gameCtx, fixdt);

            // Gravity 影响 velocity, velocity 影响 position
            // 速度 velocity m/s
            Physics.Simulate(fixdt);

        }
        void LateUpdate() {

        }

        void FixedUpdate() {
            // Auto Simulate
            // Physics.Simulate(dt);
        }

        void OnApplicationQuit() {
            Teardown();
        }

        void OnDestory() {
            Teardown();
        }

        void Teardown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;
            Unload();
        }

        private void Unload() {
            InfraAsset.Unload(ctx.infraCtx);
            UIApp.Unload(ctx.uICtx);
            InfraTemplate.Undoad(ctx.tempCtx);
        }

    }
}


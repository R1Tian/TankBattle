using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using QFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankBattle
{
    [MonoSingletonPath("[Singleton]/LevelManager")]
    public class LevelManager : NetworkSceneManagerBase, ISingleton
    {
        #region + Singleton
        public static LevelManager Instance => MonoSingletonProperty<LevelManager>.Instance;
        
        public void OnSingletonInit()
        {
            Debug.Log("LevelManager SingletonInit");
        }
        
        #endregion
        
        private int readyRoom = 2;
        private List<int> battlegroundList = new List<int>() { 3, 4 };
        
        private Scene loadedScene;


        protected override void Shutdown(NetworkRunner runner)
        {
            base.Shutdown(runner);

        }

        public void LoadLevel(int levelIndex)
        {
            Runner.SetActiveScene(levelIndex);
        }

        protected override IEnumerator SwitchScene(SceneRef prevScene, SceneRef newScene, FinishedLoadingDelegate finished)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
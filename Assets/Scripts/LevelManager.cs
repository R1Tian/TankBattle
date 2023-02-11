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
        
        public enum RoomIndex
        {
            ReadyRoom = 2,
            Arena1 = 3,
            Arena2 = 4
        }
        
        // private int readyRoom = RoomIndex.ReadyRoom;
        // private List<int> battlegroundList = new List<int>() { 3, 4 };
        
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
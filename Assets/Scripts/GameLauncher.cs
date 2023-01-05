using System;
using Fusion;
using QFramework;
using QFramework.TankBattle;
using UnityEngine;

namespace TankBattle
{
    public class GameLauncher : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            ResKit.Init();
        }

        private void Start()
        {
            OpenMainSceneUI();
        }

        private void OpenMainSceneUI()
        {
            UIMainScenePanelData uiMainScenePanelData = new UIMainScenePanelData
            {
                
            };
            UIKit.OpenPanel<UIMainScenePanel>(uiMainScenePanelData);
        }
        
    }
}
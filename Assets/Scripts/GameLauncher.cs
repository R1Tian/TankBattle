using Fusion;
using QFramework;
using QFramework.TankBattle;
using UnityEngine;

namespace TankBattle
{
    [MonoSingletonPath("[Singleton]/GameLauncher")]
    public class GameLauncher : MonoSingleton<GameLauncher>, IController
    {
        public IArchitecture GetArchitecture()
        {
            throw new System.NotImplementedException();
        }

        protected void Awake()
        {
            ResKit.Init();
            UIKit.Root.SetResolution(1920, 1080, 0);
        }

        private void Start()
        {
            OpenMainSceneUI();
            UIKit.OpenPanel<UILoadPanel>(UILevel.PopUI);
        }
        

        private void OpenMainSceneUI()
        {
            UIMainScenePanelData uiMainScenePanelData = new UIMainScenePanelData
            {
                joinLobbyFunc = FusionLauncher.Instance.JoinLobby,
                sessionLobbyType = SessionLobby.ClientServer,
                lobbyID = "DefaultLobby"
            };
            UIKit.OpenPanel<UIMainScenePanel>(uiMainScenePanelData);
        }
        
    }
}
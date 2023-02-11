using Fusion;
using QAssetBundle;
using QFramework;
using QFramework.TankBattle;
using UnityEngine;

namespace TankBattle
{
    [MonoSingletonPath("[Singleton]/GameLauncher")]
    public class GameLauncher : MonoSingleton<GameLauncher>, IController
    {
        private ResLoader resLoader = null;
        public ResLoader ResLoader
        {
            get
            {
                if (resLoader == null)
                {
                    resLoader = ResLoader.Allocate();
                }

                return resLoader;
            }
        }
        
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

        public void OnSpawnWorld(NetworkRunner runner)
        {
            Debug.Log("Spawn GameManager");

            GameObject gameManagerGO =
                ResLoader.LoadSync<GameObject>(Gamemanager_prefab.BundleName, Gamemanager_prefab.GAMEMANAGER);
            NetworkObject gameManager = runner.Spawn(gameManagerGO, Vector3.zero, Quaternion.identity, null, InitNetworkState);
            gameManager.name = "GameManager";
            
            void InitNetworkState(NetworkRunner runner, NetworkObject obj)
            {
                obj.transform.parent = transform.parent;
            }
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
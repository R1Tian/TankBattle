using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Fusion;
using Fusion.Sockets;
using QAssetBundle;
using QFramework;
using QFramework.TankBattle;
using TankBattle.FusionHelper;
using TankBattle.Lobby;
using UnityEngine;

namespace TankBattle
{
    public class FusionLauncher : ISingleton, INetworkRunnerCallbacks, IController
    {
        #region + ISingleton
        public static FusionLauncher Instance => SingletonProperty<FusionLauncher>.Instance;

        public void OnSingletonInit()
        {
            Debug.Log("FusionLauncher SingletonInit");
        }
        
        private FusionLauncher() {}
        
        #endregion

        #region + IController
        public IArchitecture GetArchitecture()
        {
            return LobbyArchitecture.Interface;
        }
        
        #endregion

        #region + Field
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
        
        private NetworkRunner networkRunner = null;
        public NetworkRunner NetworkRunner
        {
            get
            {
                if (networkRunner == null)
                {
                    networkRunner = NetworkCore.Instance.GetNetworkRunner();
                    networkRunner.ProvideInput = true;
                    networkRunner.AddCallbacks(this);
                }
                return networkRunner;
            }
            set
            {
                networkRunner = value;
            }
        }
        
        #endregion
        
        public async UniTaskVoid JoinLobby(SessionLobby sessionLobbyType, string lobbyID = null)
        {
            Debug.Log("[FusionLauncher] <JoinLobby> JoinSessionLobby Start");
            StartGameResult result = await NetworkRunner.JoinSessionLobby(sessionLobbyType, lobbyID);
            if (result.Ok)
            {
                Debug.Log("[FusionLauncher] <JoinLobby> JoinSessionLobby succeed");
                ResLoader.LoadSceneAsync(Lobbyscene_unity.LOBBYSCENE, onStartLoading: operation =>
                {
                    operation.completed += asyncOperation =>
                    {
                        Debug.Log("LobbyScene 加载完成");
                        UIKit.ClosePanel<UIMainScenePanel>();
                        UIKit.OpenPanel<UILobbyPanel>(new UILobbyPanelData
                        {
                            lobbyPanelState = UILobbyPanel.LobbyPanelState.JoinRoom
                        });
                    };
                });
            }
            else
            {
                Debug.Log($"[FusionLauncher] <JoinLobby> {result.ShutdownReason}");
            }
        }

        public async UniTaskVoid CreateRoom(string roomName, int maxPlayer)
        {
            Debug.Log($"[FusionLauncher] <CreateRoom> CreateRoom Start");
            StartGameResult result = await NetworkRunner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.Host,
                SessionName = roomName,
                PlayerCount = maxPlayer,
                SceneManager = LevelManager.Instance,
                ObjectPool = FusionObjectPoolRoot.Instance
            });

            if (result.Ok)
            {
                Debug.Log($"[FusionLauncher] <CreateRoom> CreateRoom succeed");
            }
            else
            {
                Debug.Log($"[FusionLauncher] <CreateRoom> CreateRoom Failed Because {result.ErrorMessage}");
            }
        }

        public async UniTaskVoid JoinRoom(string roomName)
        {
            Debug.Log($"[FusionLauncher] <JoinRoom> JoinRoom Start");
            StartGameResult result = await NetworkRunner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.Client,
                SessionName = roomName,
                SceneManager = LevelManager.Instance,
                ObjectPool = FusionObjectPoolRoot.Instance
            });

            if (result.Ok)
            {
                Debug.Log($"[FusionLauncher] <JoinRoom> JoinRoom succeed");
            }
            else
            {
                Debug.Log($"[FusionLauncher] <CreateRoom> JoinRoom Failed Because {result.ErrorMessage}");
            }
        }

        #region + Utility


        #endregion
        

        #region + INetworkRunnerCallbacks

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
            Debug.Log("ConnectedToServer");
        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request,
            byte[] token)
        {
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
            Debug.Log("SessionListUpdated");
            this.SendCommand<UpdateSessionListCommand>(new UpdateSessionListCommand
            {
                sessionList = sessionList,
            });
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
        }
        #endregion



    }
}
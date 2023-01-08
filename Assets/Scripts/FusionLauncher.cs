using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Fusion;
using Fusion.Sockets;
using QAssetBundle;
using QFramework;
using QFramework.TankBattle;
using UnityEngine;

namespace TankBattle
{
    public class FusionLauncher : ISingleton, INetworkRunnerCallbacks
    {
        #region + Singleton
        public static FusionLauncher Instance => SingletonProperty<FusionLauncher>.Instance;

        public void OnSingletonInit()
        {
            Debug.Log("FusionLauncher SingletonInit");
        }
        
        private FusionLauncher() {}
        
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
            if (NetworkRunner == null)
            {
                NetworkRunner = NetworkCore.Instance.GetNetworkRunner();
                NetworkRunner.ProvideInput = true;
                NetworkRunner.AddCallbacks(this);
            }

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
                        UIKit.OpenPanel<UILobbyPanel>();
                    };
                });
            }
            else
            {
                Debug.Log($"[FusionLauncher] <JoinLobby> {result.ShutdownReason}");
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
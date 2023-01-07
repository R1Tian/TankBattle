using Fusion;
using QFramework;
using UnityEngine;

namespace TankBattle
{
    [MonoSingletonPath("[Singleton]/NetworkCore")]
    public class NetworkCore : MonoSingleton<NetworkCore>
    {
        public override void OnSingletonInit()
        {
            
        }

        public NetworkRunner GetNetworkRunner()
        {
            if (gameObject.TryGetComponent(out NetworkRunner networkRunner))
            {
                return networkRunner;
            }
            else
            {
                return gameObject.AddComponent<NetworkRunner>();
            }
        }
    }
}
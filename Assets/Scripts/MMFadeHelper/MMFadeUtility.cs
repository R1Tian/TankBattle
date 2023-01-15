using MoreMountains.Feedbacks;
using QAssetBundle;
using QFramework;
using UnityEngine;

namespace TankBattle.MMFadeHelper
{
    public class MMFadeUtility
    {
        private static ResLoader resLoader = null;
        public static ResLoader ResLoader
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

        public static MMF_Player fadeDirectionalPlayer = null;

        public static MMF_Player GetFadeDirectionalPlayer()
        {
            Debug.Log($"[MMFadeUtility] <GetFadeDirectionalPlayer> 开始获取");
            if (fadeDirectionalPlayer == null)
            {
                GameObject prefab = ResLoader.LoadSync<GameObject>(Mmfadedirectional_prefab.BundleName,
                    Mmfadedirectional_prefab.MMFADEDIRECTIONAL);

                GameObject player = GameObject.Instantiate(prefab).DontDestroyOnLoad();

                fadeDirectionalPlayer = player.GetComponent<MMF_Player>();
                fadeDirectionalPlayer.Initialization();

            }
            Debug.Log($"[MMFadeUtility] <GetFadeDirectionalPlayer> fadeDirectionalPlayer: {fadeDirectionalPlayer}");
            
            return fadeDirectionalPlayer;
        }
    }
}
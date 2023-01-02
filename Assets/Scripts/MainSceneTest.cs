using System.Collections;
using System.Collections.Generic;
using QFramework;
using QFramework.Example;
using UnityEngine;

namespace TankBattle
{
    public class MainSceneTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ResKit.Init();
            UIKit.OpenPanel<UIMainScenePanel>(new UIMainScenePanelData
            {
                joinLobbyInfo = "JoinLobbySession",
                exitGameInfo = "Exit App"
            });
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

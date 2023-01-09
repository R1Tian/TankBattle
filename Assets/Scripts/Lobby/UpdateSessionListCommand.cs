using System.Collections.Generic;
using Fusion;
using QFramework;
using UnityEngine;

namespace TankBattle.Lobby
{
    public class UpdateSessionListCommand : AbstractCommand
    {
        public List<SessionInfo> sessionList;

        protected override void OnExecute()
        {
            Debug.Log("UpdateSessionListCommand sended");
            this.GetModel<LobbyModel>().sessionList = sessionList;
            this.SendEvent<UpdateSessionListEvent>();
        }
    }
}
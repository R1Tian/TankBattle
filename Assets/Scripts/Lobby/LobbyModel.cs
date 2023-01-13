using System.Collections.Generic;
using Fusion;
using QFramework;

namespace TankBattle.Lobby
{
    public class LobbyModel : AbstractModel
    {
        public List<SessionInfo> sessionList;

        protected override void OnInit()
        {
            sessionList = null;
        }
    }
}
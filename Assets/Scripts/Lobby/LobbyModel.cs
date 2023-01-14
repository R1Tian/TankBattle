using System;
using System.Collections.Generic;
using Fusion;
using QFramework;

namespace TankBattle.Lobby
{
    public class LobbyModel : AbstractModel
    {
        public List<SessionInfo> sessionList;

        // Create Room Data
        public string createRoomName;
        public int createRoomPlayerNum;

        protected override void OnInit()
        {
            sessionList = null;
            createRoomName = String.Empty;
            createRoomPlayerNum = 2;
        }
    }
}
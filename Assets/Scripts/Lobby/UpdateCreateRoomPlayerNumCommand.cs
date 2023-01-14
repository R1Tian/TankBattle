using QFramework;
using UnityEngine;

namespace TankBattle.Lobby
{
    public class UpdateCreateRoomPlayerNumCommand : AbstractCommand
    {
        public int createRoomPlayerNum;
        
        protected override void OnExecute()
        {
            Debug.Log($"[UpdateCreateRoomPlayerNumCommand] <OnExecute> createRoomPlayerNum: {createRoomPlayerNum}");
            this.GetModel<LobbyModel>().createRoomPlayerNum = createRoomPlayerNum;
        }
    }
}
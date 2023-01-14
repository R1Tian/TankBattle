using QFramework;
using UnityEngine;

namespace TankBattle.Lobby
{
    public class UpdateCreateRoomNameCommand : AbstractCommand
    {
        public string createRoomName;
        
        protected override void OnExecute()
        {
            Debug.Log($"[UpdateCreateRoomNameCommand] <OnExecute> createRoomName: {createRoomName}");
            this.GetModel<LobbyModel>().createRoomName = createRoomName;
        }
    }
}
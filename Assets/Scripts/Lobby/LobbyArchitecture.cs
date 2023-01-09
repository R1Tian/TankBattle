using QFramework;

namespace TankBattle.Lobby
{
    public class LobbyArchitecture : Architecture<LobbyArchitecture>
    {
        protected override void Init()
        {
            this.RegisterModel(new LobbyModel());
        }
    }
}
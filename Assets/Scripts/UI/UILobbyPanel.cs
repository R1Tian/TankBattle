using UnityEngine;
using UnityEngine.UI;
using QFramework;
using TankBattle.Lobby;

namespace QFramework.TankBattle
{
	public class UILobbyPanelData : UIPanelData
	{
	}
	public partial class UILobbyPanel : UIPanel, IController
	{
		#region + IController
		public IArchitecture GetArchitecture()
		{
			return LobbyArchitecture.Interface;
		}
		
		#endregion

		public LobbyModel lobbyModel;
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UILobbyPanelData ?? new UILobbyPanelData();
			// please add init code here

			lobbyModel = this.GetModel<LobbyModel>();
			
			this.RegisterEvent<UpdateSessionListEvent>(e =>
			{
				Debug.Log($"LobbyList Count {lobbyModel.sessionList.Count}");
			});
			
			Debug.Log($"LobbyList Count {lobbyModel.sessionList.Count}");
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}

	}
}

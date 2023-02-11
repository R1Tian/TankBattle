using System;
using Cysharp.Threading.Tasks;
using Fusion;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using TankBattle;
using Unity.VisualScripting;

namespace QFramework.TankBattle
{
	public class UIMainScenePanelData : UIPanelData
	{
		public Func<SessionLobby, string, UniTaskVoid> joinLobbyFunc;
		public SessionLobby sessionLobbyType;
		public string lobbyID;
	}
	public partial class UIMainScenePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIMainScenePanelData ?? new UIMainScenePanelData();
			// please add init code here

			JoinRoomBtn.onClick.AddListener(() =>
			{
				mData.joinLobbyFunc?.Invoke(mData.sessionLobbyType, mData.lobbyID);
			});
			
			ExitGameBtn.onClick.AddListener(() =>
			{
				
			});
			
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

using System;
using Fusion;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Unity.VisualScripting;

namespace QFramework.TankBattle
{
	public class UIMainScenePanelData : UIPanelData
	{
		public Action<SessionLobby, string> joinLobbyAction;
		public SessionLobby sessionLobbyType;
		public string lobbyID;
	}
	public partial class UIMainScenePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIMainScenePanelData ?? new UIMainScenePanelData();
			// please add init code here
			
			UIKit.Root.SetResolution(1920, 1080, 0);

			JoinRoomBtn.onClick.AddListener(() =>
			{
				mData.joinLobbyAction?.Invoke(mData.sessionLobbyType, mData.lobbyID);
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

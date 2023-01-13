using System.Collections.Generic;
using Fusion;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using TankBattle.Lobby;

namespace QFramework.TankBattle
{
	public class UILobbyPanelData : UIPanelData
	{
		public UILobbyPanel.LobbyPanelState lobbyPanelState;
	}
	public partial class UILobbyPanel : UIPanel, IController
	{
		#region + IController
		public IArchitecture GetArchitecture()
		{
			return LobbyArchitecture.Interface;
		}
		
		#endregion

		public enum LobbyPanelState
		{
			JoinRoom = 0,
			CreateRoom = 1
		}

		public LobbyModel lobbyModel;
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UILobbyPanelData ?? new UILobbyPanelData();
			// please add init code here

			lobbyModel = this.GetModel<LobbyModel>();
			
			this.RegisterEvent<UpdateSessionListEvent>(e =>
			{
				Debug.Log($"LobbyList Count {lobbyModel.sessionList.Count}");
				UpdateExistingSessionList(lobbyModel.sessionList);
			});
			
			EnterCreateRoomStateButton.onClick.AddListener(() =>
			{
				SetUIState(LobbyPanelState.CreateRoom);
			});
			BackToRoomListButton.onClick.AddListener(() =>
			{
				SetUIState(LobbyPanelState.JoinRoom);
			});
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			SetUIState(mData.lobbyPanelState);
			UpdateExistingSessionList(lobbyModel.sessionList);
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

		private void SetUIState(LobbyPanelState lobbyPanelState)
		{
			SetAllUIInactive();
			
			Background.gameObject.SetActive(true);
			
			if (lobbyPanelState == LobbyPanelState.JoinRoom)
			{
				LobbyTitle.gameObject.SetActive(true);
				RoomListScrollViewContainer.gameObject.SetActive(true);
				EnterCreateRoomStateButton.gameObject.SetActive(true);
			}
			else if (lobbyPanelState == LobbyPanelState.CreateRoom)
			{
				CreateRoomTitle.gameObject.SetActive(true);
				CreateRoomScrollViewContainer.gameObject.SetActive(true);
				BackToRoomListButton.gameObject.SetActive(true);
				CreateRoomButton.gameObject.SetActive(true);
			}
		}

		private void SetAllUIInactive()
		{
			Background.gameObject.SetActive(false);
			LobbyTitle.gameObject.SetActive(false);
			RoomListScrollViewContainer.gameObject.SetActive(false);
			EnterCreateRoomStateButton.gameObject.SetActive(false);
			CreateRoomTitle.gameObject.SetActive(false);
			CreateRoomScrollViewContainer.gameObject.SetActive(false);
			BackToRoomListButton.gameObject.SetActive(false);
			CreateRoomButton.gameObject.SetActive(false);
		}

		private void UpdateExistingSessionList(List<SessionInfo> sessionList)
		{
			if (sessionList.Count == 0)
			{
				NoExistingRoomText.gameObject.SetActive(true);
			}
			else
			{
				NoExistingRoomText.gameObject.SetActive(false);
			}
		}
	}
}

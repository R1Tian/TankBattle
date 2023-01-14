using System.Collections.Generic;
using Fusion;
using QAssetBundle;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using TankBattle;
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
		private ResLoader resloader;
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UILobbyPanelData ?? new UILobbyPanelData();
			// please add init code here

			Init();
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
			lobbyModel = null;
			resloader = null;
		}

		private void Init()
		{
			lobbyModel = this.GetModel<LobbyModel>();
			resloader = ResLoader.Allocate();
			
			this.RegisterEvent<UpdateSessionListEvent>(e =>
			{
				Debug.Log($"LobbyList Count {lobbyModel.sessionList.Count}");
				UpdateExistingSessionList(lobbyModel.sessionList);
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			
			EnterCreateRoomStateButton.onClick.AddListener(() =>
			{
				SetUIState(LobbyPanelState.CreateRoom);
			});
			BackToRoomListButton.onClick.AddListener(() =>
			{
				SetUIState(LobbyPanelState.JoinRoom);
			});
			
			// Create Room
			RoomNameInputField.onEndEdit.AddListener(roomName =>
			{
				this.SendCommand(new UpdateCreateRoomNameCommand
				{
					createRoomName = roomName
				});
			});
			
			PlayerNumberDropdown.onValueChanged.AddListener(index =>
			{
				this.SendCommand(new UpdateCreateRoomPlayerNumCommand
				{
					createRoomPlayerNum = int.Parse(PlayerNumberDropdown.options[index].text)
				});
			});
			
			CreateRoomButton.onClick.AddListener(() =>
			{
				FusionLauncher.Instance.CreateRoom(lobbyModel.createRoomName, lobbyModel.createRoomPlayerNum).Forget();
			});
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
				GameObject roomCell =
					resloader.LoadSync<GameObject>(Roomcell_prefab.BundleName, Roomcell_prefab.ROOMCELL);

				// 清除原有的 RoomCell
				foreach (Transform child in RoomListScrollViewContent)
				{
					Destroy(child.gameObject);
				}

				// 构建新的 RoomCell
				for (int i = 0; i < sessionList.Count; i++)
				{
					SessionInfo sessionInfo = sessionList[i];
					Instantiate(roomCell, RoomListScrollViewContent)
						.GetComponent<RoomCell>()
						.Init(sessionInfo.Name, sessionInfo.PlayerCount, sessionInfo.MaxPlayers);
				}
			}
		}
		
	}
}

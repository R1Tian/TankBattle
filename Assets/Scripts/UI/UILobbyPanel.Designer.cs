using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TankBattle
{
	// Generate Id:9cfc6b20-52c9-4f5d-9271-dc86861d274f
	public partial class UILobbyPanel
	{
		public const string Name = "UILobbyPanel";
		
		[SerializeField]
		public UnityEngine.UI.Image Background;
		[SerializeField]
		public UnityEngine.UI.Image LobbyTitle;
		[SerializeField]
		public UnityEngine.UI.Image CreateRoomTitle;
		[SerializeField]
		public RectTransform RoomListScrollViewContainer;
		[SerializeField]
		public RectTransform RoomListScrollViewContent;
		[SerializeField]
		public RectTransform CreateRoomScrollViewContainer;
		[SerializeField]
		public TMPro.TMP_InputField RoomNameInputField;
		[SerializeField]
		public TMPro.TMP_Dropdown PlayerNumberDropdown;
		[SerializeField]
		public UnityEngine.UI.Button EnterCreateRoomStateButton;
		[SerializeField]
		public UnityEngine.UI.Button BackToRoomListButton;
		[SerializeField]
		public UnityEngine.UI.Button CreateRoomButton;
		[SerializeField]
		public TMPro.TextMeshProUGUI NoExistingRoomText;
		
		private UILobbyPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Background = null;
			LobbyTitle = null;
			CreateRoomTitle = null;
			RoomListScrollViewContainer = null;
			RoomListScrollViewContent = null;
			CreateRoomScrollViewContainer = null;
			RoomNameInputField = null;
			PlayerNumberDropdown = null;
			EnterCreateRoomStateButton = null;
			BackToRoomListButton = null;
			CreateRoomButton = null;
			NoExistingRoomText = null;
			
			mData = null;
		}
		
		public UILobbyPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UILobbyPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UILobbyPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}

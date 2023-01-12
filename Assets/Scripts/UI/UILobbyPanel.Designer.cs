using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TankBattle
{
	// Generate Id:63315da2-c23f-4235-8a26-961e013a5a9c
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
		public RectTransform CreateRoomScrollViewContainer;
		[SerializeField]
		public UnityEngine.UI.Button CreateRoomButton;
		[SerializeField]
		public UnityEngine.UI.Button BackToRoomListButton;
		
		private UILobbyPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Background = null;
			LobbyTitle = null;
			CreateRoomTitle = null;
			RoomListScrollViewContainer = null;
			CreateRoomScrollViewContainer = null;
			CreateRoomButton = null;
			BackToRoomListButton = null;
			
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

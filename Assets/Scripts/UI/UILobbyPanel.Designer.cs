using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TankBattle
{
	// Generate Id:72467d55-ab88-455d-9cdd-83bb1b70c477
	public partial class UILobbyPanel
	{
		public const string Name = "UILobbyPanel";
		
		[SerializeField]
		public UnityEngine.UI.Image Background;
		[SerializeField]
		public UnityEngine.UI.Image Title;
		[SerializeField]
		public RectTransform ScrollViewContainer;
		
		private UILobbyPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Background = null;
			Title = null;
			ScrollViewContainer = null;
			
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

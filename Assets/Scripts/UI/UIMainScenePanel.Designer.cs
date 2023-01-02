using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:f5a1e9ca-55a4-4a71-8650-224f53376e9a
	public partial class UIMainScenePanel
	{
		public const string Name = "UIMainScenePanel";
		
		/// <summary>
		/// 加入房间按钮
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button JoinRoomBtn;
		/// <summary>
		/// 退出游戏按钮
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button ExitGameBtn;
		
		private UIMainScenePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			JoinRoomBtn = null;
			ExitGameBtn = null;
			
			mData = null;
		}
		
		public UIMainScenePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIMainScenePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIMainScenePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}

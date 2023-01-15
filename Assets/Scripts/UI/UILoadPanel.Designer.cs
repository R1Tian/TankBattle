using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TankBattle
{
	// Generate Id:a1539b77-7979-4261-8ac2-62e073b063f9
	public partial class UILoadPanel
	{
		public const string Name = "UILoadPanel";
		
		
		private UILoadPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UILoadPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UILoadPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UILoadPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}

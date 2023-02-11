using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TankBattle
{
	// Generate Id:87319e04-74e1-4bae-80b2-db3ff73e899a
	public partial class UILoadPanel
	{
		public const string Name = "UILoadPanel";
		
		[SerializeField]
		public UnityEngine.RectTransform FadeDirectional;
		
		private UILoadPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			FadeDirectional = null;
			
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

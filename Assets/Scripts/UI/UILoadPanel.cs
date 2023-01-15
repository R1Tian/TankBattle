using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TankBattle
{
	public class UILoadPanelData : UIPanelData
	{
	}
	public partial class UILoadPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UILoadPanelData ?? new UILoadPanelData();
			// please add init code here
			
			UIKit.Root.SetResolution(1920, 1080, 0);
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

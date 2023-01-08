using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TankBattle
{
	public class UILobbyPanelData : UIPanelData
	{
	}
	public partial class UILobbyPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UILobbyPanelData ?? new UILobbyPanelData();
			// please add init code here
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

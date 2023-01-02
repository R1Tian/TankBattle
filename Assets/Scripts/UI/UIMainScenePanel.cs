using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public class UIMainScenePanelData : UIPanelData
	{
		public string joinLobbyInfo;
		public string exitGameInfo;
	}
	public partial class UIMainScenePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIMainScenePanelData ?? new UIMainScenePanelData();
			// please add init code here
			
			JoinRoomBtn.onClick.AddListener(() =>
			{
				Debug.Log(mData.joinLobbyInfo);
			});
			
			ExitGameBtn.onClick.AddListener(() =>
			{
				Debug.Log(mData.exitGameInfo);
			});
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

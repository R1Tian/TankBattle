using UnityEngine;

namespace TankBattle.Lobby
{
    public class RoomCell : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI roomNameText;
        public TMPro.TextMeshProUGUI playerNumText;
        public UnityEngine.UI.Button joinButton;

        public void Init(string roomName, int existNum, int maxNum)
        {
            roomNameText.text = roomName;
            playerNumText.text = $"{existNum} / {maxNum}";
            joinButton.onClick.AddListener(() =>
            {
                FusionLauncher.Instance.JoinRoom(roomName).Forget();
            });
        }
    }
}
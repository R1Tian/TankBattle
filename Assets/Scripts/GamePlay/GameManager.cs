using Fusion;
using QFramework;
using UnityEngine;

namespace TankBattle.GamePlay
{
    public class GameManager: NetworkBehaviour, IStateAuthorityChanged
    {
        public enum PlayState
        {
            LOBBY,
            LEVEL,
            TRANSITION
        }
        
        public static GameManager instance { get; private set; }
        
        [Networked]
        private int networkedWinningPlayerIndex { get; set; } = -1;

        [Networked]
        private PlayState networkedPlayState { get; set; }

        public static PlayState playState
        {
            get => (instance != null && instance.Object != null && instance.Object.IsValid) ?  instance.networkedPlayState : PlayState.LOBBY;
            set
            {
                if (instance != null && instance.Object != null && instance.Object.IsValid)
                {
                    instance.networkedPlayState = value;
                }
            }
        }

        public static int WinningPlayerIndex
        {
            get => (instance != null && instance.Object != null && instance.Object.IsValid) ? instance.networkedWinningPlayerIndex : -1;
            set
            {
                if (instance != null && instance.Object != null && instance.Object.IsValid)
                {
                    instance.networkedWinningPlayerIndex = value;
                }
            }
        }

        public const byte MAX_LIVES = 3;
        public const byte MAX_SCORE = 3;
        
        public override void Spawned()
        {
            if (instance)
            {
                Runner.Despawn(Object);
            }
            else
            {
                instance = this;

                // 如果是服务端
                if (Object.HasStateAuthority)
                {
                    LoadLevel((int)LevelManager.RoomIndex.ReadyRoom,-1);
                }
            }
        }

        private void LoadLevel(int nextLevelIndex, int winningPlayerIndex)
        {
            if (!Object.HasStateAuthority) return;
            
            // Reset lives and transition to level
            // Reset players ready state so we don't launch immediately
            
            // Start transition
            WinningPlayerIndex = winningPlayerIndex;
            
            // Load Level
            LevelManager.Instance.LoadLevel(nextLevelIndex);
        }

        public void StateAuthorityChanged()
        {
            Debug.Log($"State Authority of GameManager changed: {Object.StateAuthority}");
        }

        
    }
}
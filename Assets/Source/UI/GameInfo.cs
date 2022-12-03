using Gameplay.TurnController;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameInfo : MonoBehaviour
    {
        public TextMeshProUGUI CurrentTurnText;
        public TextMeshProUGUI CurrentPlayerText;
        
        private TurnController _turnController;

        public void Init(TurnController turnController)
        {
            _turnController = turnController;
            _turnController.TurnChanged += UpdateCurrentTurnText;
            UpdateCurrentTurnText(_turnController.Turn, _turnController.CurrentPlayer.NickName);
        }

        private void OnDisable()
        {
            _turnController.TurnChanged -= UpdateCurrentTurnText;
        }

        private void UpdateCurrentTurnText(int turn, string nickName)
        {
            CurrentTurnText.text = "Текущий ход: " + turn;
            CurrentPlayerText.text = "Сейчас ходит: " + nickName;
        }
    }
}
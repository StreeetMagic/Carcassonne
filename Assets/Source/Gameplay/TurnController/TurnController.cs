using System.Collections.Generic;
using Gameplay.Players;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.TurnController
{
    public class TurnController : MonoBehaviour
    {
        [field: SerializeField] public Player HumanPlayer { get; private set; }
        [field: SerializeField] public Player AIBot { get; private set; }
        [field: SerializeField] public int Turn { get; private set; }
        [field: SerializeField] public Player CurrentPlayer { get; private set; }

        private readonly List<Player> _players = new();

        public event UnityAction<int, string> TurnChanged;

        public void Init(Player humanPlayer, Player aiBot)
        {
            HumanPlayer = humanPlayer;
            AIBot = aiBot;

            _players.Add(humanPlayer);
            _players.Add(aiBot);
            CurrentPlayer = humanPlayer;
        }

        public void SetFirstTurn()
        {
            Turn = 1;
            HumanPlayer.SetActiveTurn();
            TurnChanged?.Invoke(Turn, CurrentPlayer.NickName);
        }

        public void SetNextTurn()
        {
            Turn++;
            TurnChanged?.Invoke(Turn, CurrentPlayer.NickName);
            ReversePlayers();
            _players[0].SetActiveTurn();
            _players[1].SetInActiveTurn();
        }

        private void ReversePlayers()
        {
            var first = _players[0];
            var second = _players[1];

            _players[0] = second;
            _players[1] = first;
        }
    }
}
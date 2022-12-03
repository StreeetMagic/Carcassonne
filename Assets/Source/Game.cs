using System.Collections;
using System.Collections.Generic;
using Gameplay.CellGrid;
using Gameplay.Decks;
using Gameplay.Players;
using Gameplay.Players.AIBots;
using Gameplay.Players.Humans;
using Gameplay.TurnController;
using UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Prefabs")] 
    
    [SerializeField] private Deck DeckPrefab;
    [SerializeField] private CellCreator CellCreatorPrefab;
    [SerializeField] private Human HumanPrefab;
    [SerializeField] private AIBot AIBotPrefab;
    [SerializeField] private TurnController TurnControllerPrefab;
    [SerializeField] private GameObject UIPrefab;

    [Header("Links")] 
    
    [SerializeField] private Deck _deck;
    [SerializeField] private CellCreator _cellCreator;
    [SerializeField] private MarkerCreator _markerCreator;
    [SerializeField] private Player _humanPlayer;
    [SerializeField] private AIBot _aiBot;
    [SerializeField] private TurnController _turnController;
    [SerializeField] private GameInfo _gameInfoUI;

    private void Awake()
    {
        SpawnPrefabs();
        
        _cellCreator.CreateZeroCell(_deck);
        SetFirstTiles();
        _turnController.SetFirstTurn();
        SpawnUI();

        MainLoop();
        
        StartCoroutine(Pause());
    }

    private void MainLoop()
    {
        _markerCreator.CreateMarkers();
    }

    private void SpawnPrefabs()
    {
        SpawnDeck();
        SpawnGrid();
        SpawnHuman();
        SpawnAIBot();
        SpawnTurnController();
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
    }

    private void SpawnUI()
    {
        _gameInfoUI = Instantiate(UIPrefab).GetComponentInChildren<GameInfo>();
        _gameInfoUI.Init(_turnController);
    }

    private void SpawnTurnController()
    {
        _turnController = Instantiate(TurnControllerPrefab);
        _turnController.Init(_humanPlayer, _aiBot);
    }

    private void SetFirstTiles()
    {
        _humanPlayer.SetNextTile();
        _aiBot.SetNextTile();
    }

    private void SpawnAIBot()
    {
        _aiBot = Instantiate(AIBotPrefab);
        _aiBot.Init(_deck);
        _aiBot.NickName = "Компостер";
    }

    private void SpawnHuman()
    {
        _humanPlayer = Instantiate(HumanPrefab);
        _humanPlayer.Init(_deck);
        _humanPlayer.NickName = "Человек";
    }

    private void SpawnDeck()
    {
        _deck = Instantiate(DeckPrefab);
    }

    private void SpawnGrid()
    {
        _cellCreator = Instantiate(CellCreatorPrefab);
        _markerCreator = _cellCreator.GetComponent<MarkerCreator>();
    }
}
using System;
using System.Transactions;
using Gameplay.CellGrid;
using Gameplay.Decks;
using Gameplay.Players;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Prefabs")]
    public Deck DeckPrefab;
    public CellCreator CellCreatorPrefab;
    public Human HumanPrefab;
    public AIBot AIBotPrefab;

    [Header("Links")]
    public Deck Deck;
    public CellCreator CellCreator;
    public MarkerCreator MarkerCreator;
    public Player Player;
    public AIBot AIBot;

    private void Awake()
    {
        SpawnDeck();
        SpawnGrid();
        SpawnHuman();
        SpawnAIBot();
        
        CellCreator.CreateZeroCell(Deck);
        SetFirstTiles();
        
        var zeroTile = CellCreator.Cells[0].Tile;
        MarkerCreator.CreateMarkers(zeroTile);
    }

    private void SetFirstTiles()
    {
        Player.SetNextTile();
        AIBot.SetNextTile();
    }

    private void SpawnAIBot()
    {
        AIBot = Instantiate(AIBotPrefab);
        AIBot.Init(Deck);
    }

    private void SpawnHuman()
    {
        Player = Instantiate(HumanPrefab);
        Player.Init(Deck);
    }

    private void SpawnDeck()
    {
        Deck = Instantiate(DeckPrefab);
    }

    private void SpawnGrid()
    {
        CellCreator = Instantiate(CellCreatorPrefab);
        MarkerCreator = CellCreator.GetComponent<MarkerCreator>();
    }
}
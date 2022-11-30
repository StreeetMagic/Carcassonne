using System.Collections.Generic;
using Gameplay.Tiles;
using UnityEngine;

namespace Gameplay.Decks
{
    public class Deck : MonoBehaviour
    {
        public List<Tile> Tiles;

        public Tile GetRandomTile()
        {
            if (Tiles.Count < 1)
                return null;
        
            var randomTileNumber = Random.Range(0, Tiles.Count);
            var tile = Tiles[randomTileNumber];
            Tiles.Remove(tile);
        
            return tile;

        }
    }
}

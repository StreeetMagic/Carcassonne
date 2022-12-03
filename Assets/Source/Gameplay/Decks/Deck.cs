using System.Collections.Generic;
using Gameplay.Tiles;
using UnityEngine;

namespace Gameplay.Decks
{
    public class Deck : MonoBehaviour
    {
        [SerializeField] private List<Tile> _tiles;

        [field: SerializeField] public Tile FirstTile { get; private set; }
        
        public Tile GetRandomTile()
        {
            if (_tiles.Count < 1)
                return null;
        
            var randomTileNumber = Random.Range(0, _tiles.Count);
            var tile = _tiles[randomTileNumber];
            _tiles.Remove(tile);
        
            return tile;
        }

    }
}

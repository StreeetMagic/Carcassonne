using Gameplay.Decks;
using Gameplay.Tiles;
using UnityEngine;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        public Deck Deck;
        public Tile NextTile;
        public GameObject Container;
    
        private void Start()
        {
            SetNextTile();
        }

        private void SetNextTile()
        {
            var tile = Deck.GetRandomTile();
            NextTile = tile;
            NextTile.transform.SetParent(Container.transform);
            NextTile.gameObject.SetActive(true);
            NextTile.transform.localPosition = Vector3.zero;
        }
    }
}

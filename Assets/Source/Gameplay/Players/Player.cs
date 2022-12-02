using Gameplay.Decks;
using Gameplay.Tiles;
using UI;
using UnityEngine;

namespace Gameplay.Players
{
    public abstract class Player : MonoBehaviour
    {
        public Tile NextTile;
        public GameObject Container;
        public Camera Camera;
        public ISelectable Selectable;
        public Deck Deck;

        public void Init(Deck deck)
        {
            Deck = deck;
        }
        
        public void SetNextTile()
        {
            var tile = Deck.GetRandomTile();
            NextTile = tile;
            NextTile.transform.SetParent(Container.transform);
            NextTile.gameObject.SetActive(true);
            NextTile.transform.localPosition = Vector3.zero;
        }
    }
}
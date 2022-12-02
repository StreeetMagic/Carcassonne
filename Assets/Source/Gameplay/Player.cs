using System;
using Gameplay.Decks;
using Gameplay.Tiles;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        public Deck Deck;
        public Tile NextTile;
        public GameObject Container;
        private Camera _camera;

        private ISelectable _selectable;

        private void Start()
        {
            _camera = Camera.main;
            SetNextTile();
        }

        private void Update()
        {
            MouseInput();
        }

        private void SetNextTile()
        {
            var tile = Deck.GetRandomTile();
            NextTile = tile;
            NextTile.transform.SetParent(Container.transform);
            NextTile.gameObject.SetActive(true);
            NextTile.transform.localPosition = Vector3.zero;
        }

        void MouseInput()
        {
            Vector2 raycastPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero);

            _selectable?.DeSelect();

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out ISelectable selectable))
                {
                    _selectable = selectable;
                    selectable.Select();
                }
            }
        }
    }
}
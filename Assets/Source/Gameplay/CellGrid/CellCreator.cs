using System;
using System.Collections.Generic;
using Gameplay.CellGrid.Cells;
using Gameplay.Decks;
using Gameplay.Tiles;
using UnityEngine;

namespace Gameplay.CellGrid
{
    public class CellCreator : MonoBehaviour
    {
        public List<Cell> Cells = new();

        public Cell CellPrefab;
        public GameObject CellContainer;

        public event Action<Cell> CellCreated;
        public event Action<Tile> TilePlaced;

        public void InvokeTilePlacedEvent(Tile tile)
        {
            TilePlaced?.Invoke(tile);
            var position = tile.transform.position;
            CreateCells(position.x, position.y);
        }

        private void CreateCells(float XPosition, float YPosition)
        {
            int xPosition = (int)XPosition;
            int yPosition = (int)YPosition;
            
            for (int x = xPosition - 1; x <= yPosition + 1; x++)
            {
                for (int y = yPosition - 1; y <= yPosition + 1; y++)
                {
                    if (CheckCell(x, y, out Cell kek))
                        continue;

                    var cell = Instantiate(CellPrefab, new Vector3(x, y), Quaternion.identity, CellContainer.transform);

                    Cells.Add(cell);
                    cell.SetCellCreator(this);
                    CellCreated?.Invoke(cell);
                }
            }
        }

        public void CreateZeroCell(Deck deck)
        {
            var zeroCell = Instantiate(CellPrefab, new Vector3(0, 0), Quaternion.identity, CellContainer.transform);
            Cells.Add(zeroCell);
            zeroCell.SetCellCreator(this);
            CellCreated?.Invoke(zeroCell);
            zeroCell.SetTile(deck.FirstTile);
            
            
        }

        public bool CheckCell(float x, float y, out Cell cell)
        {
            foreach (var c in Cells)
            {
                if (Math.Abs(c.transform.position.x - x) < .1 && Math.Abs(c.transform.position.y - y) < .1)
                {
                    cell = c;
                    return true;
                }
            }
            cell = null;
            return false;
        }
    }
}
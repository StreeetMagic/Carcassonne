using Gameplay.CellGrid.Markers;
using Gameplay.Tiles;
using UnityEngine;

namespace Gameplay.CellGrid.Cells
{
    public class Cell : MonoBehaviour
    {
        public Tile Tile;
        public Marker Marker;
        public CellCreator CellCreator;

        public void SetCellCreator(CellCreator cellCreator)
        {
            CellCreator = cellCreator;
        }
        
        public void SetTile(Tile tile)
        {
            Tile = tile;
            tile.gameObject.SetActive(true);
            tile.transform.SetParent(transform);
            CellCreator.InvokeTilePlacedEvent(tile);
            Tile.Init(CellCreator);
        }
    }
}
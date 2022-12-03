using Gameplay.CellGrid.Markers;
using Gameplay.Tiles;
using UnityEngine;

namespace Gameplay.CellGrid.Cells
{
    public class Cell : MonoBehaviour
    {
        [field: SerializeField] public Tile Tile { get; private set; }
        [field: SerializeField] public Marker Marker { get; private set; }
        [field: SerializeField] public CellCreator CellCreator { get; private set; }

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
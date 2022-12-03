using System.Collections.Generic;
using Gameplay.CellGrid.Cells;
using Gameplay.CellGrid.Markers;
using Gameplay.Tiles;
using Unity.Mathematics;
using UnityEngine;

namespace Gameplay.CellGrid
{
    public class MarkerCreator : MonoBehaviour
    {
        [field: SerializeField] public CellCreator CellCreator { get; private set; }
        [field: SerializeField] public Marker MarkerPrefab { get; private set; }

        private List<Marker> _markers;

        public void CreateMarkers()
        {
            var tiles = CellCreator.GetPlacedTiles();
            
            foreach (var tile in tiles)
            {
                TryCreateMarkers(tile);
            }
        }

        private void TryCreateMarkers(Tile tile)
        {
            TryCreateMarker(tile, 1, 0);
            TryCreateMarker(tile, 0, 1);
            TryCreateMarker(tile, -1, 0);
            TryCreateMarker(tile, 0, -1);
        }

        private void TryCreateMarker(Tile tile, int XDelta, int YDelta)
        {
            var cell = TryGetCell(tile, XDelta, YDelta);

            if (cell == null)
                return;

            if (cell.Tile != null)
                return;

            var marker = CreateMarker(tile, cell);
        }

        private Cell TryGetCell(Tile tile, int xDelta, int yDelta)
        {
            var position = tile.transform.position;
            CellCreator.CheckCell(position.x + xDelta, position.y + yDelta, out Cell cell);

            return cell == null ? null : cell;
        }

        private Marker CreateMarker(Tile tile, Cell cell)
        {
            var marker = Instantiate(
                MarkerPrefab,
                cell.transform.position,
                quaternion.identity,
                tile.transform);

            tile.AddMarker(marker);

            return marker;
        }
    }
}
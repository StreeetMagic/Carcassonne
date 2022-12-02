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
        public CellCreator CellCreator;
        public Marker MarkerPrefab;
        public List<Marker> Markers;

        public void CreateMarkers(Tile tile)
        {
            CheckNeighbours(tile);
        }

        private void CheckNeighbours(Tile tile)
        {
            TryCreateMarker(tile, 1 ,0 );
            TryCreateMarker(tile, 0 ,1 );
            TryCreateMarker(tile, -1 ,0 );
            TryCreateMarker(tile, 0 ,-1 );
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

        private Cell TryGetCell(Tile tile, int XDelta, int YDelta)
        {
            var position = tile.transform.position;
            CellCreator.CheckCell(position.x + XDelta, position.y + YDelta, out Cell cell);

            return cell == null ? null : cell;
        }

        private Marker CreateMarker(Tile tile, Cell cell)
        {
            var marker = Instantiate(
                MarkerPrefab,
                cell.transform.position,
                quaternion.identity,
                tile.transform);

            tile.Markers.Add(marker);

            return marker;
        }
    }
}
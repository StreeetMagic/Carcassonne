using System;
using System.Collections.Generic;
using Gameplay.CellGrid.Cells;
using UnityEngine;

namespace Gameplay.CellGrid
{
    public class MyGrid : MonoBehaviour
    {
        public List<Cell> Cells = new();
        public GameObject CellContainer;
        public Cell CellPrefab;

        private void Start()
        {
            CreateInitialCells();
        }

        private void CreateInitialCells()
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (CheckCell(x,y))
                        continue;

                    var cell = Instantiate(CellPrefab, new Vector3(x, y), Quaternion.identity, CellContainer.transform);
                    Cells.Add(cell);
                }
            }
        }

        private bool CheckCell(float x, float y)
        {
            foreach (var cell in Cells)
            {
                if (Math.Abs(cell.transform.position.x - x) < .1 && Math.Abs(cell.transform.position.y - y) < .1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
using System.Collections.Generic;
using Gameplay.CellGrid;
using Gameplay.CellGrid.Markers;
using UI;
using UnityEngine;

namespace Gameplay.Tiles
{
    public class Tile : MonoBehaviour, ISelectable
    {
        public bool IsSelected;
        public CellCreator CellCreator;

        public List<Marker> Markers = new();

        public void Init(CellCreator cellCreator)
        {
            CellCreator = cellCreator;
        }
        
        public void Select()
        {
            if (IsSelected) return;
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            IsSelected = true;
        }

        public void DeSelect()
        {
            if (!IsSelected) return;
            transform.localScale = new Vector3(1, 1, 1);
            IsSelected = false;
        }
    }
}
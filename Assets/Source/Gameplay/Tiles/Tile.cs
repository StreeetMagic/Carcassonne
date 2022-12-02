using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Tiles
{
    public class Tile : MonoBehaviour, ISelectable
    {
        public bool IsSelected;

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
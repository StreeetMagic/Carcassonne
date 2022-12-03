using System;
using TMPro;
using UnityEngine;

namespace Gameplay.Tiles
{
    public class Rotator : MonoBehaviour
    {
        [field: SerializeField] public SideNames[] Sides { get; private set; }
        [field: SerializeField] public bool[] SideStatuses { get; private set; } = { true, true, true, true };
        [field: SerializeField] public int RotateCount { get; private set; }
        
        [field: SerializeField] public TextMeshProUGUI TopText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI RightText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI BottomText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI LeftText { get; private set; }

        private TextMeshProUGUI[] _texts;

        private void Awake()
        {
            _texts = new[] { TopText, RightText, BottomText, LeftText };
            PrintSideNames();
        }

        public void Rotate()
        {
            RotateCount++;
        }

        public SideNames GetSide(int sideNumber)
        {
            return Sides[sideNumber + RotateCount];
        }

        public bool GetSideStatus(int sideNumber)
        {
            return SideStatuses[sideNumber + RotateCount];
        }

        private void PrintSideNames()
        {
            for (var index = 0; index < _texts.Length; index++)
            {
                var t = _texts[index];
                t.text = index + " " + Sides[index].ToString();
            }
        }
    }
}
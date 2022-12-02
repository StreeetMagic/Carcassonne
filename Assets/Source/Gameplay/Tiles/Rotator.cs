using TMPro;
using UnityEngine;

namespace Gameplay.Tiles
{
    public class Rotator : MonoBehaviour
    {
        [field: SerializeField] public SideNames[] Sides { get; private set; }
        [field: SerializeField] public bool[] SideStatuses { get; private set; } = { true, true, true, true };
        [field: SerializeField] public int RotateCount { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Text { get; private set; }

        private void Update()
        {
            PrintSideName();
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

        public void PrintSideName()
        {
            Text.text = Sides[0].ToString();
        }
    }
}
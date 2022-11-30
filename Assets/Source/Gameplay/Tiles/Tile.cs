using UnityEngine;

namespace Gameplay.Tiles
{
    public class Tile : MonoBehaviour
    {
        [field:SerializeField] public SideNames[] Sides { get; private set; }

        public int RotateCount = 0;

        public SideNames GetSide(int side, int rotateCount)
        {
            return Sides[side + rotateCount];
        }

        public void Rotate()
        {
            RotateCount++;
        }


    }
}
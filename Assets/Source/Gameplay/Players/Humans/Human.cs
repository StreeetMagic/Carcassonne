using UI;
using UnityEngine;

namespace Gameplay.Players.Humans
{
    public class Human : Player
    {
        void MouseInput()
        {
            Vector2 raycastPos = Camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero);

            Selectable?.DeSelect();

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out ISelectable selectable))
                {
                    Selectable = selectable;
                    selectable.Select();
                }
            }
        }
    }
}
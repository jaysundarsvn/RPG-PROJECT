using System;
using RPG_PROJECT.Combat;
using RPG_PROJECT.Movement;
using RPG_ROJECT.Combat;
using UnityEngine;

namespace RPG_PROJECT.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Reference to the player's Health component.
        Health health;

        private void Start()
        {
            // Initialize the health reference.
            health = GetComponent<Health>();
        }

        private void Update()
        {
            // If the player is dead, stop any further actions.
            if (health.IsDead()) { return; }

            // Handle combat interactions first. If a combat interaction occurs, exit early.
            if (InteractWithCombat()) return;

            // If no combat interaction, handle movement interactions.
            if (InteractWithMovement()) return;
        }

        // Handles player interaction with combat targets using mouse clicks.
        private bool InteractWithCombat()
        {
            // Casts a ray from the camera to the mouse position and checks for all hits.
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            // Iterate through all the raycast hits.
            foreach (RaycastHit hit in hits)
            {
                // Try to get the CombatTarget component from the hit object.
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();

                // If the hit object doesn't have a CombatTarget, skip to the next hit.
                if (target == null) continue;

                // If the target is not attackable, skip to the next hit.
                if (!GetComponent<Fighter>().CanAttack(target.gameObject))
                {
                    continue;
                }

                // If the left mouse button is pressed, initiate an attack on the target.
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);
                }
                // Return true indicating a combat interaction was handled.
                return true;
            }
            // Return false if no valid combat interaction was found.
            return false;
        }

        // Handles player movement by clicking on the ground or other movement surfaces.
        private bool InteractWithMovement()
        {
            RaycastHit hit;
            // Cast a ray from the camera to the mouse position and check for a single hit.
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                // If the left mouse button is held down, move the player to the hit point.
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point, 1f);
                }
                // Return true indicating a movement interaction was handled.
                return true;
            }
            // Return false if no movement interaction was found.
            return false;
        }

        // Helper method to get a ray from the camera through the mouse position.
        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

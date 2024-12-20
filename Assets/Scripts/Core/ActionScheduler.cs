using UnityEngine;

namespace RPG_PROJECT.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        // The current action being executed by this GameObject.
        IAction currentAction;

        // The ActionScheduler helps manage actions like movement, combat, etc., 
        // ensuring that only one action is performed at a time. This prevents 
        // conflicts and breaks dependencies between components like Fighter and Mover.

        // Method to handle the scheduling of actions.
        public void ActionHandler(IAction action)
        {
            // If the action being passed is the same as the current action, do nothing.
            if (currentAction == action)
            {
                return;
            }

            // If an action is already in progress, cancel it before starting the new one.
            if (currentAction != null)
            {
                currentAction.Cancel();
            }

            // Set the new action as the current action.
            currentAction = action;
        }

        // Method to cancel the current action being performed.
        public void CancelCurrentAction()
        {
            // Calls ActionHandler with a null action, effectively canceling the current action.
            ActionHandler(null);
        }
    }
}

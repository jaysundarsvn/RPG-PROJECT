using RPG_PROJECT.Core;
using UnityEngine;
using RPG_PROJECT.Saving;


namespace RPG_PROJECT.Combat
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float healthPoints = 100f; // Hwalth of player/enemy

        bool isDead = false; // bool vlaue which will decide stop movement after death

        public bool IsDead() // bool func to check if dead or not
        {
            return isDead;
        }

        public void HealthDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0); // calcs the damage and make sure it does not go below 0
            if (healthPoints == 0)
            {
                Die(); // when health is 0  u r dead
            }
        }

        private void Die()
        {
            if (isDead) return; // early return as we declared false first

            isDead = true;
            GetComponent<Animator>().SetTrigger("Death"); // if isDead is true trigger death anim
            GetComponent<ActionScheduler>().CancelCurrentAction(); // cancel the current action
        }

        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
            healthPoints = (float)state;

            if(healthPoints == 0)
            {
                Die();
            }
        }
    }
}
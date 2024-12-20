using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG_PROJECT
{
    public class TriggerCutScene : MonoBehaviour
    {
        bool csIsTriggered = false;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag =="Player" && csIsTriggered == false )
            {
                GetComponent<PlayableDirector>().Play();
                csIsTriggered = true;
            }

            else
            {
                return;
            }
            
        }
    }
}

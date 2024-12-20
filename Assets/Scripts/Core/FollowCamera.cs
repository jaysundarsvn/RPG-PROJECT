using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_ROJECT.Core
{
    public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate()
    {
        transform.position = target.position;
    }
}
}
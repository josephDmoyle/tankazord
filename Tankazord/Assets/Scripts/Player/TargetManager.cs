using System.Collections.Generic;
using UnityEngine;

namespace Princeps.Player
{
    public class TargetManager : MonoBehaviour
    {
        [HideInInspector]
        public List<Transform> targetPoints;

        public FieldOfView view;
    }
}
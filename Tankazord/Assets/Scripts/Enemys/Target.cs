using UnityEngine;

namespace Princeps.Enemy
{
    public class Target : MonoBehaviour
    {
        public bool inSight { get; internal set; }

        private void Awake()
        {
        }

        private void Start()
        {
            this.inSight = false;
        }

        private void Update()
        {
        }
    }
}


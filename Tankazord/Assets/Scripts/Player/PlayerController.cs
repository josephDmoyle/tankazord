using UnityEngine;

namespace Princeps
{
    public class PlayerController : MonoBehaviour
    {

        public float moveSpeed;

        public Rigidbody rigidbody { get; private set; }

        public Camera mainCamera { get; private set; }

        private void Awake()
        {
            this.rigidbody = this.GetComponent<Rigidbody>();
            this.mainCamera = Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Get the mouse position on world coordinate
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            this.transform.LookAt(mousePosition + Vector3.up * transform.position.y);

        }

        private void FixedUpdate()
        {

        }
    }
}


using UnityEngine;

namespace Princeps.Enemy
{
    public class Target : MonoBehaviour
    {
        public Color targetedColor = Color.red;

        public bool inSight { get; internal set; }

        public Renderer meshRenderer  { get; private set; }

        private Color _cachedColor;

        private void Awake()
        {
            //this.meshRenderer = this.GetComponent<Renderer>( );
        }

        private void Start()
        {
            this.inSight = false;
            //_cachedColor = this.meshRenderer.material.color;
        }

        private void Update()
        {
            //if ( this.inSight && this.meshRenderer.material.color != targetedColor )
            //{
            //    this.meshRenderer.material.SetColor( "_Color", targetedColor );
            //}
            //else if ( !this.inSight && this.meshRenderer.material.color == targetedColor )
            //{
            //    this.meshRenderer.material.SetColor( "_Color", _cachedColor );
            //}
        }
    }
}


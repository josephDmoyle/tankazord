using UnityEngine;

namespace Princeps.Enemy
{
    [RequireComponent( typeof( Target ) )]
    public class TargetTinter : MonoBehaviour
    {
        public Renderer meshRenderer { get; private set; }

        public Color tintColor = Color.red;

        private Color _cachedColor;

        private Target _target;

        private void Awake()
        {
            _target = this.GetComponent<Target>( );
            this.meshRenderer = this.GetComponent<Renderer>( );
        }

        private void Start()
        {
            _cachedColor = this.meshRenderer.material.color;
        }

        private void Update()
        {
            if ( _target.inSight && this.meshRenderer.material.color != tintColor )
            {
                this.meshRenderer.material.SetColor( "_Color", tintColor );
            }
            else if ( !_target.inSight && this.meshRenderer.material.color == tintColor )
            {
                this.meshRenderer.material.SetColor( "_Color", _cachedColor );
            }
        }
    }
}


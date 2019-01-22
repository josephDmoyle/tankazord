using System.Linq;
using UnityEngine;

namespace Princeps.Player
{
    public class Missile : MonoBehaviour
    {
        public float explosionRadius;

        public float instantiateHeight;

        private void OnCollisionEnter( Collision collision )
        {
            var bitLayerMask_Ground = 1 << LayerMask.NameToLayer( "Ground" );
            var bitLayerMask_Target = 1 << LayerMask.NameToLayer( "Target" );
            var combineLayerMask = bitLayerMask_Ground | bitLayerMask_Target;
            var colliderLayerMask = 1 << collision.collider.gameObject.layer;
            if ( ( colliderLayerMask & combineLayerMask ) != 0 )
            {
                Debug.Log( "The missile exploded" );
                var collidersInSphere = Physics.OverlapSphere( this.transform.position, this.explosionRadius, bitLayerMask_Target ).ToList( );
                for ( int i = collidersInSphere.Count - 1; i >= 0; --i )
                {
                    var curCollider = collidersInSphere[i];
                    if ( curCollider != null )
                    {
                        collidersInSphere.RemoveAt( i );
                    }
                    Destroy( curCollider.gameObject );
                }
                Destroy( this.gameObject );
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace Princeps.Targets
{
    [RequireComponent( typeof( UICircle ) )]
    public class TargetIndicator : MonoBehaviour
    {
        public float lineThickness = 5.0f;

        private UICircle _uicr;

        private void Awake()
        {
            _uicr = this.GetComponent<UICircle>( );
        }

        private void Start()
        {

        }
    }
}
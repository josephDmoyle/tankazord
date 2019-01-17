using UnityEngine;

public class DisplaySetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Activate the display screen( Assuming that there are only three screens )
        if ( Display.displays.Length > 1 )
        {
            Display.displays[1].Activate();
        }
        if ( Display.displays.Length > 2 )
        {
            Display.displays[2].Activate();
        }
    }
}

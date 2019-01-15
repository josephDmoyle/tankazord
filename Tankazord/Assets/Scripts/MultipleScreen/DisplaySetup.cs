using UnityEngine;

public class DisplaySetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Activate the display screen
        if ( Display.displays.Length > 1 )
        {
            Display.displays[1].Activate();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

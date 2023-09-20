using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices;

public class MyAwesomeFlashlightIOS : MonoBehaviour
{
    
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void _SetTouchLevel(float level);
    [DllImport("__Internal")]
    private static extern void _TurnOn();
    [DllImport("__Internal")]
    private static extern void _TurnOff();
#endif

    public void TurnOn()
    {
#if UNITY_IOS
        _TurnOn();
#endif
    }

    public void TurnOff()
    {
#if UNITY_IOS
        _TurnOff();
#endif
    }

    // it seems like you can adjust intensity of flashlight but I didn't test that
    public void SetTourchLevelFromUI(float level)
	{
        _SetTouchLevel(level);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPlugin : MonoBehaviour
{
    public AndroidJavaClass javaObject;
    void Start()
    {
        javaObject = new AndroidJavaClass("com.myflashlight.flashlightlib.Flashlight");
    }

    public void TurnOn()
    {
        javaObject.CallStatic("on", GetUnityActivity());
    }
    
    public void TurnOff()
    {
        javaObject.CallStatic("off", GetUnityActivity());
    }
    
     AndroidJavaObject GetUnityActivity(){
         using ( var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
         {
             return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
         }
     }

        
        
}

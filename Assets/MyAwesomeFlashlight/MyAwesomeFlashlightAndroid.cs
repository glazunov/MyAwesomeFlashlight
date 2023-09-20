using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAwesomeFlashlightAndroid : MonoBehaviour
{
#if UNITY_ANDROID

    public AndroidJavaClass javaObject;
#endif

    void Start()
    {
#if UNITY_ANDROID
        javaObject = new AndroidJavaClass("com.myflashlight.flashlightlib.Flashlight");
#endif
    }

    public void TurnOn()
    {
#if UNITY_ANDROID
        javaObject.CallStatic("on", GetUnityActivity());
#endif
    }
    
    public void TurnOff()
    {
#if UNITY_ANDROID

        javaObject.CallStatic("off", GetUnityActivity());
#endif

    }
#if UNITY_ANDROID
    AndroidJavaObject GetUnityActivity(){
         using ( var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
         {
             return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
         }
     }
#endif


}

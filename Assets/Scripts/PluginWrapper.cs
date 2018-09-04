using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluginWrapper : MonoBehaviour
{
    public static string json;
    public Text jotain;
    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject unityContext;
    AndroidJavaClass customClass;

    float[] longitude;
    float[] latitude;

    void Start()
     {
         //Replace with your full package name
         //sendActivityReference("com.example.geofencing.PluginClass");

         //Now, start service
         //startService();
     }



     void sendActivityReference(string packageName)
     {
         unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
         unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
         unityContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");

         customClass = new AndroidJavaClass(packageName);
         customClass.CallStatic("receiveContextInstance", unityContext);
     }


     void startService()
     {
        JsonObject myObject = new JsonObject();
        myObject.longitude = 24.3f;
        myObject.latitude = 22.2f;
        json = JsonUtility.ToJson(myObject);
        Debug.Log(json);
        jotain.text = customClass.CallStatic<string>("StartCheckerService", json);

     }

    [Serializable]
    private class JsonObject
    {
        public float longitude;
        public float latitude;


    }

}


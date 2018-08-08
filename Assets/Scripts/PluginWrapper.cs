using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluginWrapper : MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start () {
        var plugin = new AndroidJavaClass("com.example.geofencing.PluginClass");
        text.text = plugin.CallStatic<string>("GetTextFromPlugin", 7);


    }

}

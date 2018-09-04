using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public Button FixedRoute;
    public Button MakeYourOwnRoute;

	// Use this for initialization
	void Start () {

        FixedRoute.onClick.AddListener(FixedRouteScene);
        MakeYourOwnRoute.onClick.AddListener(MakeYourOwnRouteScene);

    }

    void FixedRouteScene()
    {
        SceneManager.LoadScene(1);
    }

    void MakeYourOwnRouteScene()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

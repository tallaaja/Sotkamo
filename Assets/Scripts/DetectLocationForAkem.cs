
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DetectLocationForAkem : MonoBehaviour {

    private bool firstlocationPlayed, secondlocationPlayed, thirdlocationPlayed, fourthlocationPlayed = false;

    private bool enableByRequest = true;
    private bool running;
    private int maxWait = 10;
    private float dLatitude1 = 60.16953f, dLongitude1 = 24.93390f;
    private float dLatitude2 = 60.169599f, dLongitude2 = 24.9343199f;
    private float dLatitude3 = 60.1681299f, dLongitude3 = 24.9351198f;
    private float dLatitude4 = 60.1681299f, dLongitude4 = 24.9351198f;
    public AudioSource location1Audio;
    public VideoPlayer location1Video;
    public AudioSource location3Audio;
    public VideoPlayer location3Video;
    public float sLatitude, sLongitude;
    private bool ready = false;
    private float distanceFromTarget = 0.0004f;
    private float proximity = 0.001f;
    public Text text;
    private Vector2 deviceCoordinates;
    private Vector2 targetCoordinates1, targetCoordinates2, targetCoordinates3, targetCoordinates4;
    public GameObject location2, location3, location4;

    
    // Use this for initialization
    void Start () {
        targetCoordinates1 = new Vector2(dLatitude1, dLongitude1);
        targetCoordinates2 = new Vector2(dLatitude2, dLongitude2);
        targetCoordinates3 = new Vector2(dLatitude3, dLongitude3);
        targetCoordinates4 = new Vector2(dLatitude4, dLongitude4);

        //var firstPermission = AndroidPermissionsManager.RequestPermission("android.permission.ACCESS_FINE_LOCATION");


        /*if (firstPermission == null)
        {
            text.text += "null";
        }*/

        //firstPermission.WaitForCompletion();

        StartCoroutine(getLocation());

    }
    public void startGetLocation()
    {
        StartCoroutine(getLocation());
        text.text += "GETLOCATION UUDESTAAN";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator getLocation()
    {
        running = true;

        LocationService service = Input.location;
        if (!enableByRequest && !service.isEnabledByUser)
        {
            Debug.Log("Location Services not enabled by user");
            yield break;
        }

        service.Start();


        while (service.status == LocationServiceStatus.Initializing && maxWait > 3)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }
        if (service.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            text.text = "Target Location : " + dLatitude1 + ", " + dLongitude1 + "\nMy Location: " + service.lastData.latitude + ", " + service.lastData.longitude;
            sLatitude = service.lastData.latitude;
            sLongitude = service.lastData.longitude;
        }
        //service.Stop();
        ready = true;
        startCalculate();

        //Debug.Log("wait" + sLatitude + sLongitude);
        yield return new WaitForSeconds(1);
        StartCoroutine(getLocation());

    }

    public void startCalculate()
    {
        deviceCoordinates = new Vector2(sLatitude, sLongitude);

        
        if(firstlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates1, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                location1Audio.Play();
                location1Video.Play();
                firstlocationPlayed = true;
            }
        }

        else if (secondlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates2, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                location2.SetActive(true);
                secondlocationPlayed = true;
            }
        }

        else if (thirdlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates3, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                location3.SetActive(true);
                location3Audio.Play();
                location3Video.Play();
                thirdlocationPlayed = true;
            }
        }

        else if (fourthlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates4, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                location4.SetActive(true);
            }
        }




    }
}

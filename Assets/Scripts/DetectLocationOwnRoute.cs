using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DetectLocationOwnRoute : MonoBehaviour
{

    private bool running;
    private bool enableByRequest = true;
    private int maxWait = 10;
    public Text text;
    private bool ready = false;
    private float proximity = 0.001f;
    private Vector2 deviceCoordinates;
    private float distanceFromTarget = 0.0004f;

    public Button[] locationbuttons;

    private float dLatitude1 = 60.169539f, dLongitude1 = 24.933901f;
    private float dLatitude2 = 60.169539f, dLongitude2 = 24.933901f;
    private float dLatitude3 = 60.169539f, dLongitude3 = 24.933901f;
    private float dLatitude4 = 60.169539f, dLongitude4 = 24.933901f;
    private float dLatitude5 = 60.169539f, dLongitude5 = 24.933901f;
    private float dLatitude6 = 60.169539f, dLongitude6 = 24.933901f;
    private float dLatitude7 = 60.169539f, dLongitude7 = 24.933901f;
    private float dLatitude8 = 60.169539f, dLongitude8 = 24.933901f;
    private float dLatitude9 = 60.169539f, dLongitude9 = 24.933901f;
    private float dLatitude10 = 60.169539f, dLongitude10 = 24.933901f;
    private float dLatitude11 = 60.169539f, dLongitude11 = 24.933901f;
    private float dLatitude12 = 60.169539f, dLongitude12 = 24.933901f;
    private float dLatitude13 = 60.169539f, dLongitude13 = 24.933901f;
    private float dLatitude14 = 60.169539f, dLongitude14 = 24.933901f;
    private float dLatitude15 = 60.169539f, dLongitude15 = 24.933901f;
    public float sLatitude, sLongitude;
    private Vector2 targetCoordinates1, targetCoordinates2, targetCoordinates3, targetCoordinates4, targetCoordinates5, targetCoordinates6,
        targetCoordinates7, targetCoordinates8, targetCoordinates9, targetCoordinates10, targetCoordinates11, targetCoordinates12,
        targetCoordinates13, targetCoordinates14, targetCoordinates15;


    // Use this for initialization
    void Start()
    {
        targetCoordinates1 = new Vector2(dLatitude1, dLongitude1);
        StartCoroutine(getLocation());
        locationbuttons[0].onClick.AddListener(zero);

    }
    
    void zero()
    {

    }
    // Update is called once per frame
    void Update()
    {

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
        proximity = Vector2.Distance(targetCoordinates1, deviceCoordinates);

        if (proximity <= distanceFromTarget)
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DetectLocationForAkem : MonoBehaviour {

    private bool firstlocationPlayed, secondlocationPlayed, thirdlocationPlayed, fourthlocationPlayed, fifthlocationPlayed, sixthlocationPlayed, seventhlocationPlayed = false;

    private bool enableByRequest = true;
    private bool running;
    private int maxWait = 10;
    private float dLatitude1 = 60.169539f, dLongitude1 = 24.933901f;
    private float dLatitude2 = 60.169599f, dLongitude2 = 24.9343199f;
    private float dLatitude3 = 60.1681299f, dLongitude3 = 24.9351198f;
    private float dLatitude4 = 60.1660300f, dLongitude4 = 24.9394399f;
    private float dLatitude5 = 60.1676000f, dLongitude5 = 24.94540013f;
    private float dLatitude6 = 60.1675900f, dLongitude6 = 24.95145991f;
    private float dLatitude7 = 60.17003991f, dLongitude7 = 24.9522099f;
    public VideoPlayer location1Video;
    public VideoPlayer location3Video;
    public VideoPlayer location7Video;
    public float sLatitude, sLongitude;
    private bool ready = false;
    private float distanceFromTarget = 0.0004f;
    private float proximity = 0.001f;
    public Text text;
    private Vector2 deviceCoordinates;
    private Vector2 targetCoordinates1, targetCoordinates2, targetCoordinates3, targetCoordinates4, targetCoordinates5, targetCoordinates6, targetCoordinates7;
    public GameObject location1, location2, location3, location4, location5, location6, location7;
    public GameObject infotext1, infotext2, infotext3, infotext4, infotext5, infotext6, infotext7;
    public Button ExitButton;
    public GameObject ExitButtonObj;
    private int currlocation;
    public GameObject vuokattilogi;
    
    // Use this for initialization
    void Start () {
        targetCoordinates1 = new Vector2(dLatitude1, dLongitude1);
        targetCoordinates2 = new Vector2(dLatitude2, dLongitude2);
        targetCoordinates3 = new Vector2(dLatitude3, dLongitude3);
        targetCoordinates4 = new Vector2(dLatitude4, dLongitude4);
        targetCoordinates5 = new Vector2(dLatitude5, dLongitude5);
        targetCoordinates6 = new Vector2(dLatitude6, dLongitude6);
        targetCoordinates7 = new Vector2(dLatitude7, dLongitude7);

        ExitButton.onClick.AddListener(ExitButtonPressed);

        //var firstPermission = AndroidPermissionsManager.RequestPermission("android.permission.ACCESS_FINE_LOCATION");


        /*if (firstPermission == null)
        {
            text.text += "null";
        }*/

        //firstPermission.WaitForCompletion();

        StartCoroutine(getLocation());

    }

    public void ExitButtonPressed()
    {
        if(currlocation == 1)
        {
            infotext2.SetActive(true);
        }
        else if(currlocation == 2)
        {
            infotext3.SetActive(true);
        }
        else if (currlocation == 3)
        {
            infotext4.SetActive(true);
        }
        else if (currlocation == 4)
        {
            infotext5.SetActive(true);
        }
        else if (currlocation == 5)
        {
            infotext6.SetActive(true);
        }
        else if (currlocation == 6)
        {
            infotext7.SetActive(true);
        }

        startGetLocation();
        setAllLocationsToFalse();
        

    }


    private void setAllLocationsToFalse()
    {
        location1.SetActive(false);
        location2.SetActive(false);
        location3.SetActive(false);
        location4.SetActive(false);
        location5.SetActive(false);
        location6.SetActive(false);
        location7.SetActive(false);
    }

    public void startGetLocation()
    {
        StartCoroutine(getLocation());
        text.text += "GETLOCATION UUDESTAAN";
    }
	
	// Update is called once per frame
	void Update () {
        if (location1Video.isPlaying)
        {
            vuokattilogi.SetActive(false);
        }
        else
            vuokattilogi.SetActive(true);

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

    public void closeAllInfos()
    {
        infotext1.SetActive(false);
        infotext2.SetActive(false);
        infotext3.SetActive(false);
        infotext4.SetActive(false);
        infotext5.SetActive(false);
        infotext6.SetActive(false);
        infotext7.SetActive(false);
    }

    public void startCalculate()
    {
        deviceCoordinates = new Vector2(sLatitude, sLongitude);

        
        if(firstlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates1, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                currlocation = 1;
                location1.SetActive(true);
                location1Video.Play();
                firstlocationPlayed = true;
                StopAllCoroutines();
                ExitButtonObj.SetActive(true);
                closeAllInfos();

              
            }
        }

        else if (secondlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates2, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                currlocation = 2;
                location2.SetActive(true);
                secondlocationPlayed = true;
                StopAllCoroutines();
                ExitButtonObj.SetActive(true);
                closeAllInfos();
            }
        }

        else if (thirdlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates3, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                currlocation = 3;
                location3.SetActive(true);
                location3Video.Play();
                thirdlocationPlayed = true;
                StopAllCoroutines();
                ExitButtonObj.SetActive(true);
                closeAllInfos();
            }
        }

        else if (fourthlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates4, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                currlocation = 4;
                location4.SetActive(true);
                fourthlocationPlayed = true;
                StopAllCoroutines();
                ExitButtonObj.SetActive(true);
                closeAllInfos();
            }
        }

        else if (fifthlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates5, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                currlocation = 5;
                location5.SetActive(true);
                fifthlocationPlayed = true;
                StopAllCoroutines();
                ExitButtonObj.SetActive(true);
                closeAllInfos();
            }
        }

        else if (sixthlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates6, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                currlocation = 6;
                location6.SetActive(true);
                sixthlocationPlayed = true;
                StopAllCoroutines();
                ExitButtonObj.SetActive(true);
                closeAllInfos();
            }
        }

        else if (seventhlocationPlayed == false)
        {
            proximity = Vector2.Distance(targetCoordinates7, deviceCoordinates);
            if (proximity <= distanceFromTarget)
            {
                currlocation = 7;
                location7.SetActive(true);
                location7Video.Play();
                seventhlocationPlayed = true;
                StopAllCoroutines();
                ExitButtonObj.SetActive(true);
                closeAllInfos();
            }
        }




    }
}

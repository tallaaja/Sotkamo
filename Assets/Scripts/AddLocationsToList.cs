using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddLocationsToList : MonoBehaviour {

    public List<int> locations = new List<int>();

    private float dLatitude1 = 60.169539f, dLongitude1 = 24.933909f;
    private float dLatitude2 = 60.169599f, dLongitude2 = 24.9343199f;
    private float dLatitude3 = 60.1681299f, dLongitude3 = 24.9351198f;
    private float dLatitude4 = 60.1660300f, dLongitude4 = 24.9394399f;
    private float dLatitude5 = 60.945400f, dLongitude5 = 24.945400f;
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
    private Vector2 targetCoordinates1, targetCoordinates2, targetCoordinates3, targetCoordinates4, targetCoordinates5, targetCoordinates6,
        targetCoordinates7, targetCoordinates8, targetCoordinates9, targetCoordinates10, targetCoordinates11, targetCoordinates12,
        targetCoordinates13, targetCoordinates14, targetCoordinates15;
    private int number;
    public Text listofRoutes;

    // Use this for initialization
    void Start () {

        targetCoordinates1 = new Vector2(dLatitude1, dLongitude1);
        targetCoordinates2 = new Vector2(dLatitude2, dLongitude2);
        targetCoordinates3 = new Vector2(dLatitude3, dLongitude3);
        targetCoordinates4 = new Vector2(dLatitude4, dLongitude4);
        targetCoordinates5 = new Vector2(dLatitude5, dLongitude5);
        targetCoordinates6 = new Vector2(dLatitude6, dLongitude6);
        targetCoordinates7 = new Vector2(dLatitude7, dLongitude7);
        targetCoordinates8 = new Vector2(dLatitude8, dLongitude8);
        targetCoordinates9 = new Vector2(dLatitude9, dLongitude9);
        targetCoordinates10 = new Vector2(dLatitude10, dLongitude10);
        targetCoordinates11 = new Vector2(dLatitude11, dLongitude11);
        targetCoordinates12 = new Vector2(dLatitude12, dLongitude12);
        targetCoordinates13 = new Vector2(dLatitude13, dLongitude13);
        targetCoordinates14 = new Vector2(dLatitude14, dLongitude14);
        targetCoordinates15 = new Vector2(dLatitude15, dLongitude15);


    }

    public void addLocation(int number)
    {
        locations.Add(number);
        listofRoutes.text += number.ToString() + "\n";
        Debug.Log(number.ToString());
    }

    public Vector2 returnCoordinates(int number)
    {
        switch (number)
        {
            case 1:
                return targetCoordinates1;
                break;
            case 2:
                return targetCoordinates2;
                break;
            case 3:
                return targetCoordinates3;
                break;
            case 4:
                return targetCoordinates4;
                break;
            case 5:
                return targetCoordinates5;
                break;
            case 6:
                return targetCoordinates6;
                break;
            case 7:
                return targetCoordinates7;
                break;
            case 8:
                return targetCoordinates8;
                break;
            case 9:
                return targetCoordinates9;
                break;
            case 10:
                return targetCoordinates10;
                break;
            case 11:
                return targetCoordinates11;
                break;
            case 12:
                return targetCoordinates12;
                break;
            case 13:
                return targetCoordinates13;
                break;
            case 14:
                return targetCoordinates14;
                break;
            case 15:
                return targetCoordinates15;
                break;

            default:
                return new Vector2(0, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

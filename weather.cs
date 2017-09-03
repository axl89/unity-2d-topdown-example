using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;
using System;

public class weather : MonoBehaviour
{

    public Text tempUI;
    public Text weatherUI;
    public Text locationUI;
    public Button fabb;
    public Sprite t1;
    public Sprite t2;
    public Sprite t3;
    public Sprite t4;
    public Sprite t5;
    public Sprite t6;
    public Sprite t7;
    public Sprite t8;
    public Sprite t9;
    public Sprite w1; // clear
    public Sprite w2; // clouds
    public Sprite w3; // rain
    public GameObject fab; 
    public GameObject termo;
    public GameObject weatherIcon;
    public InputField locationchangeUI;
    public InputField countrychangeUI;
    public Text locationField;
    public Text countryField;
    static string fetchedWeather;
    protected int j;
    string temp;
    public float temperature;
    public string cWeather;
    public string location;
    public string country;

    void Start()
    {
        if (PlayerPrefs.GetInt("first") == 0)
        {
            PlayerPrefs.SetString("deflocation", "Madrid");
            PlayerPrefs.SetString("defcountry", "es");
        }
        StartCoroutine(GetWeather());
        j = 0;
        location = PlayerPrefs.GetString("deflocation");
        country = PlayerPrefs.GetString("defcountry");
    }

    IEnumerator GetWeather()
    {
        //fetching and storing information
        if (locationchangeUI.text != "")
        {
            location = locationchangeUI.text;
            PlayerPrefs.SetInt("first", 1);
        }
        if (countrychangeUI.text != "")
            country = countrychangeUI.text;
        WWW www = new WWW("http://api.openweathermap.org/data/2.5/find?q=" + location + "," + country + "&type=accurate&mode=html&lang=nl&units=metric&appid=8db4fb8f632ec5a7a0f6bb5053b0f884");

        yield return www;

        fetchedWeather = www.text;
        temp = getBetween(fetchedWeather, "\"temp\":", ",\"pressure\"");
        temperature = float.Parse(temp, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        temperature = (int)temperature;
        tempUI.text = temperature.ToString();
        cWeather = getBetween(fetchedWeather, "main\":\"", "\"");
        weatherUI.text = cWeather;
        locationUI.text = location;
        if (cWeather.Contains("Clear"))
        {
            weatherIcon.GetComponent<Image>().sprite = w1;
        }
        if (cWeather.Contains("Clouds"))
        {
            weatherIcon.GetComponent<Image>().sprite = w2;
        }
        if (cWeather.Contains("Thunderstorm"))
        {
            weatherIcon.GetComponent<Image>().sprite = w3;
        }
        if (cWeather.Contains("Rain"))
        {
            weatherIcon.GetComponent<Image>().sprite = w3;
        }
        if (cWeather.Contains("Snow"))
        {
            weatherIcon.GetComponent<Image>().sprite = w3;
        }
        if (cWeather.Contains("Extreme"))
        {
            weatherIcon.GetComponent<Image>().sprite = w1;
        }
        if (cWeather.Contains("Additional"))
        {
            weatherIcon.GetComponent<Image>().sprite = w1;
        }
        if (cWeather.Contains("Atmosphere"))
        {
            weatherIcon.GetComponent<Image>().sprite = w2;
        }
        if (cWeather.Contains("Drizzle"))
        {
            weatherIcon.GetComponent<Image>().sprite = w3;
        }
        //thermometer
        if (temperature <= 0)
        {
            termo.GetComponent<SpriteRenderer>().sprite = t1;
        }
        if (temperature > 0 && temperature <= 5)
        {
            termo.GetComponent<SpriteRenderer>().sprite = t2;
        }
        if (temperature > 5 && temperature <= 10)
        {
            termo.GetComponent<SpriteRenderer>().sprite = t3;
        }
        if (temperature > 10 && temperature <= 20)
        {
            termo.GetComponent<SpriteRenderer>().sprite = t4;
        }
        if (temperature > 20 && temperature <= 25)
        {
            termo.GetComponent<SpriteRenderer>().sprite = t5;
        }
        if (temperature > 25 && temperature <= 35)
        {
            termo.GetComponent<SpriteRenderer>().sprite = t6;
        }
        if (temperature > 35 && temperature <= 40)
        {
            termo.GetComponent<SpriteRenderer>().sprite = t7;
        }
        if (temperature > 40)
        {
            termo.GetComponent<SpriteRenderer>().sprite = t8;
        }
    }

    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        int Start, End;
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }
        else
        {
            return "";
        }
    }

    public void Fab(int i)
    { 
        if (j == 1)
        {
            if (i == 1)
            {
                fab.GetComponent<Animation>().Play("hide");
                fabb.enabled = false;
                StartCoroutine(delay1());
                i = 0;
                j = 0;
            }
        }
        if (j == 0)
        {
            if (i == 1)
            {
                fab.GetComponent<Animation>().Play("show");
                fabb.enabled = false;
                StartCoroutine(delay1());
                j = 1;
            }
        }
        else
        {

        }
    }

    IEnumerator delay1()
    {
        yield return new WaitForSeconds(0.25f);
        fabb.enabled = true;
    }

    void Update()
    {
        locationField.text = location;
        countryField.text = country;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void refresh(int i)
    {
        if (i == 1)
        {
            StartCoroutine(GetWeather());
            i = 0;
        }
        else
        {

        }
    }

    public void defaultSet(int i)
    {
        if (i == 1)
        {
            if (locationchangeUI.text != "")
            {
                PlayerPrefs.SetString("deflocation", locationchangeUI.text);
                PlayerPrefs.SetInt("first", 1);
            }
            if (countrychangeUI.text != "")
                PlayerPrefs.SetString("defcountry", countrychangeUI.text);
            i = 0;
        }
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class timetable : MonoBehaviour
{

    public GameObject popUp;
    public GameObject inputField;
    public GameObject inputFieldtB;
    public GameObject inputFieldcB;
    public InputField taskField;
    public Text slotTask;
    public int weekDays;
    public int slots;
    public int one;
    public int two;

    protected bool isTasking;
    protected string[,] buttons; //Need 49 copies (7 days x 7 slots)


    /*
     * Initialize the buttons bidimensional array given weekDays and slots
     */
    protected void initializeButtons()
    {
        for (int day = 0; day < weekDays; day++)
        {
            for (int slot = 0; slot < slots; slot++)
            {
                buttons[day, slot] = "";
            }

        }
    }
    // Use this for initialization
    void Start()
    {
        weekDays = 7; //7 days a week
        slots = 7; //7 slots per day
        buttons = new string[weekDays, slots]; // Makes a bidimensional array of 7x7

        initializeButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTasking == true)
        {
            //GameObject.Find("slot").GetComponent<Image>().enabled = true; FIXME
        }
        if (isTasking == false)
        {
            //GameObject.Find("slot").GetComponent<Image>().enabled = false; FIXME
        }
        PlayerPrefs.SetString("clipboardTask", taskField.text);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("main");
        }

    }

    public void addTask(int i)
    {
        if (i == 1)
        {
            isTasking = true;
            inputFieldcB.GetComponent<Button>().enabled = true;
            inputField.GetComponent<Animation>().Play("emerge");
            inputFieldtB.GetComponent<Button>().enabled = false;
            i = 0;
        }
        else
        {

        }
    }
    public void closeTask(int i)
    {
        if (i == 1)
        {
            isTasking = false;
            inputFieldtB.GetComponent<Button>().enabled = true;
            inputField.GetComponent<Animation>().Play("immerse");
            inputFieldcB.GetComponent<Button>().enabled = false;
            i = 0;
        }
        else
        {

        }
    }

    public void day1(int i) //working on this
    {
        if (i == 1)
        {
            one = 0;
            i = 0;
        }
        else
        {

        }

    }
    public void day2(int i) //working on this
    {
        if (i == 1)
        {
            one = 1;
            i = 0;

        }
        else
        {

        }

    }

    public void day3(int i) //working on this
    {
        if (i == 1)
        {
            one = 2;
            i = 0;

        }
        else
        {

        }

    }

    public void day4(int i) //working on this
    {
        if (i == 1)
        {
            one = 3;
            i = 0;

        }
        else
        {

        }

    }

    public void day5(int i) //working on this
    {
        if (i == 1)
        {
            one = 4;
            i = 0;

        }
        else
        {

        }

    }

    public void day6(int i) //working on this
    {
        if (i == 1)
        {
            one = 5;
            i = 0;
        }
        else
        {

        }

    }

    public void day7(int i) //working on this
    {
        if (isTasking == true)
        {
            if (i == 1)
            {
                one = 6;
                i = 0;
            }
            else
            {

            }
        }

    }

    public void slot1(int i) //working on this
    {
        if (i == 1)
        {
            two = 0;
            if (isTasking == true)
            {
                buttons[one, two] = PlayerPrefs.GetString("clipboardTask");
            }
            i = 0;
        }
        else
        {

        }

    }

    public void slot2(int i) //working on this
    {
        if (i == 1)
        {
            two = 1;
            if (isTasking == true)
            {
                buttons[one, two] = PlayerPrefs.GetString("clipboardTask");
            }
            i = 0;
        }
        else
        {

        }

    }

    public void slot3(int i) //working on this
    {
        if (i == 1)
        {
            two = 2;
            if (isTasking == true)
            {
                buttons[one, two] = PlayerPrefs.GetString("clipboardTask");
            }
            i = 0;
        }
        else
        {

        }

    }

    public void slot4(int i) //working on this
    {
        if (i == 1)
        {
            two = 3;
            if (isTasking == true)
            {
                buttons[one, two] = PlayerPrefs.GetString("clipboardTask");
            }
            i = 0;
        }
        else
        {

        }
    }

    public void slot5(int i) //working on this
    {
        if (i == 1)
        {
            two = 4;
            if (isTasking == true)
            {
                buttons[one, two] = PlayerPrefs.GetString("clipboardTask");
            }
            i = 0;
        }
        else
        {

        }

    }

    public void slot6(int i) //working on this
    {
        if (i == 1)
        {
            two = 5;
            if (isTasking == true)
            {
                buttons[one, two] = PlayerPrefs.GetString("clipboardTask");
            }
            i = 0;
        }
        else
        {

        }

    }

    public void slot7(int i) //working on this
    {
        if (i == 1)
        {
            two = 6;
            if (isTasking == true)
            {
                buttons[one, two] = PlayerPrefs.GetString("clipboardTask");
            }
            i = 0;
        }
        else
        {

        }

    }

    public void editTask(int i)
    {
        if (isTasking == true)
        {
            if (i == 1)
            {

            }
            else
            {

            }
        }

    }

    public void showTask(int i)
    {
        if (isTasking == false)
        {
            if (i == 1)
            {
                slotTask.text = buttons[one, two];
                popUp.GetComponent<Animation>().Play("slide");
                i = 0;
            }
            else
            {

            }
        }

    }
    public void exitPopup(int i)
    {
        if (isTasking == false)
        {
            if (i == 1)
            {
                popUp.GetComponent<Animation>().Play("fade");
                i = 0;
            }
            else
            {

            }
        }

    }
}

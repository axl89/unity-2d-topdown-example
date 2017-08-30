using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timetable : MonoBehaviour
{

    public GameObject popUp;
    public GameObject inputField;
    public GameObject inputFieldtB;
    public GameObject inputFieldcB;
    public int weekDays;
    public int slots;

    protected bool isTasking;
    protected string[][] buttons; //Need 49 copies (7 days x 7 slots)


    /*
     * Initialize the buttons bidimensional array given weekDays and slots
     */
    protected void initializeButtons()
    {
        for(int day = 0; day < weekDays; day++)
        {
            for (int slot = 0; slot < slots; slot++)
            {
                buttons[day,slot] = "";
            }
            
        }
    }
    // Use this for initialization
    void Start()
    {
        weekDays = 7; //7 days a week
        slots = 7; //7 slots per day
        buttons = new string[weekDays,slots]; // Makes a bidimensional array of 7x7

        initializeButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTasking == true)
        {
            GameObject.FindWithTag("gap").GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            GameObject.FindWithTag("gap").GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
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
    public void editTask(int i)
    {
        if (isTasking == true)
        {
            if (i == 1)
            {
                //do something along the lines of replacing the needed string with the text of an input field (already existing) 
            }
            else
            {

            }
        }

    }
}

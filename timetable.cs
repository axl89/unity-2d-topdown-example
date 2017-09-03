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

    protected bool isTasking;
    protected string[,] buttons; //Need 49 copies (7 days x 7 slots)
    

    /*
     * Initialize the buttons bidimensional array given weekDays and slots
     */
    protected void initializeButtons()
    {
        for(int day = 0; day < weekDays; day++)
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
        buttons = new string[weekDays,slots]; // Makes a bidimensional array of 7x7

        initializeButtons();
    }


    // Update is called once per frame
    void Update()
    {

        PlayerPrefs.SetString("clipboardTask", taskField.text);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("main");
        }

    }


    public void showTaskBar() { 
 
        isTasking = true;
        inputFieldcB.GetComponent<Button>().enabled = true;
        inputField.GetComponent<Animation>().Play("emerge");
        inputFieldtB.GetComponent<Button>().enabled = false;
 
    }
    

    public void closeTaskBar()
    {
        isTasking = false;
        inputFieldtB.GetComponent<Button>().enabled = true;
        inputField.GetComponent<Animation>().Play("immerse");
        inputFieldcB.GetComponent<Button>().enabled = false;
        
    }


    private int getRowFromButtonNumber(int button_number)
    {
        int row = Mathf.FloorToInt(button_number / weekDays);
        return row;
    }


    private int getColumnFromButtonNumber(int button_number)
    {
        int column = button_number % weekDays;
        return column;
    }


    //TODO: Edit a task
    public void editTask()
    {
    }

    public void buttonListener(int button_number)
    {
        int row = getRowFromButtonNumber(button_number);
        int column = getColumnFromButtonNumber(button_number);

        if (isTasking == false)
        {
            slotTask.text = buttons[row, column];
            popUp.GetComponent<Animation>().Play("slide");
        }
        else
        {
            try
            {
                buttons[row, column] = PlayerPrefs.GetString("clipboardTask");
                //TODO: This is the point where we could hide the task bar and maybe show a nice pop-up message? :)
                
            }
            catch
            {
                //Return false if row or column are off bounds (or maybe other exception)
                return;
            }
        }
    }


    public void exitPopup()
    {
        if (isTasking == false)
        {   
                popUp.GetComponent<Animation>().Play("fade");
        }

    }
}

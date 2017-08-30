using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timetable : MonoBehaviour {

    public GameObject popUp;
    public GameObject inputField;
    public GameObject inputFieldtB;
    public GameObject inputFieldcB;
    protected bool isTasking;
    protected string c1; //Need 49 copies
  


    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
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

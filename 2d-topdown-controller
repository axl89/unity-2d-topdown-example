using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hello_world : MonoBehaviour
{


    public float speed;
    protected bool isUserMoving;
    protected Dictionary<KeyCode, bool> pressedKeys;
    protected HashSet<KeyCode> allowedKeys;
    protected int numAllowedKeys;
    protected KeyCode rudder;

    private Dictionary<KeyCode, bool> initializeKeys()
    {
        Dictionary<KeyCode, bool> controls = new Dictionary<KeyCode, bool>();
        foreach (var key in allowedKeys)
        {
            controls.Add(key, false);
        }

        return controls;
    }

    private HashSet<KeyCode> getAllowedKeys()
    {

        HashSet<KeyCode> controls = new HashSet<KeyCode>();
        controls.Add(KeyCode.W);
        controls.Add(KeyCode.A);
        controls.Add(KeyCode.S);
        controls.Add(KeyCode.D);

        return controls;
    }

    void Start()
    {
        allowedKeys = getAllowedKeys();
        pressedKeys = initializeKeys();
        numAllowedKeys = allowedKeys.Count;
        isUserMoving = false;
        rudder = KeyCode.None;
    }

    private Dictionary<KeyCode, bool> getPressedKeys()
    {
        Dictionary<KeyCode, bool> pressedKeys = new Dictionary<KeyCode, bool>();

        foreach (var key in allowedKeys)
        {
            pressedKeys.Add(key, Input.GetKey(key));
        }

        return pressedKeys;
    }

    private bool getIsUserMoving()
    {

        foreach (var pair in pressedKeys)
        {
            if (pair.Value == true)
                return true;
        }

        return false;
    }


    private bool isANewKeyPressedButKey(KeyCode key, List<KeyCode> deltas)
    {
        foreach (var deltaKey in deltas)
        {
            if (deltaKey != key)
                return false;
        }

        return true;
    }

    private void move(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W:
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                break;
            case KeyCode.A:
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                break;

            case KeyCode.S:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;

            case KeyCode.D:
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Get the keys from the last frame
        Dictionary<KeyCode, bool> previousKeys = new Dictionary<KeyCode, bool>(pressedKeys);

        //Update the pressed keys
        pressedKeys = getPressedKeys();

        //See if user is moving
        isUserMoving = getIsUserMoving();

        if (isUserMoving)
        {
            //Get delta keys of pressed keys of this frame compared to the previous frame
            List<KeyCode> deltaKeys = new List<KeyCode>();

            //We iterate through the pressedKeys & previous keys to get the Deltas
            using (var e1 = pressedKeys.GetEnumerator())
            using (var e2 = previousKeys.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    var e1_current = e1.Current;
                    var e2_current = e2.Current;

                    if (e2_current.Value == false && e1_current.Value == true)
                    {
                        deltaKeys.Add(e1_current.Key);
                    }

                }
            }



            //To update the rudder, we must follow one of the two cases:
            if (deltaKeys.Count > 0)
                rudder = deltaKeys[0];
            else
            {
                //At this point it's safe to admit that some key is pressed (since isUserMoving is true), but MAYBE not the rudder one.
                bool isRudderPressed = pressedKeys[rudder] == true;

                if (isRudderPressed == false)
                {
                    //We must find the new rudder by searching the pressedKeys dictionary with the key with true value.
                    foreach (var pairs in pressedKeys)
                    {
                        if (pairs.Value == true)
                            rudder = pairs.Key;
                    }
                }


            }

            move(rudder);

        }


    }
}

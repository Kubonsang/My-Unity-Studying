using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Vector2 slideStartPosition;
    Vector2 prevPosition;
    Vector2 delta = Vector2.zero;
    bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            slideStartPosition = getCursorPosition();
        }

        if (Input.GetButton("Fire1"))
        {
            if(Vector2.Distance(slideStartPosition, getCursorPosition()) >= Screen.width * 0.1f)
            {
                moved = true;
            }
        }

        if(!Input.GetButtonUp("Fire1") && !Input.GetButton("Fire1"))
        {
            moved= false;
        }

        if(moved)
        {
            delta = getCursorPosition() - prevPosition;
        }
        else
        {
            delta = Vector2.zero;
        }

        prevPosition = getCursorPosition();
    }

    public bool Clicked()
    {
        return (!moved && Input.GetButtonUp("Fire1")) ? true : false;
    }

    public Vector2 getDeltaPosition()
    {
        return delta;
    }
    public bool Moved()
    {
        return moved;
    }

    public Vector2 getCursorPosition()
    {
        return Input.mousePosition;
    }

}

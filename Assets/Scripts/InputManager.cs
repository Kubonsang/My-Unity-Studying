using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Vector2 slideStartPosition;
    Vector2 prevPosition;
    Vector2 delta = Vector2.zero;

    // 마우스를 꾹 누른 상태로, 크게 움직이면 true
    bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 좌클릭시 그 클릭한 위치를 구한다.
        if(Input.GetButtonDown("Fire1"))
        {
            slideStartPosition = getCursorPosition();
        }

        // 마우스 좌클릭을 꾹 하고 있을 때, 마우스를 크게 움직이면 moved = true
        if (Input.GetButton("Fire1"))
        {
            if(Vector2.Distance(slideStartPosition, getCursorPosition()) >= Screen.width * 0.1f)
            {
                moved = true;
            }
        }

        // 마우스에서 손을 떼면, moved = false
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

    // 마우스 좌클릭을 떼면.
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

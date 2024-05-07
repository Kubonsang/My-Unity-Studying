using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    const float RayCastMaxDistance = 100.0f;
    InputManager inputManager;


    // Start is called before the first frame update
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Walking();
    }

    // ���콺 ��Ŭ���� Ǯ ��, �� ��ġ�� ���ϰ� �÷��̾ �̵���Ŵ.
    void Walking()
    {
        if (inputManager.Clicked())
        {
            Vector2 clickPos = inputManager.getCursorPosition();

            Ray ray = Camera.main.ScreenPointToRay(clickPos);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, RayCastMaxDistance, 1 << LayerMask.NameToLayer("Ground")))
            {
                SendMessage("SetDestination", hitInfo.point);
            }
        }
    }
}

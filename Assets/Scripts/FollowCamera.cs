using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public float distance = 5.0f;
    public float horizontalAngle = 0.0f;
    public float rotAngle = 180.0f; // 화면 가로폭만큼 커서를 이동시켰을 때 몇 도 회전하는가.
    public float verticalAngle = 10.0f;
    public Transform lookTarget;
    public Vector3 offset = Vector3.zero;
    public float speed = 0.1f;

    InputManager inputManager;
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;

        distance += scroll;
        distance = Mathf.Clamp(distance, 1.0f, 7.0f);

        // 드래그 입력으로 카메라 회전각을 갱신한다.
        if (inputManager.Moved())
        {
            float anglePerPixel = rotAngle / (float)Screen.width;
            // 마우스를 꾹 누른 채, 이동시켰을 때의 이동거리.nity 
            Vector2 delta = inputManager.getDeltaPosition();

            //캐릭터를 기준으로 좌우 각도
            horizontalAngle += delta.x * anglePerPixel;
            horizontalAngle = Mathf.Repeat(horizontalAngle, 360.0f);

            //캐릭터를 기준으로 위 아래 각도.
            verticalAngle -= delta.y * anglePerPixel;
            verticalAngle = Mathf.Clamp(verticalAngle, -60.0f, 60.0f);
        }

        // 카메라의 위치와 회전각을 갱신한다.
        if (lookTarget != null)
        {
            Vector3 lookPosition = lookTarget.position + offset;
            // 주시 대상에서 상대 위치를 구한다.
            Vector3 relativePos = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * new Vector3(0, 0, -distance);

            // 주시 대상의 위치에 오프셋을 더한 위치로 이동시킨다.
            transform.position = lookPosition + relativePos;

            // 주시 대상을 주시하게 한다.
            transform.LookAt(lookPosition);

            // 장애물을 피한다.
            RaycastHit hitInfo;
            if (Physics.Linecast(lookPosition, transform.position, out hitInfo, 1 << LayerMask.NameToLayer("Ground")))
                transform.position = hitInfo.point;
        }
    }
}

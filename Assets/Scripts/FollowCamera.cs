using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public float distance = 5.0f;
    public float horizontalAngle = 0.0f;
    public float rotAngle = 180.0f; // ȭ�� ��������ŭ Ŀ���� �̵������� �� �� �� ȸ���ϴ°�.
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

        // �巡�� �Է����� ī�޶� ȸ������ �����Ѵ�.
        if (inputManager.Moved())
        {
            float anglePerPixel = rotAngle / (float)Screen.width;
            // ���콺�� �� ���� ä, �̵������� ���� �̵��Ÿ�.nity 
            Vector2 delta = inputManager.getDeltaPosition();

            //ĳ���͸� �������� �¿� ����
            horizontalAngle += delta.x * anglePerPixel;
            horizontalAngle = Mathf.Repeat(horizontalAngle, 360.0f);

            //ĳ���͸� �������� �� �Ʒ� ����.
            verticalAngle -= delta.y * anglePerPixel;
            verticalAngle = Mathf.Clamp(verticalAngle, -60.0f, 60.0f);
        }

        // ī�޶��� ��ġ�� ȸ������ �����Ѵ�.
        if (lookTarget != null)
        {
            Vector3 lookPosition = lookTarget.position + offset;
            // �ֽ� ��󿡼� ��� ��ġ�� ���Ѵ�.
            Vector3 relativePos = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * new Vector3(0, 0, -distance);

            // �ֽ� ����� ��ġ�� �������� ���� ��ġ�� �̵���Ų��.
            transform.position = lookPosition + relativePos;

            // �ֽ� ����� �ֽ��ϰ� �Ѵ�.
            transform.LookAt(lookPosition);

            // ��ֹ��� ���Ѵ�.
            RaycastHit hitInfo;
            if (Physics.Linecast(lookPosition, transform.position, out hitInfo, 1 << LayerMask.NameToLayer("Ground")))
                transform.position = hitInfo.point;
        }
    }
}

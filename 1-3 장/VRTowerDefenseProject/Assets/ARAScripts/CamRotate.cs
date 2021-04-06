using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���콺 �Է¿� ���� ī�޶� ȸ����Ű�� �ʹ�.
// �ʿ� �Ӽ�: ���� ����, ���콺 ����
public class CamRotate : MonoBehaviour
{
    // ���� ����
    Vector3 angle;
    // ���콺 ����
    public float sensitivity = 200;

    void Start()
    {
        // ������ �� ���� ī�޶��� ������ �����Ѵ�.
        angle.y = -Camera.main.transform.eulerAngles.x;
        angle.x = Camera.main.transform.eulerAngles.y;
        angle.z = Camera.main.transform.eulerAngles.z;

        lastPos = Input.mousePosition;
    }

    Vector3 lastPos;
    void Update()
    {
        // ���콺 �Է¿� ���� ī�޶� ȸ����Ű�� �ʹ�.
        // 1. ������� ���콺 �Է��� ���;� �Ѵ�.
        // ���콺�� �¿� �Է��� �޴´�.
        //float x = Input.GetAxis("Mouse X");
        //float y = Input.GetAxis("Mouse Y");
        Vector3 mp = Input.mousePosition - lastPos;
        float x = Mathf.Clamp(mp.x, -1, 1);
        float y = Mathf.Clamp(mp.y, -1, 1);
        lastPos = Input.mousePosition;

        // 2. ������ �ʿ��ϴ�.
        // �̵� ���Ŀ� ������ �� �Ӽ����� ȸ�� ���� ������Ų��.
        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;

        // 3. ȸ����Ű�� �ʹ�.
        // ī�޶��� ȸ�� ���� ���� ������� ȸ�� ���� �Ҵ��Ѵ�.
        transform.eulerAngles = new Vector3(-angle.y, angle.x, transform.eulerAngles.z);
    }
}

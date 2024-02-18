using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Коэффициент чувствительности
    public float mouseSensetivity = 100f;

    //Сам объект FPS
    public Transform Controller;

    //Переменная, в которую будет записываться постоянно меняющиеся значение поворота
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Блокировка курсора
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Ввод по оси X и оси Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        //Ограничение угла обзора сверху и снизу, по 90 градусов каждое
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Поворот камеры по оси X
        Controller.Rotate(Vector3.up * mouseX);
    }
}

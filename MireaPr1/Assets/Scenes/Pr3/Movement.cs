using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Переменная со ссылкой на Character Controller
    public CharacterController characterController;

    // Параметр для изменения скорости передвижения
    public float speed = 12f;

    // Значение гравитационной постоянной (g) или просто гравитация
    public float gravity = -9.81f;

    // Переменная для хранения скорости падения
    public Vector3 velocity;

    public Transform GroundCheck;

    // Расстояние до земли, на котором будет триггериться невидимый объект
    public float groundDistance = 0.4f;

    // Маска для распознавания земли
    public LayerMask groundMask;

    // Переменная для хранения состояния нахождения на земле
    bool isGrounded;

    public float jumpForce = 1000;

    // Update is called once per frame
    void Update()
    {
        // Установка распознавания ввода сигналов с клавишь WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Логика изменения координат объекта, в зависимости от того, какие координаты вводятся (x или z).
        //          (forward)
        //              z
        //(left)-x            +x(right)
        //              -z
        //          (backward)
        Vector3 move = transform.right * x + transform.forward * z;

        // Вызов метода Move() на CC с формулой для передвижения
        characterController.Move(move * speed * Time.deltaTime);

        // Изменение координаты Y вектора скорости
        velocity.y += gravity * Time.deltaTime;

        // Вызов метода Move() на CC с формулой для падения
        // Из логики формулы ускорения свободного падения h = 1/2 * g * t^2
        // где h - высота, g - ускорение свободного падения, t - время
        characterController.Move((velocity*Time.deltaTime) / 2);

        // Переменная становится true, если невидимый объект, созданный в GroundCheck с радиусом groundDistance, сопприкасается со слоем groundMask
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        // Проверка истинности переменной isGrounded
        if (isGrounded && velocity.y < 0)
        {
            // Если переменная истинна, то скорость падения обнуляется
            // 2f - это значение, которое является оптимальным для плавного падения
            velocity.y = -2f;
        }

        // При нажатии на пробел и переменная isGrounded истинна, то объект будет подпрыгивать
        Debug.Log(isGrounded);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
}

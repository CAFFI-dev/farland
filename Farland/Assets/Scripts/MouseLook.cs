using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Tooltip("Чувствительность мыши")]
    public float mouseSensitivity = 3f;
    [Tooltip("Оффсет, позволяющий управлять расбросом")]
    public static float OffsetX= 0, OffsetY = 0;
    [Tooltip("Префаб игрока")]
    public Transform playerBody;
    //значение, расчитывающее поворот по координате x
    float xRotation = 0f;
    /// <summary>
    /// Закрепляем курсор чтобы его не было видно
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    /// <summary>
    /// Функция, меняющая оффсет
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public static void ChangeOffset(float x, float y)
    {
        OffsetX = x;
        OffsetY = y;
    }

    /// <summary>
    /// Обновление каждый кадр
    /// </summary>
    void Update()
    {
        //подбор значений ввода мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity + OffsetY;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity + OffsetX;
        //обнуление оффсета
        OffsetX = 0;
        OffsetY = 0;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        //выход из приложения (в едиторе не работает)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

    }
}

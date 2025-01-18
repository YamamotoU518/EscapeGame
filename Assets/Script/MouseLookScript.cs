using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookScript : MonoBehaviour
{
    public float mouseXSensitivity = 100f;
    public Transform _player;
    float xRotation = 0f;
    GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        //gameObject.transform.position = new Vector3(3.91f, 2.13f, 8.81f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameManager.CanvasVisible())
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            _player.Rotate(Vector3.up * mouseX);
        }
    }
}

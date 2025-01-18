using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpDown : MonoBehaviour
{
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraMove = GetComponent<Transform>().transform.up * 3f * Time.deltaTime;

        if (!_gameManager.CanvasVisible())
        {
            if (GetComponent<Transform>().position.y > 1.1)
            {
                if (Input.GetButton("Squat"))
                {
                    Vector3 _pos = GetComponent<Transform>().transform.position;
                    _pos.y -= cameraMove.y;
                    GetComponent<Transform>().transform.position = _pos;
                }
            }
            if (GetComponent<Transform>().position.y < 2.2)
            {
                if (!Input.GetButton("Squat"))
                {
                    Vector3 _pos = GetComponent<Transform>().transform.position;
                    _pos.y += cameraMove.y;
                    GetComponent<Transform>().transform.position = _pos;
                }
            }
        }
    }
}

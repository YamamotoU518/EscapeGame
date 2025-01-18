using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public float _speed = 5f;
    [SerializeField] public float _gravity = -15f;
    float _minusSquatSpeed;
    Rigidbody _rb;
    PauseManager _pauseManager;
    GameManager _gameManager;
    GameObject _child;
    AudioSource _audioSource;

    private void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _child = transform.Find("Main Camera").gameObject;
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (!_gameManager.CanvasVisible())
        {
            Vector3 move = transform.right * x + transform.up * _gravity * Time.deltaTime + transform.forward * z;

            _rb.velocity = move * (_speed - _minusSquatSpeed);

            //Vector3 cameraMove = _child.GetComponent<Transform>().transform.up * 3f * Time.deltaTime;

            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                if (!_audioSource.isPlaying)
                    _audioSource.PlayOneShot(_audioSource.clip);
            }

            if (_child.GetComponent<Transform>().position.y > 1.1)
            {
                if (Input.GetButton("Squat"))
                {
                    //Vector3 _pos = _child.GetComponent<Transform>().transform.position;
                    //_pos.y -= cameraMove.y;
                    //_child.GetComponent<Transform>().transform.position = _pos;
                    _minusSquatSpeed = 3f;
                }
            }
            if (_child.GetComponent<Transform>().position.y < 2.2)
            {
                if (!Input.GetButton("Squat"))
                {
                    //Vector3 _pos = _child.GetComponent<Transform>().transform.position;
                    //_pos.y += cameraMove.y;
                    //_child.GetComponent<Transform>().transform.position = _pos;
                    _minusSquatSpeed = 0f;
                }
            }
        }
        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            _audioSource.Stop();
        }
    }
}

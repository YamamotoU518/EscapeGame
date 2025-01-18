using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneCanvas : MonoBehaviour
{
    [SerializeField] Button _goTitle;
    int _timer;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer++;
        if (_timer >= 1200)
            _goTitle.gameObject.SetActive(true);
    }
}

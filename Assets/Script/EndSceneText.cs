using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneText : MonoBehaviour
{
    int _timer;
    int _messageNum;
    Text _text;
    string[] _message = { "T", "h", "a", "n", "k", "y", "o", "u", "F", "o", "r", "P", "l", "a", "y", "i", "n", "g" };
    void Start()
    {
        _timer = 0;
        _messageNum = -1;
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer++;
        if (_timer > 60)
        {
            _messageNum++;
            if (_messageNum < _message.Length)
            {
                _text.text += _message[_messageNum];
                _timer = 0;
            }
        }
    }
}

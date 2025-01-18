using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetNumber : MonoBehaviour
{
    [SerializeField] Image _image = default;
    [SerializeField] Sprite[] _alphabet;
    public int _number = 0;

    private void Start()
    {
        _image.sprite = _alphabet[0];
    }

    public void OnClicked()
    {
        _number++;
        if (_number >= 26)
            _number = 0;
        _image.sprite = _alphabet[_number];
    }
}

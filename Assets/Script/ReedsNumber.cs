using UnityEngine;
using UnityEngine.UI;

public class ReedsNumber : MonoBehaviour
{
    [SerializeField] Image _image = default;
    [SerializeField] Sprite[] _reeds;
    public int _number = 0;

    private void Start()
    {
        _image.sprite = _reeds[0];
    }

    public void OnClicked()
    {
        _number++;
        if (_number >= 4)
            _number = 0;
        _image.sprite = _reeds[_number];
    }
}

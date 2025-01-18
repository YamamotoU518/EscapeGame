using UnityEngine;
using TMPro;

public class NumberPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _numberText;
    public int _number = 0;
    
    public void OnClicked()
    {
        _number++;
        if (_number >= 10)
            _number = 0;
        _numberText.text = _number.ToString();
    }
}

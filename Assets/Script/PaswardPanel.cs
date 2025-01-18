using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaswardPanel : MonoBehaviour
{
    int[] _answer = { 0, 2, 2, 6 };
    [SerializeField] NumberPanel[] _numberPanels = default;
    [SerializeField] GameObject _exitKeyBox;
    [SerializeField] AudioSource _audioSource;
    
    public void OnClickedButton()
    {
        if (Clear())
        {
            Debug.Log("clear");
            _exitKeyBox.GetComponent<BoxOpenScript>().BoxOpen();
            transform.parent.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            if (!_audioSource.isPlaying)
                _audioSource.PlayOneShot(_audioSource.clip);
        }
    }

    bool Clear()
    {
        for (int i = 0; i < _numberPanels.Length; i++)
        {
            if (_numberPanels[i]._number != _answer[i])
                return false;
        }
        return true;
    }
}

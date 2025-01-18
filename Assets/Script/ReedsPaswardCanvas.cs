using UnityEngine;

public class ReedsPaswardCanvas : MonoBehaviour
{
    int[] _answar = { 3, 2, 0, 1 };
    [SerializeField] ReedsNumber[] _reedsNumbers = default;
    [SerializeField] GameObject _scissorsBox;
    [SerializeField] AudioSource _audioSource;

    public void OnClickedButton()
    {
        if (Clear())
        {
            Debug.Log("clear");
            _scissorsBox.GetComponent<BoxOpenScript>().BoxOpen();
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
        for (int i = 0; i < _reedsNumbers.Length; i++)
        {
            if (_reedsNumbers[i]._number != _answar[i])
                return false;
        }
        return true;
    }
}

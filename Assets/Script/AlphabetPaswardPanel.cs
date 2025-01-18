using UnityEngine;

public class AlphabetPaswardPanel : MonoBehaviour
{
    [SerializeField] AlphabetNumber[] _alphabetNumbers = default;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] GameObject _drawerTop;
    int[] _answer = { 4, 13, 8, 6, 12, 0 };

    public void OnClickedButton()
    {
        if (Clear())
        {
            Debug.Log("clear");
            _drawerTop.GetComponent<BoxOpenScript>().BoxOpen();
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
        for (int i = 0; i < _alphabetNumbers.Length; i++)
        {
            if (_alphabetNumbers[i]._number != _answer[i])
                return false;
        }
        return true;
    }
}

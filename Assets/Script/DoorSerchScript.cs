using UnityEngine;
using UnityEngine.UI;

public class DoorSerchScript : MonoBehaviour
{
    [SerializeField] Text _text = null;
    [SerializeField] DoorOpenScript _openScript = null;
    bool _onText = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            _text.gameObject.SetActive(true);
            _openScript = other.GetComponent<DoorOpenScript>();
            _onText = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            _text.gameObject.SetActive(false);
            _onText = false;
        }

    }
    private void Update()
    {
        if (_onText == true) 
        {
            if (Input.GetMouseButtonDown(1))
            {
                _onText = false;
                _text.gameObject.SetActive(false);
                _openScript.SelectedItem();
            }
        }
    }
}

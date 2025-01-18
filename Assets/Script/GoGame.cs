using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoGame : MonoBehaviour
{
    [SerializeField] GameObject _obj;
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _enabledObj;
    
    public void OnClicked()
    {
        if (this.name == "GoGame")
        {
            _gameManager.GetComponent<GameManager>()._pauseVisible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (this.name == "BuckMenuButton")
            _enabledObj.gameObject.SetActive(true);
        _obj.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _itemBoxPanel = null;
    [SerializeField] Canvas _reedsCanvas;
    [SerializeField] Canvas _birthDayCanvas;
    [SerializeField] Canvas _alphabetCanvas;
    [SerializeField] GameObject _PausePanel;
    bool _itemBoxVisible = false;
    public bool _pauseVisible = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("OpenItemBox"))
        {
            if (_itemBoxVisible == false)
            {
                _itemBoxPanel.SetActive(true);
                _itemBoxVisible = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                _itemBoxPanel.SetActive(false);
                _itemBoxVisible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            if (_pauseVisible == false)
            {
                _PausePanel.SetActive(true);
                _pauseVisible = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public bool CanvasVisible()
    {
        if (_birthDayCanvas.gameObject.activeSelf || _reedsCanvas.gameObject.activeSelf 
            || _alphabetCanvas.gameObject.activeSelf || _itemBoxVisible || _pauseVisible)
            return true;
        else 
            return false;
    }
}

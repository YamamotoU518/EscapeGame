using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationGame : MonoBehaviour
{
    [SerializeField] GameObject _explanationGame;
    public void OnButtonClicked()
    {
        _explanationGame.SetActive(true);
        transform.root.gameObject.SetActive(false);
    }
}

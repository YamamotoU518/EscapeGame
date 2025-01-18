using UnityEngine;

public class PaswardCanvas : MonoBehaviour
{
    public void OnClickedButton()
    {
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}

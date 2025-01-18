using UnityEngine;
using UnityEngine.UI;

public class SolvingTheRiddleSerch : MonoBehaviour
{
    [SerializeField] Text _text = null;
    [SerializeField] SolvingTheRiddle _solvingTheRiddle = null;
    bool _onText = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cushion"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "�N�b�V�����̒��ɉ��������Ă���݂���\n�A�C�e�����g��[�E�N���b�N]";
            _onText = true;
        }
        if (other.CompareTag("Fire"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "���̒��ɉ������肻���B�����Ȃ���΂Ƃ��̂�...\n�A�C�e�����g��[�E�N���b�N]";
            _onText = true;
        }
        if (other.CompareTag("Water"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "�o�P�c������ΐ����������邩������Ȃ���\n�A�C�e�����g��[�E�N���b�N]";
            _onText = true;
        }
        if (other.CompareTag("Aquarium"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "�����ɐ�������ꂻ��\n�A�C�e�����g��[�E�N���b�N]";
            _onText = true;
        }
        if (other.CompareTag("ScissorsBox") || other.CompareTag("ExitKeyBox"))
        {
                _text.gameObject.SetActive(true);
                _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
                _text.text = "�����J����[�E�N���b�N]";
                _onText = true;
        }
        if (other.CompareTag("Box"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "�������[�E�N���b�N]";
            _onText = true;
        }
        if (other.CompareTag("Graffiti"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "����������邩��\n�A�C�e�����g��[�E�N���b�N]";
            _onText = true;
        }
        if (other.CompareTag("DrawerTop"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "�����o�����J����[�E�N���b�N]";
            _onText = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cushion") || other.CompareTag("Fire") || other.CompareTag("Water")
            || other.CompareTag("Aquarium") || other.CompareTag("ScissorsBox") || other.CompareTag("Box") 
            || other.CompareTag("ExitKeyBox") || other.CompareTag("Graffiti") || other.CompareTag("DrawerTop"))
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
                _solvingTheRiddle.SelectedItem();
            }
        }
    }
}

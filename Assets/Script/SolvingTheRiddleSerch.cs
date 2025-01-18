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
            _text.text = "クッションの中に何か入っているみたい\nアイテムを使う[右クリック]";
            _onText = true;
        }
        if (other.CompareTag("Fire"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "炎の中に何かありそう。炎がなければとれるのに...\nアイテムを使う[右クリック]";
            _onText = true;
        }
        if (other.CompareTag("Water"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "バケツがあれば水をすくえるかもしれないな\nアイテムを使う[右クリック]";
            _onText = true;
        }
        if (other.CompareTag("Aquarium"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "水槽に水を入れられそう\nアイテムを使う[右クリック]";
            _onText = true;
        }
        if (other.CompareTag("ScissorsBox") || other.CompareTag("ExitKeyBox"))
        {
                _text.gameObject.SetActive(true);
                _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
                _text.text = "箱を開ける[右クリック]";
                _onText = true;
        }
        if (other.CompareTag("Box"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "箱を取る[右クリック]";
            _onText = true;
        }
        if (other.CompareTag("Graffiti"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "汚れを消せるかも\nアイテムを使う[右クリック]";
            _onText = true;
        }
        if (other.CompareTag("DrawerTop"))
        {
            _text.gameObject.SetActive(true);
            _solvingTheRiddle = other.GetComponent<SolvingTheRiddle>();
            _text.text = "引き出しを開ける[右クリック]";
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

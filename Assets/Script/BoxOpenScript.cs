using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpenScript : MonoBehaviour
{
    [SerializeField] GameObject _item;
    [SerializeField] AudioSource _audioSourse;

    public void BoxOpen()
    {
        if (this.name == "ScissorsBox" || this.name == "ExitKeyBox")
            transform.Find("Top").GetComponent<Animator>().SetBool("BoxOpen", true);
        if (this.name == "DrawerTop")
            this.GetComponent<Animator>().SetBool("isOpen", true);
        _item.SetActive(true);
        if (!_audioSourse.isPlaying)
            _audioSourse.PlayOneShot(_audioSourse.clip);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}

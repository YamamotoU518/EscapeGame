using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSerch : MonoBehaviour
{
    [SerializeField, Header("�A�C�e�����擾���錴�_(��������ɋ߂��A�C�e���A�����A�C�e�������܂�)")] private GameObject _originPoint;
    [SerializeField] Text _text = null;
    public List<GameObject> ItemList { get; private set; } = new List<GameObject>();
    private void Start()
    {
        // �A�C�e���폜�֐������s�J�n
        StartCoroutine(LateFixedUpdate());
    }
    /// <summary>
    /// �I�u�W�F�N�g�ƐڐG�������Ă΂��
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            ItemList.Add(other.gameObject);
        }
    }
    /// <summary>
    /// �I�u�W�F�N�g�����ꂽ���Ă΂��
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            var _item = GetNearItem();
            ItemList.Remove(other.gameObject);
            var _grandChild = _item.transform.Find("ExplanationCanvas/ExplanationPickUp");
            _text = _grandChild.GetComponent<Text>();
            _text.gameObject.SetActive(false);
            _item.GetComponent<Outline>().enabled = false;
        }
    }
    /// <summary>
    /// FixedUpdate�̎��s�^�C�~���O�ň�ԍŌ�Ɏ��s�����֐�
    /// </summary>
    /// <returns></returns>
    private IEnumerator LateFixedUpdate()
    {
        var waitForFixed = new WaitForFixedUpdate();
        while (true)
        {
            PickUpNearItemFirst();
            SetPickUpTargetItemMarker();
            yield return waitForFixed;
        }
    }
    /// <summary>
    /// ��ԋߏ�̃A�C�e����z��̐擪�Ɏ����Ă���
    /// </summary>
    /// <returns></returns>
    private void PickUpNearItemFirst()
    {
        if (ItemList.Count <= 1) return;
        var _originPos = _originPoint.transform.position;
        // �����ŏ��l��ݒ�
        var _minDirection = Vector3.Distance(ItemList[0].transform.position, _originPos);
        // ��ڂ̃A�C�e������擾�|�C���g�Ƃ̋������v�Z
        for (int _itemNum = 1; _itemNum < ItemList.Count; _itemNum++)
        {
            var _direction = Vector3.Distance(ItemList[_itemNum].transform.position, _originPos);
            // ���߂��I�u�W�F�N�g��0�Ԗڂ̗v�f�ɑ��
            if (_minDirection > _direction)
            {
                _minDirection = _direction;
                var _temp = ItemList[0];
                ItemList[0] = ItemList[_itemNum];
                ItemList[_itemNum] = _temp;
            }
        }
    }
    /// <summary>
    /// ��ԋ߂��A�C�e����Ԃ�
    /// </summary>
    /// <returns></returns>
    public GameObject GetNearItem()
    {
        if (ItemList.Count <= 0) return null;
        return ItemList[0];
    }

    /// <summary>
    /// �E���Ώۂ̃A�C�e����OutLine������
    /// </summary>
    private void SetPickUpTargetItemMarker()
    {
        var _item = GetNearItem();
        if (_item == null) return;
        _item.GetComponent<Outline>().enabled = true;
        var _grandChild = _item.transform.Find("ExplanationCanvas/ExplanationPickUp");
        _text = _grandChild.GetComponent<Text>();
        _text.text = _item.name + "���E��[F]";
        _text.gameObject.SetActive(true);
    }
}

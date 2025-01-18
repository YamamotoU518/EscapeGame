using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSerch : MonoBehaviour
{
    [SerializeField, Header("アイテムを取得する原点(これを元に近いアイテム、遠いアイテムが決まる)")] private GameObject _originPoint;
    [SerializeField] Text _text = null;
    public List<GameObject> ItemList { get; private set; } = new List<GameObject>();
    private void Start()
    {
        // アイテム削除関数を実行開始
        StartCoroutine(LateFixedUpdate());
    }
    /// <summary>
    /// オブジェクトと接触した時呼ばれる
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
    /// オブジェクトが離れた時呼ばれる
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
    /// FixedUpdateの実行タイミングで一番最後に実行される関数
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
    /// 一番近場のアイテムを配列の先頭に持ってくる
    /// </summary>
    /// <returns></returns>
    private void PickUpNearItemFirst()
    {
        if (ItemList.Count <= 1) return;
        var _originPos = _originPoint.transform.position;
        // 初期最小値を設定
        var _minDirection = Vector3.Distance(ItemList[0].transform.position, _originPos);
        // 二つ目のアイテムから取得ポイントとの距離を計算
        for (int _itemNum = 1; _itemNum < ItemList.Count; _itemNum++)
        {
            var _direction = Vector3.Distance(ItemList[_itemNum].transform.position, _originPos);
            // より近いオブジェクトを0番目の要素に代入
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
    /// 一番近いアイテムを返す
    /// </summary>
    /// <returns></returns>
    public GameObject GetNearItem()
    {
        if (ItemList.Count <= 0) return null;
        return ItemList[0];
    }

    /// <summary>
    /// 拾う対象のアイテムにOutLineをつける
    /// </summary>
    private void SetPickUpTargetItemMarker()
    {
        var _item = GetNearItem();
        if (_item == null) return;
        _item.GetComponent<Outline>().enabled = true;
        var _grandChild = _item.transform.Find("ExplanationCanvas/ExplanationPickUp");
        _text = _grandChild.GetComponent<Text>();
        _text.text = _item.name + "を拾う[F]";
        _text.gameObject.SetActive(true);
    }
}

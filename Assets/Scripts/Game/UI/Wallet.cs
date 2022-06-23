using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject panel, coinPref;

    public void Init()
    {
        Player.instance.OnChangeMoney += ChangeText;
        ChangeText(Player.instance.Money);
    }

    public void ChangeText(int moneyCount)
    {
        text.text = "Money: " + moneyCount;
    }

    public void TryAddMoney(Transform _transform, int valueMoney)
    {
        Vector3 realPos = GameInitializer.instance.MainCamera.WorldToScreenPoint(_transform.position);
        var coin = Instantiate(coinPref, realPos, Quaternion.identity);

        coin.transform.SetParent(GameInitializer.instance.MainCanvas.transform);
        coin.transform.DOMove(text.gameObject.transform.position, 1f).OnComplete(() => AddMoney(valueMoney, coin));
    }

    private void AddMoney(int valueMoney, GameObject coin)
    {
        Player.instance.AddMoney(valueMoney);
        panel.transform.DORewind(); //для возврата на стартовую позицию
        panel.transform.DOShakePosition(1f, 10, 30, 90, true);
        Destroy(coin.gameObject);
    }
}

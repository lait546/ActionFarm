using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image Scale;
    [SerializeField] private float animateTime = 8;
    [SerializeField] private TextMeshProUGUI counter;
    private float oldValue;
    private Coroutine curCoroutine;

    public void Init()
    {
        GameInitializer.instance.character.Inventory.OnChangeCountItems += ChangeHPScale;
        ChangeHPScale(GameInitializer.instance.character.Inventory.CountWeast, CharacterInventory.MAX_ITEM_COUNT);
    }

    public void ChangeHPScale(int newValue, int maxValue)
    {
        if (curCoroutine != null)
            StopCoroutine(curCoroutine);

        counter.text = newValue + "/" + maxValue;
        curCoroutine = StartCoroutine(IAnimateScale(newValue, maxValue));
    }

    private IEnumerator IAnimateScale(int newValue, int maxValue)
    {
        float startTime = Time.realtimeSinceStartup, fraction = 0f;
        oldValue = Scale.fillAmount;
        while (fraction < 1f)
        {
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / animateTime);
            Scale.fillAmount = Mathf.Lerp(oldValue, (float)newValue / maxValue, fraction);
            yield return new WaitForFixedUpdate();
        }
    }
}

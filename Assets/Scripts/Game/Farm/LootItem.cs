using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(Animator))]
public class LootItem : MonoBehaviour
{
    [SerializeField] public const float outerX = 0.2f, outerY = 0.13f, outerZ = 0.15f;
    [SerializeField] private BoxCollider colliderTrigger;
    [SerializeField] private float miniItemSizeCoef;
    [SerializeField] private Animator anim;

    public int ItemValue = 1, ItemPrice = 15;

    public void Move(Vector3 pos, Transform parent)
    {
        colliderTrigger.enabled = false;
        transform.SetParent(parent);
        anim.SetTrigger("Stop");
        transform.DOLocalMove(pos, 1.5f);
        transform.DOLocalRotate(new Vector3(0,0,0), 1.5f);
        transform.DOScale(transform.localScale * miniItemSizeCoef, 1.5f);
    }

    public void MoveAndDestroy(Vector3 pos, Transform parent, Action endMoveMethod)
    {
        transform.SetParent(parent);
        transform.DOMove(pos, 1.5f).OnComplete(() => EndMove(endMoveMethod));
    }

    private void EndMove(Action endMoveMethod)
    {
        endMoveMethod?.Invoke();
        Destroy(gameObject);
    }
}

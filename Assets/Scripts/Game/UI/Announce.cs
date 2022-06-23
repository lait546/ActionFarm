using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Announce : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private Animator anim;

    public void Init()
    {
        GameInitializer.instance.character.Inventory.OnFullInventory += Play;
    }

    public void Play(string text)
    {
        textMesh.text = text;
        anim.SetTrigger("Play");
    }
}

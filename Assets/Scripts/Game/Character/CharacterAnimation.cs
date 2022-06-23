using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Character character;
    private AnimationType currentState, previousState;
    [SerializeField] private Animator anim;

    public void ChangeAnimation(AnimationType type)
    {
        currentState = type;
        if (previousState != currentState)
            switch (type)
            {
                case AnimationType.Idle:
                    anim.SetBool("Idle", true);

                    break;
                case AnimationType.Walk:
                    anim.SetBool("Walk", true);

                    break;
            }
        previousState = currentState;
    }

    public void IsHarvest(bool value)
    {
        character.Inventory.scythe.SetActive(value);
        anim.SetBool("Harvesting", value);
    }
}

public enum AnimationType
{
    Idle,
    Walk,
    Pick
}
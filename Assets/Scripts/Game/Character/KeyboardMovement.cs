using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private FixedJoystick joystick;

    void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        if (horizontal != 0 || vertical != 0)
        {
            character.Movement.Move(new Vector3(horizontal, 0, vertical));
            character.Anim.ChangeAnimation(AnimationType.Walk);
        }
        else
        {
            character.Anim.ChangeAnimation(AnimationType.Idle);
        }
    }
}

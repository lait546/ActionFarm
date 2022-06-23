using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float maxSpeed, speedRotation;

    public void Move(Vector3 direction)
    {
        Vector3 offset = direction * (maxSpeed * Time.deltaTime);
        
        rigidbody.MovePosition(rigidbody.position + offset);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(offset), speedRotation * Time.deltaTime);
    }
}

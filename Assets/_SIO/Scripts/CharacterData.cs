using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private float defaultSpeed;

    [SerializeField]
    private Transform characterTransform;

    [SerializeField]
    private float turnSmoothTime;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float attackRange;


    public CharacterController CharacterController => characterController;
    public float DefaultSpeed => defaultSpeed;
    public Transform CharacterTransform => characterTransform;
    public float TurnSmoothTime => turnSmoothTime;
    public float Damage => damage;
    public float AttackRange => attackRange;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimSpeed : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float aimSpeed;
    void Start()
    {
        animator.speed=aimSpeed;
        //animator.SetFloat("speed",aimSpeed);
    }
}

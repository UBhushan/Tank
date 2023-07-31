using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimShoot : MonoBehaviour
{
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void ShootAnim()
    {   
        animator.SetTrigger("Shoot");
    }
}

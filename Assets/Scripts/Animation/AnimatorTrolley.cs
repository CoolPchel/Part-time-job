using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTrolley : MonoBehaviour
{
    private Animator trolleyAm;

    private void Start()
    {
        trolleyAm = GetComponent<Animator>();
    }

    public void Move()
    {
        trolleyAm.SetBool("Moving", true);
    }
    public void Stop()
    {
        trolleyAm.SetBool("Moving", false);
    }
}

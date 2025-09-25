using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    private Animator playerAm;
    public float fWY;
    public float fWX;
    public bool menPlayer = true;

    private void Start()
    {
        playerAm = GetComponent<Animator>();
    }

    private void Update()
    {
        if(menPlayer)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
                {
                    playerAm.SetBool("Run", true);
                }
                else
                {
                    playerAm.SetBool("Run", false);
                }
            }

            if(!Input.GetKey(KeyCode.LeftShift))
            {
                if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
                {
                    if(Input.GetKey(KeyCode.W) && fWY < 1)
                    {
                        if(fWY < 0)
                        {
                            fWY += 5 * Time.deltaTime;
                        }
                        fWY += 1 * Time.deltaTime;
                    }
                    if(Input.GetKey(KeyCode.A) && fWX > -1)
                    {
                        if(fWX > 0)
                        {
                            fWX -= 5 * Time.deltaTime;
                        }
                        fWX -= 1 * Time.deltaTime;
                    }
                    if(Input.GetKey(KeyCode.D) && fWX < 1)
                    {
                        if(fWX < 0)
                        {
                            fWX += 5 * Time.deltaTime;
                        }
                        fWX += 1 * Time.deltaTime;
                    }
                    if(Input.GetKey(KeyCode.S) && fWY > -1)
                    {
                        if(fWY > 0)
                        {
                            fWY -= 5 * Time.deltaTime;
                        }
                        fWY -= 1 * Time.deltaTime;
                    }
                    playerAm.SetBool("Wolk", true);
                }
                else
                {
                    playerAm.SetBool("Wolk", false);
                }
                playerAm.SetBool("Run", false);
            }

            if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                if(fWX != 0)
                {
                    if(fWX > 0)
                    {
                        fWX -= 1f * Time.deltaTime;
                    }
                    if(fWX < 0)
                    {
                        fWX += 1f * Time.deltaTime;
                    }
                }
            }

            if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if(fWY != 0)
                {
                    if(fWY > 0)
                    {
                        fWY -= 1f * Time.deltaTime;
                    }
                    if(fWY < 0)
                    {
                        fWY += 1f * Time.deltaTime;
                    }
                }
            }
            playerAm.SetFloat("WolkY", fWY);
            playerAm.SetFloat("WolkX", fWX);
            playerAm.SetBool("IsRobot", false);
        }
        if(!menPlayer)
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
            {
                playerAm.SetBool("Wolk", true);
            }
            else
            {
                playerAm.SetBool("Wolk", false);
            }
            playerAm.SetBool("IsRobot", true);
        }
    }
}

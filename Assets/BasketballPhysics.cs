using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballPhysics : MonoBehaviour
{
    Rigidbody rb;
    float yFrequency = 0;
    float SamplingInterval = 0.1f;
    float Timer = 0.0f;
    int CurrentDirection = -1;
    int HalfPeriods = 0;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity.y > 0)
        {
            if (CurrentDirection == -1)
            {
                CurrentDirection = 1;
                HalfPeriods++;
            }
        }
        else
        {
            if (CurrentDirection == 1)
            {
                CurrentDirection = -1;
                HalfPeriods++;
            }
        }
        
        if (Timer < SamplingInterval)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            yFrequency = HalfPeriods / (2 * Timer);
            // Debug.Log(yFrequency.ToString());
            
            HalfPeriods = 0;
            Timer = 0.0f;
        }

        // try
        // {
        //     TouchUIManager.CurrInst.TempNotif.SetText(yFrequency.ToString());
        //     TouchUIManager.CurrInst.TempNotif.gameObject.SetActive(true);
        // }
        // catch { }

        if (yFrequency > 10.0f && !rb.isKinematic)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }
}

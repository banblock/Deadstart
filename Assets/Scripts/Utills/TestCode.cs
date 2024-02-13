using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    [SerializeField]
    HpBarComponent hpBar;
    float max = 10;
    float current = 10;

    private void Update()
    {
        
        if (hpBar != null) {
            if (Input.GetKeyDown(KeyCode.K)) {
                Debug.Log("Å×½ºÆ®");
                hpBar.UpdateStatus(max, current);
                current -= 1;


            }

        }
    }


}

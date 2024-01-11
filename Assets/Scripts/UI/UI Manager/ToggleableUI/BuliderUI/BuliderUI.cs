using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuliderUI : ToggleableUI
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public override void OpenUI()
    {
        gameObject.SetActive(true);
    }

    public override void CloseUI()
    {
        gameObject.SetActive(false);
    }

    public void UpdateUI()
    {

    }
}

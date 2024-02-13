using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : ToggleableUI
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

}

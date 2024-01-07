using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : ToggleableUI
{
    public GameObject characterInfoPanel;
    public Text characterNameText;
    public Text healthText;
    public Text manaText;

    void Start()
    {
        characterInfoPanel = this.gameObject;
        this.gameObject.SetActive(false);
    }

    public override void ToggleUI()
    {
        characterInfoPanel.SetActive(!characterInfoPanel.activeSelf);
    }

    // 캐릭터 정보 갱신 메서드
    public void UpdateCharacterInfo(string characterName, int health, int mana)
    {
        characterNameText.text = "Name: " + characterName;
        healthText.text = "Health: " + health.ToString();
        manaText.text = "Mana: " + mana.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfoUI : ToggleableUI
{

    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private TMP_Text attackPointText;
    [SerializeField]
    private TMP_Text attackSpeedText;
    [SerializeField]
    private TMP_Text speedText;
    

    void Start()
    {
        gameObject.SetActive(false);
    }

    public override void OpenUI()
    {
        DisplayPlayerStat();
        gameObject.SetActive(true);
    }

    public override void CloseUI()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 플레이어 스테이터스 표기
    /// </summary>
    void DisplayPlayerStat()
    {
        //플레이어를 가져온뒤 디스플레이 합니다.
        PlayerController player = PlayerController.Instance;
        string playerName = player.PlayerName;
        float attackPoint = player.Stats.Attack;
        float attackSpeed = player.Stats.AttackSpeed;
        float speed = player.Stats.Speed;
        float health = player.Stats.MaxHealth;

        nameText.text = playerName;
        healthText.text = health.ToString();
        attackPointText.text = attackPoint.ToString();
        attackSpeedText.text = attackSpeed.ToString();
        speedText.text = speed.ToString();


    }

}

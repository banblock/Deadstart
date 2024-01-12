using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {  get; private set; } 

    [SerializeField]
    private PlayerStats playerStats;  // 플레이어 스탯 관리 클래스
    private Rigidbody2D rb;

    [SerializeField]
    private WeaponManager weaponManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        // 플레이어 스탯 초기화
        playerStats = new PlayerStats();
        playerStats.InitializeStats();

        // 스탯 업데이트
        UpdatePlayerStats();
    }

    void Update()
    {
        MovePlayer();
    }


    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        // 이동 속도에 스탯 적용
        rb.velocity = movement * playerStats.Speed;
    }

    private void TakeDamage(int damage)
    {
        playerStats.Health -= damage;
    }

    private void Die()
    {
        if(playerStats.Health > 0) {
            Debug.Log("player die");
        }
    }

    // 스탯 업데이트 및 UI 텍스트 갱신
    private void UpdatePlayerStats()
    {
        Debug.Log($"Player Stats: HP - {playerStats.Health}, ATK - {playerStats.Attack}, ATK Speed - {playerStats.AttackSpeed}, Speed - {playerStats.Speed}");
    }
}

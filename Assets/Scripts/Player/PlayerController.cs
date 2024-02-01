using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {  get; private set; } 

    [SerializeField]
    private PlayerStats playerStats;  // �÷��̾� ���� ���� Ŭ����
    private Rigidbody2D rb;

    [SerializeField]
    private WeaponManager weaponManager;

    private void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(Instance);
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        // �÷��̾� ���� �ʱ�ȭ
        playerStats = new PlayerStats();
        playerStats.InitializeStats();

        // ���� ������Ʈ
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

        // �̵� �ӵ��� ���� ����
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

    // ���� ������Ʈ �� UI �ؽ�Ʈ ����
    private void UpdatePlayerStats()
    {
        Debug.Log($"Player Stats: HP - {playerStats.Health}, ATK - {playerStats.Attack}, ATK Speed - {playerStats.AttackSpeed}, Speed - {playerStats.Speed}");
    }
}

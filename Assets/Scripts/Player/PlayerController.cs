using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {  get; private set; } 

    [SerializeField]
    private WeaponManager weaponManager;
    private Rigidbody2D rigid;

    [SerializeField]
    private PlayerStats playerStats;  // 플레이어 스탯 관리 클래스

    private Vector2 inputVector;


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
        rigid = GetComponent<Rigidbody2D>();

        //weponManager지정
        if( weaponManager == null ) {
            weaponManager = WeaponManager.Instance;
        }

        // 플레이어 스탯 초기화
        playerStats = new PlayerStats();
        playerStats.InitializeStats();

        // 스탯 업데이트
        UpdatePlayerStats();

       
    }

    void Update()
    {
        InputPlayerMove();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void InputPlayerMove()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MovePlayer()
    {
        Vector2 nextVector = inputVector.normalized * playerStats.Speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVector);
    }

    private void Boost()
    {

    }

    public void TakeDamage(int damage)
    {
        playerStats.Health -= damage;

        if (playerStats.Health > 0) {
            // todo : 플레이어 피격
            
        }
        else {
            // todo : 플레이어 사망
            Die();
        }
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

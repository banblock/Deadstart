using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {  get; private set; } 

    [SerializeField]
    private WeaponManager weaponManager;
    private Rigidbody2D rigid;

    [SerializeField]
    private PlayerStats playerStats;  // �÷��̾� ���� ���� Ŭ����

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

        //weponManager����
        if( weaponManager == null ) {
            weaponManager = WeaponManager.Instance;
        }

        // �÷��̾� ���� �ʱ�ȭ
        playerStats = new PlayerStats();
        playerStats.InitializeStats();

        // ���� ������Ʈ
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
            // todo : �÷��̾� �ǰ�
            
        }
        else {
            // todo : �÷��̾� ���
            Die();
        }
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

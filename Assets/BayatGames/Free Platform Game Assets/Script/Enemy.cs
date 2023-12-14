using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Spawn,
        Walk,
        Attack
    }

    public float walkSpeed = 2f;
    public float attackDistance = 1f;
    public float stopDistance = 0.5f; // Jarak untuk berhenti sebelum menyerang.
    public float attackCooldown = 2f; // Waktu antara serangan.

    private EnemyState currentState;
    private Animator animator;
    private Transform playerTransform;
    private float lastAttackTime;
    public float groundLevel = 0f; // Inisialisasi groundLevel dengan tinggi tanah.

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetState(EnemyState.Spawn);
        playerTransform = FindPlayer();
    }

    private void Update()
    {
        // Mengatur perilaku enemy berdasarkan currentState
        switch (currentState)
        {
            case EnemyState.Idle:
                // Tidak melakukan apa-apa, mungkin menunggu input pemain.
                break;

            case EnemyState.Spawn:
                // Mainkan animasi Spawn (pastikan Spawn memiliki transisi ke Walk).
                animator.SetTrigger("Spawn");
                SetState(EnemyState.Walk);
                break;

             case EnemyState.Walk:
                if (playerTransform != null)
                {
                    float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
                    if (distanceToPlayer <= attackDistance)
                    {
                        // ...

                        // Untuk menghindari enemy terbang saat pemain melompat, 
                        // kita hanya akan mengubah posisi Y enemy jika jarak vertical ke pemain
                        // lebih besar dari tinggi tetap tertentu.
                        float verticalDistanceToPlayer = Mathf.Abs(transform.position.y - playerTransform.position.y);
                        if (verticalDistanceToPlayer > 0.1f)
                        {
                            // Atur posisi Y enemy agar tetap sama dengan tinggi tetap tertentu (misalnya, ground level).
                            transform.position = new Vector3(transform.position.x, groundLevel, transform.position.z);
                        }
                    }
                    else if (distanceToPlayer > stopDistance)
                    {
                        // Jika tidak, bergerak ke arah pemain.
                        Vector2 direction = (playerTransform.position - transform.position).normalized;
                        transform.Translate(direction * walkSpeed * Time.deltaTime);
                    }
                }
                break;

            case EnemyState.Attack:
                // Mainkan animasi Attack (pastikan Attack memiliki transisi kembali ke Walk).
                animator.SetTrigger("Attack");
                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    // Setelah serangan, kembalikan ke state Walk setelah cooldown.
                    SetState(EnemyState.Walk);
                    lastAttackTime = Time.time;
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentState == EnemyState.Spawn)
        {
            // Jika dalam state Spawn dan terjadi collision, ubah ke state Walk.
            SetState(EnemyState.Walk);
        }
    }

    private void SetState(EnemyState newState)
    {
        currentState = newState;
    }

    private Transform FindPlayer()
    {
        // Temukan objek player dalam permainan.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return player.transform;
        }
        return null;
    }
}

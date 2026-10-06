using UnityEngine;

public class FishFSM : MonoBehaviour
{    
    public float speedMove = 2f; 
    public Transform trnPlayer;    
    public Rigidbody2D rb;    
    public float detectionRange = 5f;        
    public SpriteRenderer reactionSpriteRenderer;
    public Sprite reactionSprite;
    public float reactionDisplayTime = 1.5f;
    protected FishState currentState;
    private float reactionTimer;

    protected virtual void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (trnPlayer == null)
        {
            GameObject player = GameObject.Find("Player");
            if (player != null)
                trnPlayer = player.transform;
        }        

        if (reactionSpriteRenderer != null)
            reactionSpriteRenderer.enabled = false;
    }

    protected virtual void Start() //시작할 때에는 IdleState로 시작
    {
        ChangeState(new IdleState());
    }

    protected virtual void Update() // 
    {
        if (currentState != null)
            currentState.UpdateState();

        UpdateReactionSprite();
    }

    protected virtual void FixedUpdate()
    {
        if (currentState != null)
            currentState.FixedUpdateState();
    }

    public void ChangeState(FishState newState) // state 변경
    {
        if (newState == null)
        {
            Debug.LogError($"{gameObject.name}: 새로운 State가 Null입니다.");
            return;
        }

        if (currentState != null) 
            currentState.Exit(); //현재 state를 종료하고

        currentState = newState; // 현재 currnetState를 새로 시작한 newState로 변환
        currentState.Initialize(this); // 현재 상태를 초기화
        currentState.Enter(); // 변경된 currnetState를시작
    }

    public FishState GetCurrentState() // 현재 state 반환
    {
        return currentState;
    }

    public float GetDistanceToPlayer() // 유저와 물고기 사이 거리를 반환
    {
        if (trnPlayer == null)
            return Mathf.Infinity;

        return Vector2.Distance(transform.position, trnPlayer.position);
    }

    public bool IsPlayerInRange() //거리가 감지범위 내에 들어올 경우 true를 반환
    {
        return GetDistanceToPlayer() <= detectionRange;
    }

    public virtual void OnPlayerDetected() { }

    public void ShowReactionSprite()
    {
        if (reactionSpriteRenderer == null || reactionSprite == null)
            return;

        reactionSpriteRenderer.sprite = reactionSprite;
        reactionSpriteRenderer.enabled = true;
        reactionTimer = reactionDisplayTime;
    }

    private void UpdateReactionSprite()
    {
        if (reactionSpriteRenderer == null || !reactionSpriteRenderer.enabled)
            return;

        reactionTimer -= Time.deltaTime;
        if (reactionTimer <= 0f)
            reactionSpriteRenderer.enabled = false;
    }

    public void Move(Vector3 targetPosition) // 매개변수로 전달된 좌표로 이동 수 정지
    {
        if (rb == null)
            return;

        Vector2 direction = targetPosition - transform.position; //좌표로 이동
        if (direction.sqrMagnitude <= 0.01f) // 거리가 0.01f 이하이면 정지
        {
            StopMove();
            return;
        }

        rb.velocity = direction.normalized * speedMove;
    }

    public void MoveDirection(Vector2 direction) // 매개변수로 전달된 좌표로 계속 이동
    {
        if (rb == null)
            return;

        if (direction.sqrMagnitude <= 0.01f)
        {
            StopMove();
            return;
        }

        rb.velocity = direction.normalized * speedMove;
    }

    public void StopMove() // 멈추기
    {
        if (rb != null)
            rb.velocity = Vector2.zero;
    }
}

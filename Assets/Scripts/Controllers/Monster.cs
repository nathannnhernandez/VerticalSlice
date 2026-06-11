
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float viewDistance = 50f;
   // [SerializeField] private float viewAngle = 120f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float roamRange = 50f;
    [SerializeField] private float maxDistanceFromPlayer = 30f;
    public float currentMonsterSpeed;
    private NavMeshHit hit;
    private RaycastHit rayHit;
    private Animator animator;
    public bool youShotMeTwin = false;
    float distanceFromPlayer;
    public float maxSpeed = 14f;
    public float slowAmount = 3f;
    public float slowDuration = 7f;
    private bool hasBeenShot = false;
    public enum MonsterStates
    {
        Chillin,
        WalkThatBihDown,
        Attack
    }
    public MonsterStates currentState;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = MonsterStates.WalkThatBihDown;

        animator = GetComponent<Animator>();

        currentMonsterSpeed = maxSpeed;
        agent.speed = currentMonsterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = currentMonsterSpeed;
        distanceFromPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);
        Debug.Log(distanceFromPlayer);
        if (distanceFromPlayer > maxDistanceFromPlayer)
        {
            currentState = MonsterStates.WalkThatBihDown;
        }
        if (hasBeenShot == false)
        {
            currentMonsterSpeed = maxSpeed;
        }
        switch (currentState)
        {
            case MonsterStates.Chillin:
                HandleChillin();
                break;
            case MonsterStates.WalkThatBihDown:
                HandleWalkThatBihDown();
                break;
            case MonsterStates.Attack:
                HandleAttack();
                break;
        }
        if (youShotMeTwin == true)
        {
            animator.SetBool("isShot", true);
        }
        else
        {
            animator.SetBool("isShot", false);
        }
    }

    void HandleChillin()
    {
        animator.SetBool("isRunning", false);
        if (CanSeePlayer())
        {
            currentState = MonsterStates.WalkThatBihDown;
            return;
        }
        if (!agent.hasPath || agent.remainingDistance < 0.5f)
        {
            Roam();
        }
    }
    void HandleWalkThatBihDown()
    {
        animator.SetBool("isRunning", true);
        agent.SetDestination(player.transform.position);

        float distance = UnityEngine.Vector3.Distance(transform.position, player.transform.position);

        if (!CanSeePlayer() && distanceFromPlayer < maxDistanceFromPlayer)
        {
            currentState = MonsterStates.Chillin;
        }
        else if (distanceFromPlayer > maxDistanceFromPlayer)
        {
            currentState = MonsterStates.WalkThatBihDown;
            currentMonsterSpeed = 1000f;
            hasBeenShot = false;
        }
        else if (distanceFromPlayer < maxDistanceFromPlayer && currentState == MonsterStates.WalkThatBihDown && hasBeenShot == false)
        {
            currentMonsterSpeed = maxSpeed;
        }
        else if (distance < 2f) // attack range
        {
            currentState = MonsterStates.Attack;
        }
        //Debug.Log(currentState);
    }
    void HandleAttack()
    {
        float holdMonsterSpeed = currentMonsterSpeed;

        agent.ResetPath();

        animator.SetTrigger("isAttacking");

        currentMonsterSpeed = 1f;

        float distance = UnityEngine.Vector3.Distance(transform.position, player.transform.position);

        if (distance > 2f)
        {
            currentState = MonsterStates.WalkThatBihDown;
            currentMonsterSpeed = holdMonsterSpeed;
        }
    }
    bool CanSeePlayer()
    {
        UnityEngine.Vector3 eyePosition = transform.position + UnityEngine.Vector3.up * 1.6f;
        UnityEngine.Vector3 directionToPlayer = (player.transform.position - eyePosition).normalized;
        float distanceToPlayer = UnityEngine.Vector3.Distance(eyePosition, player.transform.position);

        Debug.DrawRay(transform.position, directionToPlayer * distanceToPlayer, Color.red);
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.blue);
       if (distanceToPlayer > viewDistance)
        {
            return false;
        }
        
        
        float angle = UnityEngine.Vector3.Angle(transform.forward, directionToPlayer);

       /* if (angle > viewAngle / 2)
        {
            return false;
        }
        */
        if (Physics.Raycast(eyePosition, directionToPlayer, out rayHit, distanceToPlayer))
        {
            return rayHit.transform == player.transform;
        }

        return false;

    }
    void Roam()
    {
        UnityEngine.Vector3 randomPos = transform.position + UnityEngine.Random.insideUnitSphere * roamRange;
        if (NavMesh.SamplePosition(randomPos, out hit, roamRange, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }


    private Coroutine slowRoutine;

    public void ApplySlow()
    {
        hasBeenShot = true;
        // Apply slow to the actual movement speed
        currentMonsterSpeed = Mathf.Max(currentMonsterSpeed - slowAmount, 1f);
        if (currentMonsterSpeed <= maxSpeed * 0.5)
        {
            youShotMeTwin = true;
        }

        if (slowRoutine != null)
            StopCoroutine(slowRoutine);

        slowRoutine = StartCoroutine(RestoreSpeed());
    }

    private IEnumerator RestoreSpeed()
    {

        yield return new WaitForSeconds(slowDuration);

        youShotMeTwin = false;
        currentMonsterSpeed = maxSpeed;
        hasBeenShot = false;
    }
}

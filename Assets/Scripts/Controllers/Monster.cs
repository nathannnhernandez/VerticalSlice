
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
    [SerializeField] private float roamSpeedDividend = 2f;
    public float monsterSpeed = 10f;
    private float currentMonsterSpeed;
    private NavMeshHit hit;
    private RaycastHit rayHit;
    private enum MonsterStates
    {
        Chillin,
        WalkThatBihDown,
        Attack
    }
    private MonsterStates currentState;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = MonsterStates.WalkThatBihDown;

        currentMonsterSpeed = monsterSpeed;
        agent.speed = currentMonsterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = currentMonsterSpeed;
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
    }

    void HandleChillin()
    {
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
        currentMonsterSpeed = monsterSpeed;
        agent.SetDestination(player.transform.position);

        float distance = UnityEngine.Vector3.Distance(transform.position, player.transform.position);

        if (!CanSeePlayer())
        {
            currentState = MonsterStates.Chillin;
        }
        else if (distance < 2f) // attack range
        {
            currentState = MonsterStates.Attack;
        }
        //Debug.Log(currentState);
    }
    void HandleAttack()
    {
        agent.ResetPath();

        float distance = UnityEngine.Vector3.Distance(transform.position, player.transform.position);

        if (distance > 2f)
        {
            currentState = MonsterStates.WalkThatBihDown;
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
        currentMonsterSpeed /= roamSpeedDividend;
        UnityEngine.Vector3 randomPos = transform.position + UnityEngine.Random.insideUnitSphere * roamRange;
        if (NavMesh.SamplePosition(randomPos, out hit, roamRange, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

}

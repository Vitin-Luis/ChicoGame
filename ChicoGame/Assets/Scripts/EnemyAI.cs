using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] public GameObject playerTarget1;
    [SerializeField] public GameObject playerTarget2;
    public GameObject player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float delayR = 5f;
    public float delayL = 5f;
    public float curSpeed;
    public Vector3 previousPosition;
    [SerializeField] public ParticleSystem[] flashR;
    [SerializeField] public ParticleSystem[] flashL;
    [SerializeField] public GameObject[] firePointsR;
    [SerializeField] public GameObject[] firePointsL;
    [SerializeField] public GameObject inRangeL;
    [SerializeField] public GameObject inRangeR;

    [SerializeField] private GameObject CBall;

    public float walkPointRange;

    public float sightRange;
    public bool playerInSightRange;
    public bool combatMode;
    public VerifyCollision boxR;
    public VerifyCollision boxL;
    public SpawnPrefabRandomly spawn;

    private void Start()
    {   
        playerTarget1 = GameObject.Find("AITarget");
        playerTarget2 = GameObject.Find("AITarget2");
        boxR = inRangeR.GetComponent<VerifyCollision>();
        boxL = inRangeL.GetComponent<VerifyCollision>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {   
        float distanceToTarget1 = Vector3.Distance(transform.position, playerTarget1.transform.position);
        float distanceToTarget2 = Vector3.Distance(transform.position, playerTarget2.transform.position);

        if (distanceToTarget1 <= distanceToTarget2)
        {
            player = playerTarget1;
        }
        else if (distanceToTarget1 > distanceToTarget2)
        {
            player = playerTarget2;
        }
        

        if(health <= 0) Destroy(gameObject);

        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
        delayR -= Time.deltaTime;
        delayL -= Time.deltaTime;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);


        if (!playerInSightRange) Patroling();
        if (playerInSightRange)
        {
            ChasePlayer();
        }
        if ((boxR.isInRange() || boxL.isInRange()) && playerInSightRange && (delayR <= 0 || delayL <= 0))
        {
            AttackPlayer();
            delayL = 5;
            delayR = 5;
        }

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);
           

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    
        walkPointSet = true;
    }

    private void ChasePlayer()
    {    
         agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {   
        if(boxR.isInRange()) ShootRight();
            
        if(boxL.isInRange()) ShootLeft();              
    }
    void ShootLeft()
    {
        for (int i = 0; i <= 2; i++)
        {
            Quaternion initialRotation = firePointsL[i].transform.rotation;
            firePointsL[i].transform.Rotate(0f + curSpeed, 0f, 0f, Space.Self);
            Rigidbody C = Instantiate(CBall, firePointsL[i].transform.position, firePointsL[i].transform.rotation).GetComponent<Rigidbody>();
            C.AddRelativeForce(transform.up * 50f, ForceMode.Impulse);
            flashL[i].Play();
            firePointsL[i].transform.rotation = initialRotation;
        }
    }
    void ShootRight()
    {
        for (int i = 0; i <= 2; i++)
        {
            Quaternion initialRotation = firePointsR[i].transform.rotation;
            firePointsR[i].transform.Rotate(0f - curSpeed, 0f, 0f, Space.Self);
            Rigidbody C = Instantiate(CBall, firePointsR[i].transform.position, firePointsR[i].transform.rotation).GetComponent<Rigidbody>();
            C.AddRelativeForce(transform.up * 50f, ForceMode.Impulse);
            flashR[i].Play();
            firePointsR[i].transform.rotation = initialRotation;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        spawn.InstanceDestroyed();
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala")){
            health -= 10;
        }
    }
}
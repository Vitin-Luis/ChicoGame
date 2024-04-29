using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Classe EnemyAI controla o comportamento do inimigo
public class EnemyAI : MonoBehaviour
{
    // Referência para o componente NavMeshAgent
    public NavMeshAgent agent;
    
    // Referências aos alvos dos jogadores
    [SerializeField] public GameObject playerTarget1;
    [SerializeField] public GameObject playerTarget2;
    
    // Referência ao jogador atual
    public GameObject player;
    
    // Camadas para determinar o que é terreno e o que é jogador
    public LayerMask whatIsGround, whatIsPlayer;
    
    // Saúde do inimigo
    public float health;
    
    // Ponto de destino para a patrulha
    public Vector3 walkPoint;
    bool walkPointSet;
    
    // Distância de patrulha máxima
    public float walkPointRange;
    
    // Alcance de visão e indicador se o jogador está dentro do alcance de visão
    public float sightRange;
    public bool playerInSightRange;
    
    // Indicador de modo de combate
    public bool combatMode;
    
    // Atrasos para os ataques esquerdo e direito
    public float delayR = 5f;
    public float delayL = 5f;
    
    // Velocidade atual do inimigo
    public float curSpeed;
    public Vector3 previousPosition;
    
    // Partículas e pontos de fogo para os ataques
    [SerializeField] public ParticleSystem[] flashR;
    [SerializeField] public ParticleSystem[] flashL;
    [SerializeField] public GameObject[] firePointsR;
    [SerializeField] public GameObject[] firePointsL;
    
    // GameObjects para detectar a presença do jogador
    [SerializeField] public GameObject inRangeL;
    [SerializeField] public GameObject inRangeR;

    // Prefab da bola de fogo
    [SerializeField] private GameObject CBall;

    // Componentes de verificação de colisão para detectar a presença do jogador
    public VerifyCollision boxR;
    public VerifyCollision boxL;
	
    // Componente para spawn de objetos
	public AISpawner aiSpawner;

    // Inicialização
    private void Start()
    {   
        // Encontra os alvos dos jogadores
        playerTarget1 = GameObject.Find("AITarget");
        playerTarget2 = GameObject.Find("AITarget2");
        
        // Obtém as verificações de colisão dos objetos de alcance
        boxR = inRangeR.GetComponent<VerifyCollision>();
        boxL = inRangeL.GetComponent<VerifyCollision>();
        
        // Obtém o componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
		
		// Obtém o componente SpawnPrefabRandomly
		aiSpawner = GetComponent<AISpawner>();
    }

    // Atualização
    private void Update()
    {   
        // Calcula a distância até os alvos dos jogadores
        float distanceToTarget1 = Vector3.Distance(transform.position, playerTarget1.transform.position);
        float distanceToTarget2 = Vector3.Distance(transform.position, playerTarget2.transform.position);

        // Determina o jogador mais próximo como o alvo
        if (distanceToTarget1 <= distanceToTarget2)
        {
            player = playerTarget1;
        }
        else if (distanceToTarget1 > distanceToTarget2)
        {
            player = playerTarget2;
        }
        
        // Verifica se o inimigo está sem saúde
        if (health <= 0)
		{
    		Destroy(gameObject);
    		ScoreManager.scoreCount += 10;
			aiSpawner.InstanceDestroyed();
			aiSpawner.SpawnPrefab();
		}

        // Calcula a velocidade atual do inimigo
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
        delayR -= Time.deltaTime;
        delayL -= Time.deltaTime;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        // Comportamentos dependendo da detecção do jogador
        if (!playerInSightRange) Patroling();
        if (playerInSightRange) ChasePlayer();
        if ((boxR.isInRange() || boxL.isInRange()) && playerInSightRange && (delayR <= 0 || delayL <= 0))
        {
            AttackPlayer();
            delayL = 5;
            delayR = 5;
        }
    }

    // Função de patrulha
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    
    // Função para encontrar um ponto de patrulha
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        walkPointSet = true;
    }

    // Função para perseguir o jogador
    private void ChasePlayer()
    {    
         agent.SetDestination(player.transform.position);
    }

    // Função para atacar o jogador
    private void AttackPlayer()
    {   
        if(boxR.isInRange()) ShootRight();
            
        if(boxL.isInRange()) ShootLeft();              
    }

    // Função para atirar à esquerda
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
    
    // Função para atirar à direita
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

    // Função para receber dano
public void TakeDamage(int damage)
{
    // Reduz a saúde do inimigo pelo valor do dano
    health -= damage;

    // Verifica se a saúde do inimigo é igual ou menor que zero
    if (health <= 0)
    {
        // Invoca a destruição do inimigo após um pequeno atraso
        Invoke(nameof(DestroyEnemy), 0.5f);
    }
}

// Função para destruir o inimigo
private void DestroyEnemy()
{
    // Destroi o GameObject do inimigo
    Destroy(gameObject);
}

// Função para desenhar gizmos no editor
private void OnDrawGizmosSelected()
{
    // Define a cor do gizmo como amarelo
    Gizmos.color = Color.yellow;
    // Desenha uma esfera de arame para representar o alcance de visão do inimigo
    Gizmos.DrawWireSphere(transform.position, sightRange);
}

// Função chamada quando o GameObject entra em colisão com outro Collider
void OnTriggerEnter(Collider other)
{
    // Verifica se o Collider do outro GameObject tem a tag "Bala"
    if (other.gameObject.CompareTag("Bala"))
    {
        // Reduz a saúde do inimigo quando atingido por uma bala
        health -= 10;
    }
}
}
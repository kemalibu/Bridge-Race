using UnityEngine.AI;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    [SerializeField] private int randomValue;
    [SerializeField] private bool changeOfSuccess;


    private FindClosestCube targetCube;
    public NavMeshAgent agent;
    private Animator animator;
    private CubeCollider cubeCollider;
 
    private bool running;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cubeCollider = GetComponent<CubeCollider>();
        targetCube = GetComponent<FindClosestCube>();
        randomValue = Random.Range(5, 10);
    }


    private void FixedUpdate()
    {  
        if(gameObject.tag == "RedPlayer" && cubeCollider.cubes.Count < randomValue)
        {
            agent.SetDestination(targetCube.FindClosestTarget("RedCube").transform.position);
            animator.SetBool("isRunning", true);
        }

        else if (gameObject.tag == "PurplePlayer" && cubeCollider.cubes.Count < randomValue)
        {
            agent.SetDestination(targetCube.FindClosestTarget("PurpleCube").transform.position);
            animator.SetBool("isRunning", true);
        }

        else if (gameObject.tag == "GreenPlayer" && cubeCollider.cubes.Count < randomValue)
        {
            agent.SetDestination(targetCube.FindClosestTarget("GreenCube").transform.position);
            animator.SetBool("isRunning", true);
        }

        else
        {
            agent.SetDestination(destination.transform.position);
            animator.SetBool("isRunning", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Destination")
        {
            changeOfSuccess = false;
        }
    }
}

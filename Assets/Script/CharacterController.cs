using UnityEngine.AI;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    private FindClosestCube targetCube;


    public NavMeshAgent agent;
    private Animator animator;
    private CubeCollider cubeCollider;
    [SerializeField] private bool changeOfSuccess;
    private bool running;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cubeCollider = GetComponent<CubeCollider>();
        targetCube = GetComponent<FindClosestCube>();
    }


    private void FixedUpdate()
    {  
        if(changeOfSuccess == false && cubeCollider.cubes.Count < Random.Range(5,10))
        {
            agent.SetDestination(targetCube.FindClosestTarget("RedCube").transform.position);
            animator.SetBool("isRunning", true);
        }

        else if(cubeCollider.cubes.Count > Random.Range(5,10))
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

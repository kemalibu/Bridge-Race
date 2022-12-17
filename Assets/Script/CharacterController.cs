using UnityEngine.AI;
using UnityEngine;


public class CharacterController : MonoBehaviour
{ 
    [SerializeField] private GameObject topDestination;

    
    private FindClosestCube targetCube;
    public NavMeshAgent agent;
    private Animator animator;
    private CubeCollider cubeCollider;

    private int randomValue;
    private float coordinateX;

    private bool isPicking = true;
    private bool isArrived = false;

    



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cubeCollider = GetComponent<CubeCollider>();
        targetCube = GetComponent<FindClosestCube>();
        randomValue = Random.Range(5, 10);
        FindRandomXPoint();
    }


    private void FixedUpdate()
    {
        if (isArrived)
        {
            agent.SetDestination(topDestination.transform.position);
        }


        else if (isPicking && !isArrived)
        {
            if (gameObject.tag == "RedPlayer" && cubeCollider.CounterForCubeCount < randomValue)
            {
                agent.SetDestination(targetCube.FindClosestTarget("RedCube").transform.position);
                animator.SetBool("isRunning", true);
            }

            else if (gameObject.tag == "YellowPlayer" && cubeCollider.CounterForCubeCount < randomValue)
            {
                agent.SetDestination(targetCube.FindClosestTarget("YellowCube").transform.position);
                animator.SetBool("isRunning", true);
            }

            else if (gameObject.tag == "GreenPlayer" && cubeCollider.CounterForCubeCount < randomValue)
            {
                agent.SetDestination(targetCube.FindClosestTarget("GreenCube").transform.position);
                animator.SetBool("isRunning", true);
            }

            else
            {
                isPicking = false;    
            }
        }
       

        else if(!isPicking && !isArrived)
        {   
            if(cubeCollider.CounterForCubeCount > 0)
            {
                Vector3 destination = new Vector3(coordinateX,
                                       0.525f + (cubeCollider.CounterForPosition * 0.05f),
                                       5.05f + (cubeCollider.CounterForPosition * 0.1f));
                agent.SetDestination(destination);
                animator.SetBool("isRunning", true);

            }
           

            else
            {
                isPicking = true;
            }
        }
    }

    private void FindRandomXPoint()
    {
        int randomX = Random.Range(0, 4);
       
        if(randomX == 0)
        {
            coordinateX = -2.4f;
        }

        else if(randomX == 1)
        {
            coordinateX = -1.2f;
        }

        else if (randomX == 2)
        {
            coordinateX = 0f;
        }

        else if (randomX == 3)
        {
            coordinateX = 1.2f;
        }     
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground1")
        {
            isArrived = true;
        }
    }
}

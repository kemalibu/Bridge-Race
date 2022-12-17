using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomObject : MonoBehaviour
{
    [SerializeField] GameObject[] cubes;

    private CubeCollider cubeCollider;

    List<Vector3> cubesList = new List<Vector3>();

    void Start()
    {
        cubeCollider = GetComponent<CubeCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (cubeCollider.isCollected)
        {
            cubeCollider.isCollected = false;
            cubesList.Add(other.gameObject.transform.position);
            StartCoroutine(RandomObjectCoroutine());
        }

    }

    IEnumerator RandomObjectCoroutine()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(cubes[Random.Range(0,4)], cubesList[0] , Quaternion.identity);
        cubesList.RemoveAt(0);
    }

}

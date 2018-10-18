using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public Animator animator;
    public float chaseSpeed = 2;
    public float attackRange = 2;

    public GameObject targetGO;

    [SerializeField]
    private GameObject targetMarker;

    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent nav;
    
    void Start ()
    {
        targetGO = null;
        animator = GetComponent<Animator>();

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.speed = chaseSpeed;
    }
	
	void Update () {
		
	}

    public void PlaceMarker(Vector3 position)
    {
        GameObject marker = Instantiate(targetMarker, position, Quaternion.identity) as GameObject;
        StartCoroutine(DestroyMarker(marker));        
    }

    IEnumerator DestroyMarker(GameObject marker)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(marker);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER DETECTED");
            targetGO = other.gameObject;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER LOST");
            targetGO = null;
        }
    }

}

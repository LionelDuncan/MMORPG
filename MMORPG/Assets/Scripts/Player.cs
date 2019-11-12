using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    [SerializeField]
    Transform destination;

    NavMeshAgent navMeshAgent;

    // Variables
    public float movementSpeed;
    public GameObject playerMovePoint;

    private Transform pmr;

    // Functions
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
            Debug.LogError("The nav mesh agent is not attached to " + gameObject.name);
        else
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if(destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
    }
    
    /*void Update()
    {
        //Player movement
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDistance = 0.0f;

        if(playerPlane.Raycast(ray, out hitDistance))
        {
            Vector3 targetPoint = ray.GetPoint(hitDistance);
            //Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            if (Input.GetMouseButtonDown(0))
            {
               // pmr = Instantiate(transform.position)
            }
        }
    }*/
}

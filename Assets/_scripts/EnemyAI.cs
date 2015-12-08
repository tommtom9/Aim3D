using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public GameObject player;
    NavMeshAgent navMashA;
    float dis;

    [SerializeField]
    GameObject RaycastOrigin;

    Vector3 PlayerRayOffset = new Vector3(0, 2, 0);

    Vector3 fwd;    
	// Use this for initialization
	void Start () {
        navMashA = GetComponent<NavMeshAgent>();
    }

	// Update is called once per frame
	void Update () {

        dis = Vector3.Distance(transform.position, player.transform.position);

        if (dis < 11)
        {
            RaycastHit hit;
            Debug.DrawRay(RaycastOrigin.transform.position, -transform.position - (-player.transform.position  + PlayerRayOffset), Color.red);
            if (Physics.Raycast(RaycastOrigin.transform.position, -transform.position - (-player.transform.position + PlayerRayOffset), out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    navMashA.SetDestination(player.transform.position);
                }   
            }
        }
	}
}
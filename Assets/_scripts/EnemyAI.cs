using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    GameObject player;
    NavMeshAgent navMashA;
	// Use this for initialization
	void Start () {
        navMashA = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        navMashA.SetDestination(player.transform.position);
	}
}

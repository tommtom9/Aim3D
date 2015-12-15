using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {

    public  List<Vector3>   path;
    public  GameObject      player;
            NavMeshAgent    _navMashA;
            PlayerMovement  _playerMov;

    [SerializeField]
            float           _enemySightRange = 11;
    [SerializeField]
            float           _regularSpeed = 2;
    [SerializeField]
            float           _chaseSpeed = 4;
    [SerializeField]
            float           _detectionRange = 4;

            float           _playerDis;
            float           _pathDis;
            
            int             _pathCount = 0;
            
            bool            _canSeePlayer = false;
            bool            _goPatrolling = true;

    [SerializeField]
            GameObject      _raycastOrigin;

            Vector3         _playerRayOffset = new Vector3(0, 2, 0);
            Vector3         _fwd;
            Vector3         _currentMovePiont;

	void Start () {
        _navMashA = GetComponent<NavMeshAgent>();
        _navMashA.speed = _regularSpeed;
        _playerMov = player.GetComponent<PlayerMovement>();
    }

	void Update () {
        _playerDis = Vector3.Distance(transform.position, player.transform.position);
        _pathDis = Vector3.Distance(transform.position, path[_pathCount]);
        MoveTroughWaypoints();
        CheckForPlayer();
	}

    void MoveTroughWaypoints()
    {
        if (_goPatrolling == true)
        {
            if (_pathDis <= 2)
            {
                _pathCount++;
            }

            if (_pathCount >= path.Count)
            {
                _pathCount = 0;
            }
            _navMashA.SetDestination(path[_pathCount]);
        }
    }
    
    void CheckForPlayer()
    {
        if (_playerDis < _enemySightRange)
        {
            RaycastHit hit;
            Debug.DrawRay(_raycastOrigin.transform.position, -transform.position - (-player.transform.position + _playerRayOffset), Color.blue);
            if (Physics.Raycast(_raycastOrigin.transform.position, -transform.position - (-player.transform.position + _playerRayOffset), out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    _goPatrolling = false;
                    _navMashA.speed = _chaseSpeed;
                    _currentMovePiont = player.transform.position;
                    _navMashA.SetDestination(player.transform.position);
                    _canSeePlayer = true;
                }

                else if (_playerDis < _detectionRange && hit.transform.tag != "Wall" && _playerMov.walking)
                {
                    _navMashA.SetDestination(player.transform.position);
                }

                Debug.Log(Vector3.Distance(transform.position, _currentMovePiont));
                if (Vector3.Distance(transform.position,_currentMovePiont) <= 3)
                {
                    if (_canSeePlayer == false)
                    {
                        _goPatrolling = true;
                        _navMashA.speed = _regularSpeed;   
                    }
                }
            }
        }
        _canSeePlayer = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawSphere((transform.position + _playerRayOffset), _detectionRange);
    }
        
}
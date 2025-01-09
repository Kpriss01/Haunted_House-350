using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.EventSystems;

public class MonsterScriptCollider : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] float moveSpeed = 40f;
    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("MonsterSprite").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed);
    }

}

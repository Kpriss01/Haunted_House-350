using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private GameObject attack; //attaches light
    [SerializeField] private GameObject main; //attaches Enemy code
    [SerializeField] private bool attacking;


    // Start is called before the first frame update
    void Start()
    {
        attack.gameObject.SetActive(false);
        attacking = main.GetComponent<Enemy>().Attack;
    }

    // Update is called once per frame
    void Update()
    {
        attacking = main.GetComponent<Enemy>().Attack;

        if (attacking)
        {
            StartCoroutine(Flash());
        }
        else
        {
            attack.gameObject.SetActive(false);
        }
    }

    private IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.5f);
        attack.gameObject.SetActive(true);
    }
}

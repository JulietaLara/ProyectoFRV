using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAProfe : MonoBehaviour
{
    private bool scanning = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(VoltearAlFrente());
        if (scanning) {
            Debug.Log("Escaneando los que se mueven...");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(player.transform.position);
            
        }
    }

    IEnumerator VoltearAlFrente()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("voltearFrente", true);
        scanning = true;
    }
}

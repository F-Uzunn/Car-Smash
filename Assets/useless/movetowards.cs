using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetowards : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.transform.position.x>0)
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 10f * Time.deltaTime);
    }
}

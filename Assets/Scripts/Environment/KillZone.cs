using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     transform.position = new Vector3(PlayerMovement.Instance.transform.position.x,transform.position.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerMovement.Instance.transform.position.x, transform.position.y, 0);
    }
}

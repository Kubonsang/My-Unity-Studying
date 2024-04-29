using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private float rollZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rollZ += Time.deltaTime * 360f;
        transform.rotation = Quaternion.Euler(0, 0, rollZ);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{

    public float timer;
    public float scaler = 1f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * scaler;

        if(timer >= 5f)
        {
            Destroy(gameObject);
        }
        if(timer< 0)
        {
            Destroy(gameObject);
        }
    }
}

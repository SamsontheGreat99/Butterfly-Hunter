using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    public float speed3 = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bndCheck != null)
        {
            if (bndCheck.offDown)
            {
                Destroy(gameObject);
            }
        }
        Move();
    }

    public override void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed3 * Time.deltaTime;
        pos = tempPos;
    }
}

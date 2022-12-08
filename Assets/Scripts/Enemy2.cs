using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public float speed2 = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bndCheck != null)
        {
            if(bndCheck.offDown || bndCheck.offLeft)
            {
                Destroy(gameObject);
            }
        }

        Move();
    }

    public override void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed2 * Time.deltaTime;
        pos = tempPos;
        base.Move();
    }
}

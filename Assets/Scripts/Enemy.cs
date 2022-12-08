using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int score = 10;

    [Header("Set in Inspector")]
    public float speed = 5;


    protected BoundsCheck bndCheck;


    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bndCheck != null && bndCheck.offLeft)
        {
            Destroy(gameObject);
        }

        Move();
    }

    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.x -= speed*Time.deltaTime;
        pos = tempPos;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{

    public static int bflyScore = 10;
    private BoundsCheck bndCheck;

    [Header("Set in Inspector: Enemy_1")]
    public float waveFrequency = 2; // # of seconds for full sine wave
    public float waveWidth = 4; // width in meters
    public float waveRotZ = 45;
    public float speed = 5f;
    public float theta = 1f;
    public float frequency = 5f;

    private float y0; // Init x val of pos
    private float birthTime;
    private int pathOption;



    // Start is called before the first frame update
    void Start()
    {
        pathOption = Random.Range(1,4);
        Debug.Log(pathOption);
        bndCheck = this.GetComponent<BoundsCheck>();
        y0 = pos.y;

        birthTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (bndCheck.offRight)
        {
            Destroy(gameObject);
        }

        if(pathOption == 1)
        {
            Move1();
        }
        else if(pathOption == 2)
        {
            Move2();
        }
        else if(pathOption == 3)
        {
            Move3();
        }
        else if(pathOption == 4)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    public void Move1()
    {
        Vector3 tempPos = pos;
        tempPos.x += speed * Time.deltaTime;
        pos = tempPos;
    }
    public void Move2()
    {
        Vector3 tempPos = pos;

        tempPos.x += speed * Time.deltaTime;


        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.y = y0 + waveWidth * sin;
        pos = tempPos;


        Vector3 rot = new Vector3(0, 0, sin * waveRotZ);
        this.transform.rotation = Quaternion.Euler(rot);
    }

    public void Move3()
    {
        Vector3 tempPos = pos;

        tempPos.x += speed * Time.deltaTime;
        //pos = tempPos;

        //tempPos.x = pos.x; /*+ theta * Mathf.Cos(Time.time * frequency);*/
        tempPos.y = theta * Mathf.Sin(Time.time * frequency);
        theta += Time.deltaTime;
        pos = tempPos;
    }

    //public void Move4()
    //{
    //    Vector3 tempPos = pos;

    //    tempPos.x += Mathf.Cos(Time.time *frequency);
    //    pos = tempPos;
        

    //}


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
}

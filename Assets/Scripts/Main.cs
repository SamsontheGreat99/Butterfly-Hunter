using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main S;


    public GameObject[] prefabEnemies;
    public GameObject prefabButterfly;
    public GameObject prefabWhirlpool;

    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;

    public float bflySpawnPerSecond = 0.02f;
    public float bflyDefaultPadding = 1.5f;

    public float whirlpoolSpawnPerSecond = 0.5f;
    public float whirlpoolDefaultPadding = 1.5f;

    private BoundsCheck bndCheck;
    private Character character;
    private int score;
    private bool called = false;
    private bool called2 = false;


    private void Awake()
    {
        S = this;
        bndCheck = GetComponent<BoundsCheck>();
        character = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();

        Invoke("SpawnEnemy1", 1f / enemySpawnPerSecond);
        Invoke("SpawnButterfly", 1f / bflySpawnPerSecond);
        Invoke("SpawnWhirlpool", 1f / whirlpoolSpawnPerSecond);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = character.characterScore;

    }

    public void SpawnEnemy1()
    {
        //int ndx = prefabEnemies[0];
        //int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[0]);

        float enemyPadding = enemyDefaultPadding;
        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        if(go.tag == "Enemy")
        {
            Vector3 pos = Vector3.zero;
            float yMin = -bndCheck.camHeight + enemyPadding;
            float yMax = bndCheck.camHeight - enemyPadding;
            pos.y = Random.Range(yMin, yMax);
            pos.x = bndCheck.camWidth + enemyPadding;
            go.transform.position = pos;
        }
        //else if(go.tag == "Enemy2")
        //{
        //    Vector3 pos = Vector3.zero;
        //    float xMin = -bndCheck.camHeight + enemyPadding;
        //    float xMax = bndCheck.camHeight - enemyPadding;
        //    pos.x = Random.Range(0, xMax*2f);
        //    pos.y = bndCheck.camHeight + enemyPadding;
        //    go.transform.position = pos;
        //}
        //else if(go.tag == "Enemy3")
        //{
        //    Vector3 pos = Vector3.zero;
        //    float yVal = bndCheck.camHeight + enemyPadding;
        //    float xVal = 0;
        //    pos.y = yVal;
        //    pos.x = xVal;
        //    go.transform.position = pos;
        //}

        if(score >= 100 && called == false)
        {
            Invoke("SpawnEnemy2", 1f / enemySpawnPerSecond);
            called = true;
        }
        Invoke("SpawnEnemy1", 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy2()
    {
        GameObject go = Instantiate<GameObject>(prefabEnemies[1]);

        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        if (go.tag == "Enemy2")
        {
            Vector3 pos = Vector3.zero;
            float xMin = -bndCheck.camHeight + enemyPadding;
            float xMax = bndCheck.camHeight - enemyPadding;
            pos.x = Random.Range(0, xMax * 2f);
            pos.y = bndCheck.camHeight + enemyPadding;
            go.transform.position = pos;
        }

        if (score >= 200 && called2 == false)
        {
            Invoke("SpawnEnemy3", 1f / enemySpawnPerSecond);
            called2 = true;
        }
        Invoke("SpawnEnemy2", 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy3()
    {
        GameObject go = Instantiate<GameObject>(prefabEnemies[2]);

        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        if (go.tag == "Enemy3")
        {
            Vector3 pos = Vector3.zero;
            float yVal = bndCheck.camHeight + enemyPadding;
            float xVal = 0;
            pos.y = yVal;
            pos.x = xVal;
            go.transform.position = pos;
        }

        Invoke("SpawnEnemy3", 1f / enemySpawnPerSecond);
    }

    public void SpawnWhirlpool()
    {
        GameObject go = Instantiate<GameObject>(prefabWhirlpool);

        float whirlpoolPadding = whirlpoolDefaultPadding;
        if(go.GetComponent<BoundsCheck>() != null)
        {
            whirlpoolPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float yMin = -bndCheck.camHeight + whirlpoolPadding;
        float yMax = bndCheck.camHeight - whirlpoolPadding;
        float xMin = -bndCheck.camWidth + whirlpoolPadding;
        float xMax = bndCheck.camWidth - whirlpoolPadding;
        pos.y = Random.Range(yMin, yMax);
        pos.x = Random.Range(xMin, xMax);
        go.transform.position = pos;

        Invoke("SpawnWhirlpool", 1f / whirlpoolSpawnPerSecond);
    }

    public void SpawnButterfly()
    {
        GameObject go = Instantiate<GameObject>(prefabButterfly);

        float bflyPadding = bflyDefaultPadding;
        if(go.GetComponent<BoundsCheck>() != null)
        {
            bflyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float yMin = -bndCheck.camHeight + bflyPadding;
        float yMax = bndCheck.camHeight - bflyPadding;
        pos.y = Random.Range(yMin, yMax);
        pos.x = -bndCheck.camWidth - bflyPadding;
        go.transform.position = pos;

        Invoke("SpawnButterfly", 1f / bflySpawnPerSecond);
    }
}

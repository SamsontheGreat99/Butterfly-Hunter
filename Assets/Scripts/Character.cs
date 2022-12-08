using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int characterScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement of Character using mouse
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        pos.y = mousePos3D.y;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.tag == "Whirlpool")
        {
            StartCoroutine(Whirlpool());
            Destroy(go);
        }

        if(go.tag == "Butterfly")
        {
            characterScore += Butterfly.bflyScore;
            Debug.Log(characterScore);
            Destroy(go);
        }
        if(go.tag == "Enemy" || go.tag == "Enemy2" || go.tag == "Enemy3")
        {
            characterScore -= Enemy.score;
            if(characterScore <= 0)
            {
                characterScore = 0;
            }
            Destroy(go);
        }
    }

    IEnumerator Whirlpool()
    {
        CanvasGroup im = this.gameObject.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>();
        im.alpha = .5f;
        this.transform.position += new Vector3(0, 0, -5);
        yield return new WaitForSeconds(3f);
        im.alpha = 1f;
        this.transform.position += new Vector3(0, 0, 5);
 
    }
}
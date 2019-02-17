using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppear : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject obj;
    public float timeOut;
    public float timeElapsed;
    public int maxEnemySize;

    void Start()
    {

    }


    void Update()
    {

        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            if (maxEnemySize > enemies.Count)
            {
                float x = Random.Range(-25.0f, 25.0f);
                float y = Random.Range(0.0f, 3.0f);
                float z = Random.Range(-25.0f, 25.0f);

                GameObject enemy = Instantiate(obj, new Vector3(x, y, z), Quaternion.identity);
                enemies.Add(enemy);
                timeElapsed = 0.0f;
            }
            else
            {
                if (!GameObject.Find("Enemy(Clone)"))
                {
                    enemies.Clear();
                }

            }

        }

    }

}
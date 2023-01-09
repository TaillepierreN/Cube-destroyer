using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float time =0f, randX, randY;
    [SerializeField] float _spawnRate,_distance;
    [SerializeField] GameObject _objectToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>= 1/_spawnRate)
        {
            randX = Random.Range(0f,Camera.main.pixelWidth);
            randY = Random.Range(0f,Camera.main.pixelHeight);
            var camView = Camera.main.ScreenToWorldPoint(new Vector3(randX,randY,_distance));
            Instantiate(_objectToSpawn,camView,Quaternion.identity);
            time =0f;
        }
    }
}
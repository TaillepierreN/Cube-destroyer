using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float time = 0f, randX, randY;
    [SerializeField] float _spawnRate, _distance, _movingSpeed;
    [SerializeField] GameObject _objectToSpawn;
    public List<GameObject> _spawnedObject;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        SpawnCube();
        SpawnCube();
        SpawnCube();
        SpawnCube();
        SpawnCube();
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1 / _spawnRate)
        {
            // randX = Random.Range(0f, Camera.main.pixelWidth);
            // randY = Random.Range(0f, Camera.main.pixelHeight);
            // var camView = Camera.main.ScreenToWorldPoint(new Vector3(randX, randY, _distance));
            // var spawned = Instantiate(_objectToSpawn, camView, Quaternion.identity);
            time = 0f;
            // _spawnedObject.Add(spawned);
            GameObject firstObject = _spawnedObject[0];
            firstObject.SetActive(true);
            _spawnedObject.RemoveAt(0);
            _spawnedObject.Add(firstObject);


        }
        foreach (GameObject item in _spawnedObject)
        {
            item.transform.Translate(-Camera.main.transform.forward * Time.deltaTime * _movingSpeed);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _spawnedObject.Remove(hit.transform.gameObject);
                //Destroy(hit.transform.gameObject);
                hit.transform.gameObject.SetActive(false);
            }
        }

    }
    void SpawnCube()
    {
        randX = Random.Range(0f, Camera.main.pixelWidth);
        randY = Random.Range(0f, Camera.main.pixelHeight);
        var camView = Camera.main.ScreenToWorldPoint(new Vector3(randX, randY, _distance));
        var spawned = Instantiate(_objectToSpawn, camView, Quaternion.identity);
        _spawnedObject.Add(spawned);
        spawned.SetActive(false);
    }
}

using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject bolitaPrefab;
    [SerializeField] private float timeBetweenSpawns;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject copy = Instantiate(bolitaPrefab, transform.position, Quaternion.identity);
        Destroy(copy , 3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
            if(timer>= timeBetweenSpawns)
            {
                 GameObject copy = Instantiate(bolitaPrefab, transform.position, Quaternion.identity);
                Destroy(copy , 3f);
                timer = 0;
            }
        
    }
}

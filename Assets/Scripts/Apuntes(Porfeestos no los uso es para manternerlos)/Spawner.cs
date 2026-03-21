using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject bolitaPrefab;
    [SerializeField] private float timeBetweenSpawns;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LaunchBall();
    }

    private void LaunchBall()
    {
        GameObject copy = Instantiate(bolitaPrefab, transform.position, Quaternion.identity);
        copy.GetComponent<Rigidbody>().AddForce(Vector3.forward * Random.Range(5f,15f),ForceMode.Impulse);
        Destroy(copy , 3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
            if(timer>= timeBetweenSpawns)
            {
                LaunchBall();
                timer = 0;
            }
        
    }
}

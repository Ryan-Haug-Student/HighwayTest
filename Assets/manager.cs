using System.Collections;
using UnityEngine;

public class manager : MonoBehaviour
{
    public static manager i { get; private set; }

    [Header("Stats")]
    public float speed;
    public float timeBetween; //frequency
    public float timeScale;

    [SerializeField] GameObject car;
    public int totalCars = 0;
    private Vector3[] lanes;

    [Header("Logic")]
    public bool canSpawn;

    private void Start()
    {
        if (i == null)
            i = this;

        lanes = new Vector3[] 
        { new Vector3(-1.1f, .7f, -24),    //left lane
          new Vector3(0, .75f, -24),       //right lane
          new Vector3(1.1f, 0.75f, -24)    //right lane 
        }; 
    }

    private void Update()
    {
        if (canSpawn)
            StartCoroutine("SpawnCars");

        Time.timeScale = timeScale;
    }

    private IEnumerator SpawnCars()
    {
        canSpawn = false;
        int quantity = Random.Range(1, 3);
        int lastSpawnPos = -1; //assigned so first run isnt null and always used

        for (int i = 0; i < quantity; i++)
        {
            int spawnPos = Random.Range(0, 3);

            if (spawnPos != lastSpawnPos)
            { Instantiate(car, lanes[spawnPos], Quaternion.identity); lastSpawnPos = spawnPos; }
            else
                break;
        }

       yield return new WaitForSeconds(timeBetween / speed);
       canSpawn = true;
    }
}

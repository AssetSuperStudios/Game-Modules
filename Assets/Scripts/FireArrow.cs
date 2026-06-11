using UnityEngine;
using System.Collections;

public class FireArrow : MonoBehaviour
{
    public bool isActive = true;
    [SerializeField] private GameObject ArrowPrefab;
    private float fireRate = 3f; // Time in seconds between each arrow fired

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(fireArrow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
    }

    IEnumerator fireArrow()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(fireRate);
            Vector3 spawnPosition = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z); // You can adjust this to spawn the arrow at a specific position
                        
            Vector3 direction = (playerTransform.position - spawnPosition).normalized; // Assuming the arrow should move towards the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject arrow = Instantiate(ArrowPrefab, spawnPosition, rotation); 
        }
    }
}

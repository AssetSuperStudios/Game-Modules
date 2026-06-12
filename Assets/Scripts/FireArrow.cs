using UnityEngine;
using System.Collections;

public class FireArrow : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] private GameObject ArrowPrefab;
    private float fireRate = 3f; // Time in seconds between each arrow fired
    private Transform playerTransform;
    public float detectionRange = 10f; // Range within which the tower will start firing arrows

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        StartCoroutine(fireArrow());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
        {
            isActive = false;
            return; // Exit if player is not found
        }

        Vector3 distanceToPlayer = playerTransform.position - transform.position;
        float squaredDistanceToPlayer = distanceToPlayer.sqrMagnitude;
        float squaredDetectionRange = detectionRange * detectionRange;

        isActive = squaredDistanceToPlayer <= squaredDetectionRange;
    }

    void FixedUpdate()
    {
    }

    IEnumerator fireArrow()
    {
        while (true)
        {
            if (isActive)
            {
                Vector3 toPlayer = playerTransform.position - transform.position;
                Vector3 spawnDirection = toPlayer != Vector3.zero ? toPlayer.normalized : Vector3.right;
                Vector3 spawnPosition = transform.position + spawnDirection * 2.3f; // spawn 2.3 units from the tower toward the player

                float angle = Mathf.Atan2(spawnDirection.y, spawnDirection.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0, 0, angle);
                Instantiate(ArrowPrefab, spawnPosition, rotation);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
}

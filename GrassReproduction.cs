using UnityEngine;
using System.Collections;

public class GrassReproduction : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private string grassTag = "grass";
    [SerializeField] private float minSpawnDistance = 0.5f;
    [SerializeField] private float maxSpawnDistance = 1.8f;
    [SerializeField] private float checkRadius = 1.2f;
    [SerializeField] private float spawnIntervalMin = 10f;
    [SerializeField] private float spawnIntervalMax = 25f;
    [SerializeField][Range(0, 1)] private float spawnChance = 0.4f;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckHeight = 2f;
    [SerializeField] private float groundCheckDistance = 3f;
    [SerializeField] private float spawnHeightOffset = 0.1f;

    [Header("Advanced")]
    [SerializeField] private bool checkForObstacles = true;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private int maxAttempts = 5;

    private float nextSpawnTime;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            TrySpawnGrass();
            SetNextSpawnTime();
        }
    }

    private void TrySpawnGrass()
    {
        if (Random.value > spawnChance) return;

        for (int i = 0; i < maxAttempts; i++)
        {
            // Генерация случайного направления
            Vector2 randomCircle = Random.insideUnitCircle.normalized;
            Vector3 direction = new Vector3(randomCircle.x, 0, randomCircle.y);
            float distance = Random.Range(minSpawnDistance, maxSpawnDistance);

            // Расчет базовой позиции
            Vector3 targetPos = transform.position + direction * distance;

            // Проверка земли
            if (FindGroundPosition(targetPos, out Vector3 validPosition))
            {
                if (IsValidSpawnPosition(validPosition))
                {
                    SpawnNewGrass(validPosition);
                    return;
                }
            }
        }
    }

    private bool FindGroundPosition(Vector3 targetPos, out Vector3 groundPosition)
    {
        // Проверяем сверху вниз
        if (Physics.Raycast(
            targetPos + Vector3.up * groundCheckHeight,
            Vector3.down,
            out RaycastHit hit,
            groundCheckDistance,
            groundLayer))
        {
            groundPosition = hit.point + Vector3.up * spawnHeightOffset;
            return true;
        }

        groundPosition = Vector3.zero;
        return false;
    }

    private bool IsValidSpawnPosition(Vector3 position)
    {
        // Проверка на другие травы
        Collider[] nearbyGrass = Physics.OverlapSphere(position, checkRadius);
        foreach (var collider in nearbyGrass)
        {
            if (collider.CompareTag(grassTag) && collider.gameObject != gameObject)
                return false;
        }

        // Проверка на препятствия
        if (checkForObstacles && Physics.CheckSphere(position, 0.3f, obstacleLayer))
            return false;

        return true;
    }

    private void SpawnNewGrass(Vector3 position)
    {
        GameObject newGrass = Instantiate(gameObject, position, Quaternion.identity);
        newGrass.name = grassTag;
        StartCoroutine(AnimateGrowth(newGrass.transform));
    }

    private IEnumerator AnimateGrowth(Transform grassTransform)
    {
        float duration = Random.Range(1.5f, 3f);
        float elapsed = 0;
        Vector3 startScale = Vector3.one * 0.1f;
        Vector3 endScale = Vector3.one * Random.Range(0.9f, 1.1f);

        while (elapsed < duration)
        {
            grassTransform.localScale = Vector3.Lerp(startScale, endScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    private void OnDrawGizmosSelected()
    {
        // Зона спавна
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawWireSphere(transform.position, maxSpawnDistance);

        // Зона проверки
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawWireSphere(transform.position, checkRadius);

        // Линия проверки земли
        Gizmos.color = Color.blue;
        Vector2 randomCircle = Random.insideUnitCircle.normalized;
        Vector3 testDirection = new Vector3(randomCircle.x, 0, randomCircle.y);
        Vector3 testPos = transform.position + testDirection * ((minSpawnDistance + maxSpawnDistance) / 2);
        Gizmos.DrawLine(testPos + Vector3.up * groundCheckHeight,
                       testPos + Vector3.up * groundCheckHeight - Vector3.up * groundCheckDistance);
    }
}
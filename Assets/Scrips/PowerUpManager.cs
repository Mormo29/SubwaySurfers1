using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField]
    private int minPlatformsNumber = 5;
    [SerializeField]
    private int maxPlatformsNumber = 7;
    [SerializeField]
    private InstantiatePoolObjects[] powerUpPools;
    [SerializeField]
    private float powerUpOffset = 1f;
    private int platformsNumber;
    private int platformsCounter = 0;

    public void Awake()
    {
        SetPlatformsNumber();
    }
    private void SetPlatformsNumber()
    {
        platformsNumber = Random.Range(minPlatformsNumber, maxPlatformsNumber);
    }
    public void PlatformPassed(Platform platform)
    {
        platformsCounter++;
        if (platformsCounter >= platformsNumber)
        {
            SpawnPowerUp(platform);
            platformsCounter = 0;
            SetPlatformsNumber();
        }
    }
    private void SpawnPowerUp(Platform platform)
    {
        InstantiatePoolObjects pool = powerUpPools[Random.Range(0, powerUpPools.Length)];
        pool.InstantiateObject(Vector3.zero);
        GameObject powerUp = pool.GetCurrentObject();
        platform.AddPowerUp(powerUp);
        powerUp.transform.localPosition += Vector3.up * powerUpOffset;
   
    }

}

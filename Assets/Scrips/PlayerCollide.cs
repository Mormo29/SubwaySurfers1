using UnityEngine;
using UnityEngine.Events;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField]
    private string obstacleTag = "Obstacle";
    [SerializeField]
    private string coinTag = "Coin";
    [SerializeField]
    private string jumpPowerUpTag = "JumpPowerUp";
    [SerializeField]
    private string jetpackTag = "JetPack";
    [SerializeField]
    private UnityEvent<Transform> onJetpackCollected;
    [SerializeField]
    private UnityEvent<Transform> onMagnetCollected;
    [SerializeField]
    private UnityEvent<Transform> onObstacleCollision;
    [SerializeField]
    private UnityEvent<Transform> onJumpPowerUpCollected;
    [SerializeField]
    private UnityEvent<Transform> onCoinCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            onObstacleCollision?.Invoke(transform);
        }
        else if (other.CompareTag(coinTag))
        {
           CollectCoin(other.gameObject);
        }
        else if (other.CompareTag(jumpPowerUpTag))
        {
            onJumpPowerUpCollected?.Invoke(transform);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Magnet"))
        {
            onMagnetCollected?.Invoke(transform);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag(jetpackTag))
        {
            onJetpackCollected?.Invoke(transform);
            other.gameObject.SetActive(false);
        }
    }
        public void CollectCoin (GameObject coin)
        {
            coin.SetActive(false);
            onCoinCollected?.Invoke(transform);
        }
}



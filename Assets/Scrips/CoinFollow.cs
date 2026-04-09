using UnityEngine;

public class CoinFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float followSpeed = 5f;
    [SerializeField]
    private float minimumDistance = 0.05f;
    private bool canFollow = true;
    private Vector3 originalPosiition = Vector3.zero;
    public void Awake()
    {
        originalPosiition = transform.localPosition;
    }
    private void OnEnable()
    {
        canFollow = true;
        player = null;
        if(originalPosiition != Vector3.zero) transform.localPosition = originalPosiition;
    }
    public void StartFollow(Transform playerTransform)
    {
        if (!canFollow) return;
        canFollow = false;
        player = playerTransform;
    }
    public void Update() 
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < minimumDistance)
            {
                player.GetComponent<PlayerCollide>()?.CollectCoin(gameObject);
                player = null;
            }
        }
    }
}

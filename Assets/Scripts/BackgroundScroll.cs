using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.2f;
    private Renderer rend;
    private float currentOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        currentOffset += scrollSpeed * ScoreManager.Instance.globalSpeedMultiplier * Time.deltaTime;
        rend.material.mainTextureOffset = new Vector2(currentOffset, 0);
    }
}
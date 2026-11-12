using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // Die Geschwindigkeit, mit der sich der Hintergrund bewegt
    public float scrollSpeed = 0.2f;
    private Renderer rend;

    void Start()
    {
        // Holt sich den Renderer des Quads
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Verschiebt die Textur kontinuierlich über die Zeit
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }
}

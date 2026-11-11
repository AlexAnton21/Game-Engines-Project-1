using UnityEngine;

public class Player : MonoBehaviour
{
    public float schubKraft = 15f;

    private Rigidbody2D rb; // Ein Platzhalter für unsere Schwerkraft-Komponente

    void Start()
    {
        // Wenn das Spiel startet, sucht sich das Skript den Rigidbody (die Schwerkraft)
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // GetKey prüft: Wird die Leertaste (oder linke Maustaste) gerade GEHALTEN?
        // (Beim Flappy Bird Tutorial steht hier "GetKeyDown" für nur einmal drücken)
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            // Wenn ja: Füge eine Kraft (AddForce) nach oben (Vector2.up) hinzu.
            rb.AddForce(Vector2.up * schubKraft);
        }
    }
}

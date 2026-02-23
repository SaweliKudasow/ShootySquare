using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    public Transform topWall, leftWall, rightWall; // Wände
    public float wallThickness = 0.5f; // Wandstärke

    private int lastScreenWidth, lastScreenHeight; // Bildschirmgröße

    void Start()
    {
        UpdateBorder(); // Grenzen setzen
    }

    void Update()
    {
        // Bildschirmgröße geändert?
        if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
        {
            UpdateBorder(); // Grenzen aktualisieren
            lastScreenWidth = Screen.width; // Breite speichern
            lastScreenHeight = Screen.height; // Höhe speichern
        }
    }

    void UpdateBorder()
    {
        Camera cam = Camera.main; // Kamera
        float camHeight = 2f * cam.orthographicSize; // Kamerahöhe
        float camWidth = camHeight * cam.aspect; // Kamerabreite

        Vector3 camPos = cam.transform.position; // Kameraposition

        // obere Wand Position und Größe
        topWall.position = new Vector3(camPos.x, camPos.y + camHeight / 2 + wallThickness / 2, 0);
        topWall.localScale = new Vector3(camWidth, wallThickness, 1);

        // linke/rechte Wand Position
        leftWall.position = new Vector3(camPos.x - camWidth / 2 - wallThickness / 2, camPos.y, 0);
        rightWall.position = new Vector3(camPos.x + camWidth / 2 + wallThickness / 2, camPos.y, 0);

        // linke/rechte Wand Größe
        leftWall.localScale = new Vector3(wallThickness, camHeight, 1);
        rightWall.localScale = new Vector3(wallThickness, camHeight, 1);
    }
}

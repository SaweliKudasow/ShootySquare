using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    public Transform topWall, leftWall, rightWall; // стены
    public float wallThickness = 0.5f; // толщина стен

    private int lastScreenWidth, lastScreenHeight; // отслеживание изменений размеров экрана

    void Start()
    {
        UpdateBorder(); // устанавливаем границы стен
    }

    void Update()
    {
        // проверяем изменился ли размер экрана
        if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
        {
            UpdateBorder(); // обновляем границы
            lastScreenWidth = Screen.width; // сохраняем новое значение ширины экрана
            lastScreenHeight = Screen.height; // сохраняем новое значение высоты экрана
        }
    }

    void UpdateBorder()
    {
        Camera cam = Camera.main; // получаем камеру
        float camHeight = 2f * cam.orthographicSize; // высота камеры
        float camWidth = camHeight * cam.aspect; // ширина камеры

        Vector3 camPos = cam.transform.position; // позиция камеры

        // устанавливаем позицию и размер верхней стены
        topWall.position = new Vector3(camPos.x, camPos.y + camHeight / 2 + wallThickness / 2, 0);
        topWall.localScale = new Vector3(camWidth, wallThickness, 1);

        // устанавливаем позицию левой и правой стены
        leftWall.position = new Vector3(camPos.x - camWidth / 2 - wallThickness / 2, camPos.y, 0);
        rightWall.position = new Vector3(camPos.x + camWidth / 2 + wallThickness / 2, camPos.y, 0);

        // устанавливаем размер левой и правой стены
        leftWall.localScale = new Vector3(wallThickness, camHeight, 1);
        rightWall.localScale = new Vector3(wallThickness, camHeight, 1);
    }
}

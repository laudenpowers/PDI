using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Color data;

    public Text rText, gText, bText;
    public Button grayscaleButton;

    Color[] color;

    public void Start()
    {
        color = gameObject.GetComponent<SpriteRenderer>().sprite.texture.GetPixels();
        grayscaleButton.onClick.AddListener(turnGray);
    }

    public void Update()
    {
        PixelToMouse.Instance().GetSpritePixelColorUnderMousePointer(gameObject.GetComponent<SpriteRenderer>(), out data);
        rText.text = data.r.ToString();
        gText.text = data.g.ToString();
        bText.text = data.b.ToString();
    }

    public void turnGray()
    {
        Texture2D texture = gameObject.GetComponent<SpriteRenderer>().sprite.texture;
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color pixel = texture.GetPixel(x,y);

                Color color = new Color((pixel.r + pixel.g + pixel.b)/3, (pixel.r + pixel.g + pixel.b) / 3, (pixel.r + pixel.g + pixel.b) / 3, 1);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }
}

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class CanvasScript : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ImageUploaderCaptureClick();
    [SerializeField]
    private Material _360Texture;

    IEnumerator LoadTexture(string url)
    {
        WWW image = new WWW(url);
        yield return image;
        Texture2D texture = new Texture2D(1, 1);
        image.LoadImageIntoTexture(texture);
        Debug.Log("Loaded image size: " + texture.width + "x" + texture.height);
        Debug.Log("image:" + image.texture);
        _360Texture.mainTexture = texture;
    }

    void FileSelected(string url)
    {
        StartCoroutine(LoadTexture(url));
    }

    public void OnButtonPointerDown()
    {
        ImageUploaderCaptureClick();
    }
}
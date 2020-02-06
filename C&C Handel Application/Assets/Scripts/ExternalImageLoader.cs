﻿using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.Video;

public class ExternalImageLoader : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ImageUploaderCaptureClick();
    [SerializeField]
    private Material _360Texture;
    ProjectDataManager projectData;
    [SerializeField]
    private bool isVideo = false;

    [SerializeField]
    private GameObject _360Object;

    private void Start()
    {
        _360Object.GetComponent<VideoPlayer>();
    }
    IEnumerator LoadTexture(string url)
    {
        WWW image = new WWW(url);
        yield return image;
        
        Texture2D texture = new Texture2D(1, 1);
        image.LoadImageIntoTexture(texture);
        Debug.Log("Loaded image size: " + texture.width + "x" + texture.height);
        Debug.Log("image:" + image.texture);
        _360Texture.mainTexture = texture;
     //   projectData.Set360ImageForCurrentScene(texture);
    }
    IEnumerator LoadVideo(string url)
    {
        WWW video = new WWW(url);
        yield return video;

        VideoPlayer newVideo = _360Object.GetComponent<VideoPlayer>();
        newVideo.url = video.url;
        /*if (string.IsNullOrEmpty(url))
        {
            url = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
        }*/

        //newVideo.SetTargetAudioSource(0, audioSource);

    }

    void FileSelected(string url)
    {
        Debug.Log(url);
        if (!isVideo)
        {
            StartCoroutine(LoadTexture(url));
        }
        else
        {
            StartCoroutine(LoadVideo(url));
        }
    }

    public void OnButtonImageDown()
    {
        isVideo = false;
        ImageUploaderCaptureClick();
    }
    public void OnButtonVideoDown()
    {
        isVideo = true;
        ImageUploaderCaptureClick();
    }
}
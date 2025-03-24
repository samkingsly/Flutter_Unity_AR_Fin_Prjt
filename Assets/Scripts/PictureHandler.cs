using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class PictureHandler : MonoBehaviour
{
    private void Start()
    {
        RequestPermissionAsynchronously(NativeGallery.PermissionType.Write , NativeGallery.MediaType.Image);
    }
    public void TakePhoto()
    {
        StartCoroutine(TakeAPhoto());
    }

    IEnumerator TakeAPhoto()
    {
        yield return new WaitForEndOfFrame();

        Camera camera = Camera.main;

        int width = Screen.width;
        int height = Screen.height;

        RenderTexture rt = new RenderTexture(width, height, 24);
        camera.targetTexture = rt;

        var currentRT = RenderTexture.active;
        RenderTexture.active = rt;

        camera.Render();

        Texture2D image = new Texture2D(width, height);
        image.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        image.Apply();
        
        camera.targetTexture = null;
        
        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;
        
        byte[] bytes = image.EncodeToPNG();
        string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        string filepath = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllBytes(filepath, bytes);

        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(bytes, "GalleryTest", fileName, (success, path) => Debug.Log("Media save result: " + success + " " + path));

        Debug.Log("Permission result: " + permission);

        Destroy(rt);
        Destroy(image);
    }

    private async void RequestPermissionAsynchronously(NativeGallery.PermissionType permissionType, NativeGallery.MediaType mediaTypes)
    {
        NativeGallery.Permission permission = await NativeGallery.RequestPermissionAsync(permissionType, mediaTypes);
        Debug.Log("Permission result: " + permission);
    }


}

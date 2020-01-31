using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(GetData());
        StartCoroutine(GetUsers());
    }

    //IEnumerator GetData()
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Get("http://groep03.mediaenvormgeving.nl/GetData.php"))
    //    {
    //        yield return www.Send();

    //        if (www.isNetworkError || www.isHttpError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            // show results as text
    //            Debug.Log(www.downloadHandler.text);

    //            byte[] results = www.downloadHandler.data;
    //        }
    //    }
    //}


    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://groep03.mediaenvormgeving.nl/GetUsers.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // show results as text
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }

}

using UnityEngine;
using System.Collections;

public class OpenURL : MonoBehaviour


{
    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/Ozi_stuff");
    }

    public void PlayStore()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Ozi");
    }
}

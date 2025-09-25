using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMusikSetting : MonoBehaviour
{
    [SerializeField] List<MasterAudio> mastersAudio;

    private void Start()
    {
        for(int i = 0; i < mastersAudio.Count; i++)
        {
            mastersAudio[i].LoadAudio();
        }
    }

    public void SaveAllAudio()
    {
        for(int i = 0; i < mastersAudio.Count; i++)
        {
            mastersAudio[i].SaveAudio();
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSound : MonoBehaviour
{
    public static ItemSound Instance;
    [SerializeField]
    AudioClip Loot;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Multiple instances of SoundEffects!");
        }
        Instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void MakeSound(AudioClip OriginalClip)
    {
        AudioSource.PlayClipAtPoint(OriginalClip, transform.position);
    }

    public void LootSound()
    {
        MakeSound(Loot);
    }
}

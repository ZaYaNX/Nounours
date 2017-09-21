using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taille des chunks : 2.88 / 4.16

public class ProceduralManager : MonoBehaviour
{
    [SerializeField]List<GameObject> chunks = new List<GameObject>();
    float chunkLenght = 20.0f;
    float nmbChunk = 12.0f;
    int RandomChunk;
    int LastChunk;
    GameObject newChunk;
    [SerializeField]
    GameObject firstZone;
    [SerializeField]
    GameObject lastZone;
    
	
	void Start ()

    {
        Instantiate(firstZone);
        for (float i = 0.0f; i <= nmbChunk; i = i + chunkLenght)
        {
            RandomChunk = Random.Range(0, chunks.Count);
            if (RandomChunk != LastChunk)

            {
                newChunk = Instantiate(chunks[RandomChunk]);
                LastChunk = RandomChunk;
            }

            else

            {
                LastChunk = RandomChunk + 1;
                newChunk = Instantiate(chunks[RandomChunk + 1]);
            }
            newChunk.transform.position = new Vector2(i, 0f);
        }
        Instantiate(lastZone);
	}
	
	
	void Update ()
    {
		
	}
}

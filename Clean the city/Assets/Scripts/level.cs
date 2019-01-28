using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int breakableblocks;
    SceneLoader sceneloder;

    private void Start()
    {
        sceneloder = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks()
    {
        breakableblocks++;
    }

    public void Blockdestroyed()
    {
        breakableblocks--;
        if (breakableblocks<=0)
        {
            sceneloder.LoadNextScene();
        }
    }
}

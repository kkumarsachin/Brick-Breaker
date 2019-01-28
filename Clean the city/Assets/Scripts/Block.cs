using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip breaksound;
    [SerializeField] GameObject blocksparkes;
   
    [SerializeField] int timeshits;
    [SerializeField] Sprite[] hitsprites;
    level levels;

    private void Start()
    {
        Countbrekblock();
    }

    private void Countbrekblock()
    {
        levels = FindObjectOfType<level>();
        if (tag == "Breakabke")
        {
            levels.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakabke")
        {
            Handlehit();
        }
    }

    private void Handlehit()

    {
             
         timeshits++;
        int maxhits = hitsprites.Length + 1;
        if (timeshits >= maxhits)
            {
                Destoryblock();
            }
            else
        {
            Shownexthitsprint();
        }

        
    }

    private void Shownexthitsprint()
    {
        int spriteindex = timeshits - 1;
        if (hitsprites[spriteindex] != null){
            GetComponent<SpriteRenderer>().sprite = hitsprites[spriteindex];
        }
        else{
            Debug.Log("Block sprite is missing from the array"+gameObject.name);
        }
    }

    private void Destoryblock()

    {
        
        Playblockdestroy();
        Destroy(gameObject);
        levels.Blockdestroyed();
        Triggersparkes();
    }

    private void Playblockdestroy()
    {
        FindObjectOfType<GameStatus>().AddtoScore();
        AudioSource.PlayClipAtPoint(breaksound, Camera.main.transform.position);
    }

    void Triggersparkes()
    {
        GameObject sparkes = Instantiate(blocksparkes, transform.position, transform.rotation);
        Destroy(sparkes,1f);
    }
}

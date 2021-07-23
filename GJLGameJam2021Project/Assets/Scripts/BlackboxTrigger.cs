using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackboxTrigger : Interactable
{
    private SpriteRenderer destroying;
    public Sprite part1Destroy;
    public Sprite part2Destroy;
    public Sprite part3Destroy;
    private int keyPressCounter = 0;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        destroying = GetComponent<SpriteRenderer>();
    }

    protected override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && keyPressCounter == 0)
        {
            destroying.sprite = part1Destroy;
            keyPressCounter = 1;
            print(keyPressCounter);
        }
        else if(Input.GetKeyDown(KeyCode.E) && keyPressCounter == 1)
        {
            destroying.sprite = part2Destroy;
            keyPressCounter = 2;
            print(keyPressCounter);
        }
        else if(Input.GetKeyDown(KeyCode.E) && keyPressCounter == 2)
        {
            destroying.sprite = part3Destroy;
            keyPressCounter = 3;
            print(keyPressCounter);
        }
        else if (Input.GetKeyDown(KeyCode.E) && keyPressCounter == 3)
        {
            LevelManager.current.DestroyBlackBox();
            Destroy(gameObject);
            //keyPressCounter = 0;
        }
        
        
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackboxTrigger : Interactable
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Interact()
    {
        LevelManager.current.DestroyBlackBox();
        Destroy(gameObject);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}

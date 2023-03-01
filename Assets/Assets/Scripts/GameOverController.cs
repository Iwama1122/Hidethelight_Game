using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : AliceCursoleStage
{
    [SerializeField] private GameObject normal;
    [SerializeField] private GameObject hard;
    [SerializeField] private GameObject nightmare;
    // Start is called before the first frame update
    void Start()
    {
        normal.SetActive(false);
        hard.SetActive(false);
        nightmare.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(stagecount) {
            case 1:
                normal.SetActive(true);
                break;
            case 2:
                hard.SetActive(true);
                break;
            case 3:
                nightmare.SetActive(true);
                break;
        }
    }
}

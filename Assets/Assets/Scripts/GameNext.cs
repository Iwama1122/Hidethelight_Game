using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNext : MonoBehaviour
{
    [SerializeField] private GameObject Nextka;
    NextKarten ne;
    // Start is called before the first frame update
    void Awake()
    {
        ne = Nextka.GetComponent<NextKarten>();
     
        if(AliceCursoleStage.stagecount == 1 && Alicetyutoriaru.gametutorial == true) { 
            
            Invoke("Tyuto", 5.0f);
        }
        if(AliceCursoleStage.stagecount == 1 && Alicetyutoriaru.nottyutorial == true) {
           
            Invoke("Game", 5.0f);

        }
       
    }

    // Update is called once per frame
    void Update()
    {
      

    }

    void Game() {
        SceneManager.LoadScene("SampleScene");
        
    }
    void Tyuto() {
        SceneManager.LoadScene("TyutorialScene");
    }
}

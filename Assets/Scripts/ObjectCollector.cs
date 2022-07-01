using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {

        if (!Game.isGameover)
        {
            string tag = other.tag;

            if (tag.Equals("GoodObjects"))
            {
                Destroy(other.gameObject);
                LevelManager.Instance.objectsInScene--;
                UIManager.Instance.UpdateLevelProgress();

                if (LevelManager.Instance.objectsInScene==0)
                {
                    Game.isGameover = true;
                    UIManager.Instance.levelCompletedText.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;

                    LevelManager.Instance.PlayWinFx();

                    StartCoroutine(NextLevel());
                    
                }



            }

            if (tag.Equals("BadObjects"))
            {
                Destroy(other.gameObject);
                Game.isGameover = true;
                CameraShake.Shake(.3f, .032f);
                StartCoroutine(RestartLevel());
                
            }
        }

        
        IEnumerator NextLevel()
        {
            yield return new WaitForSeconds(2f);
             LevelManager.Instance.LoadNextLevel();

        }

        IEnumerator RestartLevel()
        {
            yield return new WaitForSeconds(.5f);
            LevelManager.Instance.RestartLevel();

        }
        
       

         
    }




}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KartGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        //[Tooltip("What is the name of the scene we want to load when clicking the button?")]

        public void LoadTargetScene(int sceneIndex) 
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}

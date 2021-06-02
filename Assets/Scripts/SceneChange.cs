using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public string scene;
    private void OnTriggerEnter(Collider other)
    {
        IADeath iA = other.GetComponent<IADeath>();
        if(iA != null)
        {
            LoadSceneFin(scene);
        }
    }

    public void LoadSceneFin(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

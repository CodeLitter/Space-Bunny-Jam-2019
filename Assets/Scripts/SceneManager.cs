using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void Load(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}

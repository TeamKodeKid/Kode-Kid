﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    /// <summary>
    /// Exiting level timer
    /// </summary>
    [SerializeField] float LvlLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMo = 0.2f;

    /// <summary>
    ///  When hitting the exit sprite it will trigger this method to move to next levele.
    /// </summary>
    /// <param name="collision">user to sprite collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }

    /// <summary>
    /// Next level rendering slowly
    /// </summary>
    /// <returns>next scene</returns>
    IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelExitSlowMo;
        yield return new WaitForSecondsRealtime(LvlLoadDelay);
        Time.timeScale = 1f;


        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}

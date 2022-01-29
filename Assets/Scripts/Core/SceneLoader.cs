using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : BaseSingletonBehaviour<SceneLoader>
{
	public GameObject fadeScreen;
	private Animator _anim;

	private int _nextLevelIndex;

    private void Start()
    {
		//DontDestroyOnLoad(this);
		_anim = fadeScreen.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
	{
	}

	public void FadeToNextLevel()
	{
		FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void FadeToLevel(int levelIndex)
	{
		_nextLevelIndex = levelIndex;
		_anim.SetTrigger("FadeIn");
	}

	public void OnFadeComplete()
	{
		SceneManager.LoadScene(_nextLevelIndex);
		_anim.SetTrigger("FadeOut");
	}
}

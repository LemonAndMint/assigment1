using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public TopKontrol tk;
	public Level[] levels;
  public GameObject winPanel;
  public GameObject losePanel;
  public DynamicJoystick joystick;
  public GameObject cam1;
  public GameObject cam2;

	private int levelindex;
	private GameObject level;
  private GameState gamestate;
  private bool istouched;

  // Update is called once per frame
  void Update()
  {
      switch (gamestate)
		{
			case GameState.empty:

				levelindex = PlayerPrefs.GetInt("levelindex");

				if (PlayerPrefs.GetInt("randomlevel") == 1)
				{
					levelindex = Random.Range(0, levels.Length - 1);
				}

				level = Instantiate(levels[levelindex].levelplane, Vector3.zero, Quaternion.identity);

				gamestate = GameState.initiliaze;
				break;
			case GameState.initiliaze:
				break;
			case GameState.start:
				break;
			case GameState.stay:
				break;
			case GameState.restart:
      istouched = joystick.backg.activeSelf;
        if(istouched){
          restart();
        }
				break;
			case GameState.next:
        istouched = joystick.backg.activeSelf;
        if(istouched){
          next();
        }
				break;
			default:
				break;
		}
  }
  public void next()
	{
		levelindex++;
		PlayerPrefs.SetInt("levelindex", levelindex);
		if (levelindex >= levels.Length)
		{
			levelindex--;
			PlayerPrefs.SetInt("randomlevel", 1);
		}
		restart();
	}

  public void restart()
	{
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}

  public void win(){
    winPanel.SetActive(true);
    tk.enabled = false;

    cam1.SetActive(false);
    cam2.SetActive(true);

    gamestate = GameState.next;
  }
  public void lose(){
    losePanel.SetActive(true);
    tk.enabled = false;

    gamestate = GameState.restart;

  }
}

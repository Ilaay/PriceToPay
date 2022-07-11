using UnityEngine;
using UnityEngine.SceneManagement;

namespace ApplicationData
{
	public class SceneLoader : MonoBehaviour
	{
		public void QuitGame()
		{
			QuitGame();
		}

		public void LoadScene(string scene)
		{
			SceneManager.LoadScene(scene);
		}
	}
}

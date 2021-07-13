using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIControllers.UIButton
{
    public class RestartButton : MonoBehaviour, IButtonBehaviour
    {
        public void OnClickButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
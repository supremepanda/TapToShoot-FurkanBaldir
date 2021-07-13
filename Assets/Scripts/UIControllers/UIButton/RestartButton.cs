using UnityEngine.SceneManagement;

namespace UIControllers.UIButton
{
    public class RestartButton : IButtonBehaviour
    {
        public void OnClickButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
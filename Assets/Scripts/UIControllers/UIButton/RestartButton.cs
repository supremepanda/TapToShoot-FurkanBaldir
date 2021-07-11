using UnityEngine.SceneManagement;

namespace UIControllers.UIButton
{
    public class RestartButton : UIButtonBehaviour
    {
        public override void OnClickButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
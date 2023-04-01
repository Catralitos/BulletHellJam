using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    /// <summary>
    /// The tutorial screen manager
    /// </summary>
    public class TutorialScreenManager: MonoBehaviour
    {
        /// <summary>
        /// The return to title screen button
        /// </summary>
        public Button titleButton;
        
        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            titleButton.onClick.AddListener(ToTitle);
        }

        /// <summary>
        /// Returns to the title screen.
        /// </summary>
        private static void ToTitle()
        {
            SceneManager.LoadScene(0);
        }
    }
}

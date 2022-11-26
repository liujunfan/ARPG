using UnityEngine.UI;

namespace Nono
{
    public class PlayingState : UIAnimatedState
    {
        public Text text;

        public void SetLevel(int id)
        {
            text.text = $"Level-{id}";
        }
    }
}
using UnityEngine;

public class OpenViewScript : MonoBehaviour
{
    public GameObject view;
    public GameObject board;

    public void WhenClicked()
    {
        view.SetActive(true);
        if (board)
        {
            board.SetActive(true);
        }
    }
}

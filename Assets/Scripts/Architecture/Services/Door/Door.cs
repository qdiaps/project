using UnityEngine;

namespace Architecture.Services.Door
{
    public class Door : MonoBehaviour
    {
        public void Open()
        {
            GetComponent<BoxCollider>()
                .enabled = false;
            Debug.Log("Door open");
        }
    }
}
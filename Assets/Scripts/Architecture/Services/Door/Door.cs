using UnityEngine;

namespace Architecture.Services.Door
{
    public class Door : MonoBehaviour
    {
        public void Open()
        {
            GetComponent<BoxCollider>()
                .isTrigger = true;
            Debug.Log("Door open");
        }
    }
}
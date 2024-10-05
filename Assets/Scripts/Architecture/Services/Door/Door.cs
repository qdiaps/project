using UnityEngine;

namespace Architecture.Services.Door
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _openingDoorAudios;
        
        public void Open()
        {
            var index = Random.Range(0, _openingDoorAudios.Length);
            AudioSource.PlayClipAtPoint(_openingDoorAudios[index], transform.position);
            GetComponent<BoxCollider>()
                .enabled = false;
            Debug.Log("Door open");
        }
    }
}
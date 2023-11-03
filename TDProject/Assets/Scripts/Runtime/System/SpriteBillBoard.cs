using UnityEngine;

namespace Runtime.System
{
    public class SpriteBillBoard : MonoBehaviour
    {

        [SerializeField] private bool freezeXZAxis = true;
    
        private void Start()
        {
            EventManager.Instance.OnCameraChanged += BillBoardEffect;
            EventManager.Instance.OnCameraChangedRotation += BillBoardEffectLookUp;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnCameraChanged -= BillBoardEffect;
            EventManager.Instance.OnCameraChangedRotation -= BillBoardEffectLookUp;
        }

        private void BillBoardEffect(Quaternion position)
        {
            if (freezeXZAxis)
            {
                transform.rotation = Quaternion.Euler(0f,position.eulerAngles.y,0f);
            }
        }

        private void BillBoardEffectLookUp(Quaternion rotation)
        {
            if (!freezeXZAxis)
            {
                transform.rotation = rotation;
            }
        }


    }
}

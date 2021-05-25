using UnityEngine;
using UniRx;

namespace InputSwitcher{
    public class Hoge : MonoBehaviour, IInputReceiver{
        void Start(){
            InputSw.GetKey(this, KeyCode.C)
                   .Subscribe(_ => {Debug.Log("Hoge");});
        }
    }
}
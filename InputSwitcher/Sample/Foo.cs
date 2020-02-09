using UnityEngine;
using UniRx;

namespace InputSwitcher{
    public class Foo : MonoBehaviour, IInputReceiver{
        void Start(){
            InputSw.GetKey(this, KeyCode.C)
                   .Subscribe(_ => {Debug.Log("Foo");});
        }
    }
}
using InputAsRx.Triggers;
using UnityEngine;
using UniRx;

namespace InputSwitcher{
    public class SampleInputManager : MonoBehaviour{
        [SerializeField] private Hoge hoge;
        [SerializeField] private Foo foo;

        private void Start(){
            // InputSw.IsLogWrite = true; // Default
            
            this.OnKeyDownAsObservable(KeyCode.H)
                .Subscribe(_ => {
                    InputSw.Switch(hoge);
                });

            this.OnKeyDownAsObservable(KeyCode.F)
                .Subscribe(_ => {
                    InputSw.Switch(foo);
                });

            this.OnKeyDownAsObservable(KeyCode.P)
                .Subscribe(_ => {
                    InputSw.Pause();
                    // InputSw.IsActive = false;
                });

            this.OnKeyDownAsObservable(KeyCode.R)
                .Subscribe(_ => {
                    InputSw.Resume();
                    // InputSw.IsActive = true;
                });
        }
    }
}

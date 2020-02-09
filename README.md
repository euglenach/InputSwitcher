# InputSwitcher

# 必要なもの
[UniRx](https://github.com/neuecc/unirx)

[InputAsObservable](https://github.com/euglenach/InputAsObservable)

# 使い方

## Input元に IInputReceiverインターフェース を実装する

```C#
using UnityEngine;
using UniRx;
using InputSwitcher;

public class Hoge : MonoBehaviour, IInputReceiver{

}

```

## InputSwクラスのメソッドにIInputReceiverのインスタンスを渡す

```C#
using UnityEngine;
using UniRx;
using InputSwitcher;

public class Hoge : MonoBehaviour, IInputReceiver{
    void Start(){
        InputSw.GetKey(this, KeyCode.C)
            .Subscribe(_ => {Debug.Log("Hoge");}); //Cをおすとほげええええ
    }
}

```

```C#
using UnityEngine;
using UniRx;
using InputSwitcher;

public class Foo : MonoBehaviour,IInputReceiver{
    void Start(){
        InputSw.GetKey(this, KeyCode.C)
               .Subscribe(_ => {Debug.Log("Foo");}); //Cを押すとふううううう
    }
}
```

# 分岐方法を決定する

```C#
using InputSwitcher;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class SampleInputController : MonoBehaviour{
    [SerializeField] private Hoge hoge;
    [SerializeField] private Foo foo;
    private void Start(){
        this.OnKeyDownAsObservable(KeyCode.H)
            .Subscribe(_ => {
                Debug.Log("switch hoge");
                InputSw.Switch(hoge); //Hを押したらhogeのインプットしか受け取らない
            });

        this.OnKeyDownAsObservable(KeyCode.F)
            .Subscribe(_ => {
                Debug.Log("switch foo");
                InputSw.Switch(foo); //Fを押したらfooのインプットしか受け取らない
            });
    }
}
```


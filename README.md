# InputSwitcher

# 必要なもの
[UniRx](https://github.com/neuecc/unirx)

[InputAsObservable](https://github.com/euglenach/InputAsObservable)

# 使い方

## Input元に IInputReceiverインターフェース を実装する

```C#
using UnityEngine;
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

## 分岐方法を決定する

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

![screenshot 1559356854](https://user-images.githubusercontent.com/28961922/74109866-aca20e00-4bca-11ea-8e92-eccdd09d8d73.png)


# リファレンス

## IInputReceiver

インプットを流すクラスに実装するインターフェース

```C#
public class Hoge : MonoBehaviour,IInputReceiver{

}
```

## Switch

インプットを通すキーになるインスタンスを切り替える

```C#
InputSw.Switch(hoge);
```

## Inputを流す

InputSwのインプット系のメソッドにIInputReceiverインスタンスを渡す

```C#
InputSw.GetKey(this, KeyCode.C)
        .Subscribe(_ => {Debug.Log("Hoge");});
```

## Current

現在のキーインスタンスを取得する

```C#
InputSw.Current;
```

## IsCurrent

今のキーインスタンスが引数と一致するか

```C#
InputSw.IsCurrent(hoge)
```

## IsActive

InputSwがアクティブかどうかを取得する

IsActiveプロパティがfalseだと、SwitchメソッドとInput系メソッドを通さなくなる
デフォルトはtrue

```C#
InputSw.IsActive;
```

```C#
InputSw.IsActive = !InputSw.IsActive;
```

## Pause

InputSw.IaActiveプロパティを非アクティブにする

```C#
InputSw.Pause();
```

## Resume

InputSw.IaActiveプロパティをアクティブにする

```C#
InputSw.Resume();
```

## IsLogWrite

ログを出力するかのプロパティ
デフォルトはtrue

```C#
InputSw.IsLogWrite = false;
```

using System;
using InputAsRx;
using UnityEngine;
using UniRx;

namespace InputSwitcher{
    public  static class InputSw{
        public static IInputReceiver Current{get; private set;}
        private static bool isActive = true;
        public static bool IsActive{
            get => isActive;
            set => isActive = value;
        }
        public static bool IsLogWrite{get;set;} = true;

        public static IObservable<Unit> GetKey(IInputReceiver receiver, KeyCode key){
            return InputAsObservable.GetKey(key).InputWhere(receiver);
        }

        public static IObservable<Unit> GetKeyDown(IInputReceiver receiver, KeyCode key) =>
            InputAsObservable.GetKeyDown(key).InputWhere(receiver);

        public static IObservable<Unit> GetKeyUp(IInputReceiver receiver, KeyCode key) =>
            InputAsObservable.GetKeyUp(key).InputWhere(receiver);
        
        public static IObservable<Unit> AnyKey(IInputReceiver receiver) =>
            InputAsObservable.AnyKey.InputWhere(receiver);

        public static IObservable<Unit> AnyKeyDown(IInputReceiver receiver) =>
            InputAsObservable.AnyKeyDown.InputWhere(receiver);
        
        public static IObservable<float> Axis(IInputReceiver receiver, string axisName) =>
             InputAsObservable.Axis(axisName).InputWhere(receiver);

        public static IObservable<float> AxisRaw(IInputReceiver receiver, string axisName) =>
             InputAsObservable.AxisRaw(axisName).InputWhere(receiver);
        
        public static IObservable<Unit> GetMouseButton(IInputReceiver receiver, int button) =>
            InputAsObservable.GetMouseButton(button).InputWhere(receiver);
        
        public static IObservable<Unit> GetMouseButtonDown(IInputReceiver receiver, int button) =>
            InputAsObservable.GetMouseButtonDown(button).InputWhere(receiver);
        
        public static IObservable<Unit> GetMouseButtonUp(IInputReceiver receiver, int button) =>
            InputAsObservable.GetMouseButtonUp(button).InputWhere(receiver);
        
        public static IObservable<Unit> GetButton(IInputReceiver receiver, string buttonName) =>
            InputAsObservable.GetButton(buttonName).InputWhere(receiver);
        
        public static IObservable<Unit> GetButtonDown(IInputReceiver receiver, string buttonName) =>
            InputAsObservable.GetButtonDown(buttonName).InputWhere(receiver);
        
        public static IObservable<Unit> GetButtonUp(IInputReceiver receiver, string buttonName) =>
            InputAsObservable.GetButtonUp(buttonName).InputWhere(receiver);
        
        public static IObservable<Unit> Get(IInputReceiver receiver,IObservable<Unit> source){
            return source.InputWhere(receiver);
        }

        public static IObservable<float> Axis(IInputReceiver receiver, IObservable<float> source){
            return source.InputWhere(receiver);
        }
        private static IObservable<T> InputWhere<T>(this IObservable<T> source,IInputReceiver receiver){
            if(!isActive){
                Warn("InputSw is Paused Now.");
            }
            return source.Where(_ => receiver == Current && isActive);
        }

        public static bool Switch(IInputReceiver receiver){
            if(!isActive){
                Warn("InputSw isn't Active.");
            } else{
                Current = receiver;
                Log("switched current receiver as." + receiver);
            }

            return isActive;
        }

        public static bool IsCurrent(IInputReceiver receiver) =>
            Current == receiver;

        
        public static void Pause(){
            Log("InputSw has been Paused.");
            isActive = false;
        }

        public static void Resume(){
            Log("InputSw has been Resumed.");
            isActive = true;
        }

        
        private static void Log(object message){
            if (!IsLogWrite) return;
            Debug.Log(message);
        }

        private static void Warn(object message){
            if (!IsLogWrite) return;
            Debug.LogWarning(message);
        }

        private static void Error(object message){
            if (!IsLogWrite) return;
            Debug.LogError(message);
        }
    }

    public interface IInputReceiver{}
}

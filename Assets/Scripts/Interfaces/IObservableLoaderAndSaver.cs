using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveAndLoadModule
{
    public interface ISaverObserver : IObserver 
    {
        void NotifyAboutSave();
    }
    public interface ILoaderObserver : IObserver
    {
        void NotifyAboutLoad();
    }

    public interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
    }
    public interface IObservableLoaderAndSaver : IObservable { }   
}



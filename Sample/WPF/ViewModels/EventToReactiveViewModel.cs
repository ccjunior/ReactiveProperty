﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codeplex.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using System.Windows;

namespace WPF.ViewModels
{
    public class EventToReactiveViewModel
    {
        // binding from UI
        public ReactiveProperty<MouseEventArgs> MouseMove { get; private set; }
        public ReactiveProperty<MouseEventArgs> MouseDown { get; private set; }
        public ReactiveProperty<string> CurrentPoint { get; private set; }

        public EventToReactiveViewModel()
        {
            MouseMove = new ReactiveProperty<MouseEventArgs>();
            MouseDown = new ReactiveProperty<MouseEventArgs>();

            CurrentPoint = MouseMove
                .Select(m => m.GetPosition(null))
                .Select(p => string.Format("X:{0} Y:{1}", p.X, p.Y))
                .ToReactiveProperty();

            MouseDown.Subscribe(_ => MessageBox.Show("MouseDown!"));
        }
    }
}
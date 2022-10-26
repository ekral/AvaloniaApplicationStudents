using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaApplicationStudents.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string? propertyName = null)
        {
            ArgumentNullException.ThrowIfNull(propertyName);

            if (EqualityComparer<T>.Default.Equals(field, newValue)) return false;

            field = newValue;

            OnPropertyChanged(propertyName);

            return true;
        }

        public bool SetProperty<TModel, T>(T oldValue, T newValue, TModel model, Action<TModel, T> action, [CallerMemberName] string? propertyName = null)
        {
            ArgumentNullException.ThrowIfNull(propertyName);
            ArgumentNullException.ThrowIfNull(model);

            if (EqualityComparer<T>.Default.Equals(oldValue, newValue)) return false;
            
            OnPropertyChanged(propertyName);
            
            action(model, newValue);

            return true;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaApplicationStudents.Services;
using AvaloniaApplicationStudents.ViewModels;
using AvaloniaApplicationStudents.Views;

namespace AvaloniaApplicationStudents
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            StudentService studentService = new StudentService();
            StudentsListViewModel studentsListViewModel = new StudentsListViewModel(studentService);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new StudentsWindow() { DataContext = studentsListViewModel };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}

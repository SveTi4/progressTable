using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using Avalonia.Media;
using Avalonia.X11;
using progressTable.Models;
using ReactiveUI;

namespace progressTable.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Student[] students;

        private string status = "";
        
        private ushort index = 9999;
        
        private string newStudentName = "1";
        private ushort[] newStudentRating = { 0, 0, 0 };

        private float[] average_rating = { 0, 0, 0, 0 };
        
        public MainWindowViewModel()
        {
            Students = new Student[]
            {
                new Student{Name="person 1", Visual=0, Architecture=0, Networks=0},
            };
            AddStudent = ReactiveCommand.Create(() =>
            {
                if (newStudentName.Length > 0)
                {
                    Student[] temp = students;
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = new Student { Name = newStudentName, Visual = newStudentRating[0], Architecture = newStudentRating[1], Networks = newStudentRating[2] };
                    Students = temp;
                    restoreNewStudentData();
                    calcAverage(students);
                }
            });
            DeleteStudent = ReactiveCommand.Create(() =>
            {
                if (Index < students.Length)
                {
                    Student[] temp = students;
                    for (int i = index; i < temp.Length - 1; i++)
                    {
                        temp[i] = temp[i + 1];
                    }
                    Array.Resize(ref temp, temp.Length - 1);
                    Students = temp;
                    Index = 9999;
                    calcAverage(students);
                }
            });
            SaveData = ReactiveCommand.Create(() =>
            {
                Serialization<Student[]>.SaveData(students, "data.dat");
            });
            LoadData = ReactiveCommand.Create(() =>
            {
                Students = Serialization<Student[]>.LoadData("data.dat");
                Index = (ushort)Students.Length;
                calcAverage(students);
            });
        }
        public ReactiveCommand<Unit, Unit> AddStudent { get; }
        public ReactiveCommand<Unit, Unit> DeleteStudent { get; }
        public ReactiveCommand<Unit, Unit> SaveData { get; }
        public ReactiveCommand<Unit, Unit> LoadData { get; }


        private void restoreNewStudentData()
        {
            NewStudentName = "";
            VisualRating = 0;
            ArchitectureRating = 0;
            NetworksRating = 0;
            AverageStudentRating = 0;
        }

        private void restoreAverageRating()
        {
            for (int i = 0; i < average_rating.Length; i++)
            {
                average_rating[i] = 0;
            }
        }

        private void calcAverage(Student[] students)
        {
            restoreAverageRating();
            
            for (int i = 0; i < students.Length; i++)
            {
                VisualRating += students[i].Visual;
                ArchitectureRating += students[i].Architecture;
                NetworksRating += students[i].Networks;
                AverageStudentRating += students[i].Average_Rating;
            }
            VisualRating /= students.Length;
            ArchitectureRating /= students.Length;
            NetworksRating /= students.Length;
            AverageStudentRating /= students.Length;
        }

        public Student[] Students { get => students; set => this.RaiseAndSetIfChanged(ref students, value); }
        public ushort Index{ get => index; set => this.RaiseAndSetIfChanged(ref index, value); }
        public string Status { get => status; set => this.RaiseAndSetIfChanged(ref status, value); }
        public float VisualRating { get => average_rating[0]; set => this.RaiseAndSetIfChanged(ref average_rating[0], value); }
        public float ArchitectureRating { get => average_rating[1]; set => this.RaiseAndSetIfChanged(ref average_rating[1], value); }
        public float NetworksRating { get => average_rating[2]; set => this.RaiseAndSetIfChanged(ref average_rating[2], value); }
        public float AverageStudentRating { get => average_rating[3]; set => this.RaiseAndSetIfChanged(ref average_rating[3], value); }
        
        public string NewStudentName { get => newStudentName; set => this.RaiseAndSetIfChanged(ref newStudentName, value); }
        public ushort NewVisualRating { get => newStudentRating[0]; set => this.RaiseAndSetIfChanged(ref newStudentRating[0], value); }
        public ushort NewArchitectureRating { get => newStudentRating[1]; set => this.RaiseAndSetIfChanged(ref newStudentRating[1], value); }
        public ushort NewNetworksRating { get => newStudentRating[2]; set => this.RaiseAndSetIfChanged(ref newStudentRating[2], value); }

    }
}



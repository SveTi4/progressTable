﻿using System;
using System.Linq;
using System.Reactive;
using Avalonia.X11;
using progressTable.Models;
using ReactiveUI;

namespace progressTable.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Student[] students;

        private string status = "st";
        
        private ushort index = 5000;
        
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
                    Status = newStudentName;
                    Student[] temp = students;
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = new Student { Name = newStudentName, Visual = newStudentRating[0], Architecture = newStudentRating[1], Networks = newStudentRating[2] };
                    Students = temp;
                    restoreNewStudentData();
                    // calcAverage();
                }
            });
        }

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

        // private void calcAverage(Student[] students)
        // {
        //     
        //     for (int i = 0; i < students.Length; i++)
        //     {
        //         ScoreVisualSr += students[i].Visual;
        //         ScoreArchitectureSr += students[i].Architecture;
        //         ScoreNetworksSr += students[i].Networks;
        //         ScoreCalculate_MathSr += students[i].Calculate_Math;
        //         ScorePISr += students[i].PI;
        //         ScoreMathSr += students[i].Math;
        //         ScoreElectricSr += students[i].Electric;
        //         ScoreAverageSr += students[i].Average_Score;
        //     }
        //     ScoreVisualSr /= students.Length;
        //     ColorVisualSr = checkColor(ScoreVisualSr);
        //     ScoreArchitectureSr /= students.Length;
        //     ColorArchitectureSr = checkColor(ScoreArchitectureSr);
        //     ScoreNetworksSr /= students.Length;
        //     ColorNetworksSr = checkColor(ScoreNetworksSr);
        //     ScoreCalculate_MathSr /= students.Length;
        //     ColorCalculate_MathSr = checkColor(ScoreCalculate_MathSr);
        //     ScorePISr /= students.Length;
        //     ColorPISr = checkColor(ScorePISr);
        //     ScoreMathSr /= students.Length;
        //     ColorMathSr = checkColor(ScoreMathSr);
        //     ScoreElectricSr /= students.Length;
        //     ColorElectricSr = checkColor(ScoreElectricSr);
        //     ScoreAverageSr /= students.Length;
        //     ColorAverageSr = checkColor(ScoreAverageSr);
        // }
        //
        public ReactiveCommand<Unit, Unit> AddStudent { get; }
        
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



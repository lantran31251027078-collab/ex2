using System;

public class Student
{
    private string name;
    private double score;
    private static int totalStudents = 0;

    public Student(string name, double score)
    {
        this.name = name;
        this.score = score;
        totalStudents++;
    }

    // TODO: write instance methods here
    public string GetName()
    {
        return name;
    }

    public double GetScore()
    {
        return score;
    }
    public bool IsPassed()
    {
        return score >= 5.0;
    }
    public string GetClassification()
    {
        if (score >= 8.0)
            return "Excellent";
        else if (score >= 6.5)
            return "Good";
        else if (score >= 5.0)
            return "Average";
        else
            return "Weak";
    }

    // TODO: write static methods here
    public static int GetTotalStudents()
    {
        return totalStudents;
    }

    public static Student FindTopStudent(Student[] students)
    {
        Student top = students[0];

        foreach (Student student in students)
        {
            if (student.score > top.score)
                top = student;
        }

        return top;
    }

    public static double CalculateAverageScore(Student[] students)
    {
        double total = 0;

        foreach (Student student in students)
        {
            total += student.score;
        }

        return total / students.Length;
    }
}
}


class Program
{
    static void Main(string[] args)
    {
        // TODO: create array of Student objects
        Student[] students =
        {
            new Student("An", 8.5),
            new Student("Binh", 6.5),
            new Student("Chi", 4.5),
            new Student("Dung", 7.0),
            new Student("Em", 9.0)
        };

        // TODO: call static and instance methods as required
        Console.WriteLine("Total students: " + Student.GetTotalStudents());

        foreach (Student student in students)
        {
            Console.WriteLine(
                student.GetName() + " - " +
                student.GetScore() + " - " +
                student.GetClassification() + " - " +
                (student.IsPassed() ? "Passed" : "Failed")
            );
        }

        Student top = Student.FindTopStudent(students);

        Console.WriteLine("Top student: " + top.GetName());

        Console.WriteLine(
            "Average score: " +
            Student.CalculateAverageScore(students)
        );
    }
}

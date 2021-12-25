using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Models
{
    public class Group
    {
        public const int LIMIT = 21;
        private string _groupName;
        private List<Student> students = new List<Student>();

        public Group(string groupName)
        {
            if (!CheckName(groupName))
            {
                throw new IsuException("Incorrect format group name");
            }

            _groupName = groupName;
        }

        public CourseNumber CourseNumber { get; set; }

        public string Name => _groupName;
        public List<Student> Students => students;

        public uint GetCourseNumber()
        {
            return (uint)char.GetNumericValue(_groupName[2]);
        }

        public void AddStudent(Student student)
        {
            if (students.Count >= LIMIT)
                throw new IsuException("Too many people in the group");
            students.Add(student);
        }

        public Student GetStudent(int id)
        {
            foreach (Student item in students)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }

        public Student FindStudent(string name)
        {
            foreach (Student item in students)
            {
                if (item.Name == name)
                    return item;
            }

            return null;
        }

        private bool CheckName(string name)
        {
            if (name.Length != 5)
                return false;
            if (!name.StartsWith("M3"))
                return false;
            if (char.IsDigit(name[2]) && char.IsDigit(name[3]) && char.IsDigit(name[4]))
                return true;
            else
                return false;
        }
    }
}
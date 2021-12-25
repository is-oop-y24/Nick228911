using System.Collections.Generic;
using Isu.Models;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Group> isuGroupList = new List<Group>();
        private List<CourseNumber> courseNumbers = new List<CourseNumber>();

        public Group AddGroup(string name)
        {
            var group = new Group(name);
            uint courseNumber = group.GetCourseNumber();
            CourseNumber course = FindCourseNumber(courseNumber);
            if (course == null)
            {
                course = new CourseNumber(courseNumber);
                courseNumbers.Add(course);
            }

            group.CourseNumber = course;

            isuGroupList.Add(group);
            return group;
        }

        public CourseNumber FindCourseNumber(uint course)
        {
            foreach (CourseNumber item in courseNumbers)
            {
                if (item.Value == course)
                    return item;
            }

            return null;
        }

        public Student AddStudent(Group group, string name)
        {
            var student = new Student(group, name);
            group.AddStudent(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            foreach (Group group in isuGroupList)
            {
                Student student = group.GetStudent(id);
                if (student != null)
                    return student;
            }

            return null;
        }

        public Student FindStudent(string name)
        {
            foreach (Group group in isuGroupList)
            {
                Student student = group.FindStudent(name);
                if (student != null)
                    return student;
            }

            return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            foreach (var item in isuGroupList)
            {
                if (item.Name == groupName)
                {
                    return item.Students;
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var students = new List<Student>();

            foreach (Group item in isuGroupList)
            {
                if (item.CourseNumber.Value == courseNumber.Value)
                    students.AddRange(item.Students);
            }

            return students;
        }

        public Group FindGroup(string groupName)
        {
            foreach (Group group in isuGroupList)
            {
                if (group.Name == groupName)
                    return group;
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groups = new List<Group>();
            foreach (Group group in isuGroupList)
            {
                if (group.CourseNumber.Value == courseNumber.Value)
                    groups.Add(group);
            }

            return groups;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            student.GroupName.Students.Remove(student);
            newGroup.AddStudent(student);
            student.GroupName = newGroup;
        }
    }
}
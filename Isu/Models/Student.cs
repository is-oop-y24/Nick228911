namespace Isu.Models
{
    public class Student
    {
        private static int currentId = 0;

        public Student(Group group, string name)
        {
            GroupName = group;
            Name = name;
            ++currentId;
            Id = currentId;
        }

        public Group GroupName { get; set; }
        public string Name { get; }
        public int Id { get; }
    }
}
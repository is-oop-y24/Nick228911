using Isu.Models;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            _isuService = new IsuService();
            Group group = _isuService.AddGroup("M3245");
            Student student = _isuService.AddStudent(group, "Ivan");

            Assert.IsNotNull(student.GroupName);
            Assert.AreEqual(group.Students.Count, 1);
            CollectionAssert.Contains(group.Students, student);
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            _isuService = new IsuService();
            Group group = _isuService.AddGroup("M3245");

            Assert.Catch<IsuException>(() =>
            {
                for (int i = 0; i < Group.LIMIT + 1; i++)
                {
                    _isuService.AddStudent(group, "tytr" + i);
                }
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            _isuService = new IsuService();
            Assert.Catch<IsuException>(() =>
            {
                _isuService.AddGroup("M6245");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            _isuService = new IsuService();
            Group group1 = _isuService.AddGroup("M3211");
            Student student = _isuService.AddStudent(group1, "Ivan");
            Group group2 = _isuService.AddGroup("M3277");

            _isuService.ChangeStudentGroup(student, group2);

            Assert.AreEqual(student.GroupName, group2);
            CollectionAssert.Contains(group2.Students, student);
            CollectionAssert.DoesNotContain(group1.Students, student);
        }
    }
}
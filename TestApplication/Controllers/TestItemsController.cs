using TestApplication.Models;
using TestApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.Controllers
{
    public class TestItemsController : ApiController
    {
        private TestApplicationDbContext dbContext = new TestApplicationDbContext();

        [Route("api/TestItems/All")]
        public IEnumerable<TestItem> GetAllTestItems()
        {
            var _testItem = new TestItem()
            {
                State = States.Not_Running,
                Action = "POST",
                Name = "Test",
                Code = 1,
                Retry =  0,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };

            var _testSubItem = new List<TestSubItem>()
            {
                new TestSubItem() {Name = "Test", Code = 1, SubName = "SubTest1"},
                new TestSubItem() {Name = "Test", Code = 2, SubName = "SubTest2"},
                new TestSubItem() {Name = "Test", Code = 2, SubName = "SubTest3"},
            };

            _testItem.TestSubItems = _testSubItem;

            dbContext.TestItems.Add(_testItem);
            dbContext.SaveChanges();

            var testItem = dbContext.TestItems.Where(x => x.State != States.Completed).ToArray();
            return testItem;
        }

        [Route("api/TestItems/First")]
        public TestItem GetTestItemFirst()
        {
            var testItem = dbContext.TestItems.Where(x => x.State == States.Not_Running && x.Retry < 3).OrderBy(x => x.Id).FirstOrDefault();
            if(testItem != null)
            {
                testItem.State = States.Running;
                testItem.UpdateAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            return testItem;
        }

        [Route("api/TestItems/Delete/{TestItemId}")]
        public TestItem GetTestItemDelete(long TestItemId)
        {
            var testItem = dbContext.TestItems.FirstOrDefault(x => x.Id == TestItemId && x.State == States.Running);
            if (testItem != null)
            {
                testItem.State = States.Completed;
                testItem.UpdateAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            return testItem;
        }

        [Route("api/TestItems/Put/{TestItemId}")]
        public TestItem GetTestItemPut(long TestItemId)
        {
            var testItem = dbContext.TestItems.FirstOrDefault(x => x.Id == TestItemId && x.State == States.Running);
            if (testItem != null)
            {
                testItem.State = States.Not_Running;
                testItem.Retry = testItem.Retry + 1;
                testItem.UpdateAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            return testItem;
        }


        public void PostTestItem()
        {

        }

    }
}

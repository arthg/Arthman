using Arthman.Models;
using NUnit.Framework;

namespace Arthman.Tests.Integration.MongoDb
{
    [TestFixture]
    public class NotesRepository : AbstractFixtureWithDatabase
    {
        [Test]
        public void Should_()
        {
            var collection = ArthmanContext.Database.GetCollection<Note>("notes");
            collection.InsertOne(new Note());
        }

    }
}

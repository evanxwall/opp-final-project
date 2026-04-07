using oopFinalProjecy;

namespace TestBooksMethods
{
    [TestClass]
    public sealed class BooksTests
    {
        [TestMethod]
        public void TestBorrowMethod()
        {
            // Test 1: Borrow() Method

            // Arrange
            Books testBook = new Books("Test Title", "Test Author");
            User testUser = new Student("Guy", "Student");
            

            // Act
            testBook.Borrow(testUser);
            // testBook.IsAvailable = true; - will cause test to fail

            // Assert
            Assert.IsFalse(testBook.IsAvailable);
            Assert.IsTrue(testUser.MyBooks.Contains(testBook));


        }

        [TestMethod]
        public void TestReturnMethod()
        {
            // Test 2: Return() Method

            // Arrange
            Books testBook = new Books("Test Title", "Test Author");
            User testUser = new Student("Guy", "Student");

            testBook.Borrow(testUser);

            // Act
            testBook.Return(testUser);

            // Assert
            Assert.IsTrue(testBook.IsAvailable);
            Assert.IsFalse(testUser.MyBooks.Contains(testBook));
        }

        [TestMethod]
        public void TestOverloadedOperators()
        {
            // Test 3: == and != overloaded operators

            // Arrange 
            Books testBook1 = new Books("Title1", "Author1");
            Books testBook2 = new Books("Title1", "Author1");

            // Act/Assert
            Assert.IsTrue(testBook1 == testBook2);
            Assert.IsFalse(testBook1 != testBook2);

        }
    }
}

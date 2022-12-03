namespace Book.Tests
{
    using System;
    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void ValidateCtorAndProp() 
        {
            Book book = new Book("Borba", "Hristo Botev");
            Assert.IsNotNull(book);

            Assert.Throws<ArgumentException>(() => new Book("Borba", null));
            Assert.Throws<ArgumentException>(() => new Book("Borba", ""));

            Assert.Throws<ArgumentException>(() => new Book(null, "Hristo Botev"));
            Assert.Throws<ArgumentException>(() => new Book("", "Hristo Botev"));

        }
        [Test]
        public void ValidateMethotAddFootnote() 
        {
            Book book = new Book("Borba", "Hristo Botev");
            book.AddFootnote(2, "foot...");

            Assert.AreEqual(1, book.FootnoteCount);

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(2, ".."));
        }
        [Test]
        public void ValidateMethotFindFootnote() 
        {
            Book book = new Book("Borba", "Hristo Botev");
            book.AddFootnote(2, "foot...");

            Assert.AreEqual("Footnote #2: foot...", book.FindFootnote(2));

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(1));
        }
        [Test]
        public void ValidateMethotAlterFootnote() 
        {
            Book book = new Book("Borba", "Hristo Botev");
            book.AddFootnote(2, "foot...");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(1, "..."));

            book.AlterFootnote(2, "New Test");
            Assert.AreEqual("Footnote #2: New Test", book.FindFootnote(2));
        }
    }
}
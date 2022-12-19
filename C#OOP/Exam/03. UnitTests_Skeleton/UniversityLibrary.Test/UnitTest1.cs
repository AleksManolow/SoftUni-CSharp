namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    using System.Text;

    public class Tests
    {
        [Test]
        public void ValidateTextBookCtorAndProp()
        {
            TextBook textBook = new TextBook("Borba", "Hristo Botev", "Stihotworenie");
            Assert.IsNotNull(textBook);
            Assert.AreEqual("Borba", textBook.Title);
            Assert.AreEqual("Hristo Botev", textBook.Author);
            Assert.AreEqual("Stihotworenie", textBook.Category);
            Assert.AreEqual(0, textBook.InventoryNumber);
            Assert.IsNull(textBook.Holder);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Book: Borba - 0");
            sb.AppendLine($"Category: Stihotworenie");
            sb.AppendLine($"Author: Hristo Botev");

            Assert.AreEqual(sb.ToString().TrimEnd(), textBook.ToString());
        }
        [Test]
        public void ValidateUniversityLibraryCtorAndProp() 
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            Assert.IsNotNull(universityLibrary);
            Assert.IsNotNull(universityLibrary.Catalogue);
            Assert.AreEqual(0, universityLibrary.Catalogue.Count);

            var type = typeof(UniversityLibrary);
            PropertyInfo propertyInfo = type.GetProperty("Catalogue");
            Assert.That(propertyInfo.CanWrite == false);

            List<TextBook> textBooks= new List<TextBook>();
            TextBook textBook1 = new TextBook("Borba", "Hristo Botev", "Stihotworenie");
            TextBook textBook2 = new TextBook("Pod Igoto", "Ivan Vazov", "Razkazi");
            textBooks.Add(textBook1);
            textBooks.Add(textBook2);

            universityLibrary.AddTextBookToLibrary(textBook1);
            universityLibrary.AddTextBookToLibrary(textBook2);

            for (int i = 0; i < textBooks.Count; i++)
            {
                Assert.AreEqual(textBooks[i], universityLibrary.Catalogue[i]);
            }

            Assert.AreEqual(textBooks, universityLibrary.Catalogue);
        }
        [Test]
        public void ValidateMethodAddTextBookToLibrary()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook textBook = new TextBook("Borba", "Hristo Botev", "Stihotworenie");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Book: Borba - 1");
            sb.AppendLine($"Category: Stihotworenie");
            sb.AppendLine($"Author: Hristo Botev");

            Assert.AreEqual(0, textBook.InventoryNumber);
            Assert.AreEqual(sb.ToString().TrimEnd(), universityLibrary.AddTextBookToLibrary(textBook));

            Assert.AreEqual(1, textBook.InventoryNumber);

            Assert.AreEqual(1, universityLibrary.Catalogue.Count);

            StringBuilder sb2 = new StringBuilder();
            sb2.AppendLine($"Book: Pod Igoto - 2");
            sb2.AppendLine($"Category: Razkazi");
            sb2.AppendLine($"Author: Ivan Vazov");
            Assert.AreEqual(sb2.ToString().TrimEnd(), universityLibrary.AddTextBookToLibrary(new TextBook("Pod Igoto", "Ivan Vazov", "Razkazi")));

            Assert.AreEqual(2, universityLibrary.Catalogue.Count);
        }
        [Test]
        public void ValidateMethodLoanTextBook()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook textBook = new TextBook("Borba", "Hristo Botev", "Stihotworenie");
            universityLibrary.AddTextBookToLibrary(textBook);

            Assert.AreEqual("Borba loaned to Gosho.", universityLibrary.LoanTextBook(1, "Gosho"));
            Assert.AreEqual("Gosho", textBook.Holder);
            Assert.AreEqual("Gosho still hasn't returned Borba!", universityLibrary.LoanTextBook(1, "Gosho"));

            Assert.Throws<NullReferenceException>(() => universityLibrary.LoanTextBook(5, "Pesho"));
        }
        [Test]
        public void ValidateMethodReturnTextBook()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook textBook = new TextBook("Borba", "Hristo Botev", "Stihotworenie");
            universityLibrary.AddTextBookToLibrary(textBook);

            Assert.AreEqual("Borba is returned to the library.", universityLibrary.ReturnTextBook(1));
            Assert.AreEqual(string.Empty, textBook.Holder);
            Assert.Throws<NullReferenceException>(() => universityLibrary.ReturnTextBook(5));
        }
    }
}
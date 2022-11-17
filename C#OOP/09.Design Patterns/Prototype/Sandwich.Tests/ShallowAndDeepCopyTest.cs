using NUnit.Framework;
namespace Sandwich.Tests
{
    public class Tests
    {
        [Test]
        public void when_make_shollew_copy_and_remember_value_changes_in_object_copy()
        {
            Sandwich fstSandwich = new Sandwich(
                "Wheat",
                "Bacon",
                "Lettuse",
                "Tomato",
                15);

            Sandwich shallowCopy = fstSandwich.ShallowCopy();

            shallowCopy.Weight.Gr = 20;

            Assert.AreEqual(fstSandwich.Weight.Gr, 20);
            Assert.AreEqual(shallowCopy.Weight.Gr, 20);
        }
        [Test]
        public void when_make_deep_copy_and_remember_value_no_changes_in_object_copy()
        {
            Sandwich fstSandwich = new Sandwich(
                "Wheat",
                "Bacon",
                "Lettuse",
                "Tomato",
                15);

            Sandwich deepCopy = fstSandwich.DeepCopy();

            deepCopy.Weight.Gr = 35;

            Assert.AreEqual(fstSandwich.Weight.Gr, 15);
            Assert.AreEqual(deepCopy.Weight.Gr, 35);
        }
    }
}
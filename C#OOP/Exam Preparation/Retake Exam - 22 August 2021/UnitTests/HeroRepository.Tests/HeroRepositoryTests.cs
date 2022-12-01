using NUnit.Framework;
using System;
using System.Reflection;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void ValidateCtor()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.IsNotNull(heroRepository);
    }
    [Test]
    public void ValidateMethotAdd()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 2);

        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));

        heroRepository.Create(hero);
        Assert.AreEqual(1, heroRepository.Heroes.Count);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }
    [Test]
    public void ValidateMethotRemove()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 2);


        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(" "));

        heroRepository.Create(hero);

        Assert.IsTrue(heroRepository.Remove("Gosho"));
        Assert.IsFalse(heroRepository.Remove("Gero"));
    }
    [Test]
    public void ValidateMethotGetHeroWithHighestLevel() 
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero1 = new Hero("Gosho", 2);
        Hero hero2 = new Hero("Pesho", 3);
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        Assert.AreEqual(hero2, heroRepository.GetHeroWithHighestLevel());
    }
    [Test]
    public void ValidateMethotGetHero()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero1 = new Hero("Gosho", 2);
        Hero hero2 = new Hero("Pesho", 3);
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        Assert.AreEqual(hero2, heroRepository.GetHero("Pesho"));
    }
    [Test]
    public void HeroesPropertyShouldBeReadOnly()
    {
        var type = typeof(HeroRepository);
        PropertyInfo propertyInfo = type.GetProperty("Heroes");

        Assert.That(propertyInfo.CanWrite == false);
    }
}
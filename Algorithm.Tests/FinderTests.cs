using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new Finder(list);

            var result = finder.FindBirthdaySpreadByType(BirthdaySpreadType.Narrowest);

            Assert.Null(result.pOlderPerson);
            Assert.Null(result.pYoungerPerson);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new Finder(list);

            var result = finder.FindBirthdaySpreadByType(BirthdaySpreadType.Narrowest);

            Assert.Null(result.pOlderPerson);
            Assert.Null(result.pYoungerPerson);
        }

        [Fact]
        public void Returns_Closest_Two_Birthdays_Out_Of_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new Finder(list);

            var result = finder.FindBirthdaySpreadByType(BirthdaySpreadType.Narrowest);

            Assert.Same(sue, result.pOlderPerson);
            Assert.Same(greg, result.pYoungerPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_Birthdays_Out_Of_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new Finder(list);

            var result = finder.FindBirthdaySpreadByType(BirthdaySpreadType.Widest);

            Assert.Same(greg, result.pOlderPerson);
            Assert.Same(mike, result.pYoungerPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_Birthdays_Out_Of_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.FindBirthdaySpreadByType(BirthdaySpreadType.Widest);

            Assert.Same(sue, result.pOlderPerson);
            Assert.Same(sarah, result.pYoungerPerson);
        }

        [Fact]
        public void Returns_Closest_Two_Birthdays_Out_Of_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.FindBirthdaySpreadByType(BirthdaySpreadType.Narrowest);

            Assert.Same(sue, result.pOlderPerson);
            Assert.Same(greg, result.pYoungerPerson);
        }

        Person sue = new Person() {strName = "Sue", dtBirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {strName = "Greg", dtBirthDate = new DateTime(1952, 6, 1)};
        Person mike  = new Person() {strName = "Mike", dtBirthDate = new DateTime(1979, 1, 1)};
        Person sarah = new Person() { strName = "Sarah", dtBirthDate = new DateTime(1982, 1, 1)};
    }
}
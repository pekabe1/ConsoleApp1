using NUnit.Framework;
using Moq;
using ConsoleApp1;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        Mock<IBookingRepository> _repository;
        public List<Booking> ExistingBookings { get; private set; }


        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IBookingRepository>();
            ExistingBookings = new List<Booking>();

            ExistingBookings.Add(new Booking
            {
                Id = 2,
                ArrivalDate = new DateTime(2019, 1, 15),
                DepartureDate = new DateTime(2019, 1, 23),
                Reference = "a"
            });


            _repository.Setup(r => r.GetActiveBookings(1)).
                Returns(ExistingBookings.AsQueryable());



        }

        [Test]
        public void OverlappingBookingsExist_GiveList()
        {
            Booking testBooking = new Booking
            {
                ArrivalDate = new DateTime(2019, 1, 16),
                DepartureDate = new DateTime(2019, 1, 24),
                Id = 3,
                Reference = "b"
            };


            var result = BookingHelper.OverlappingBookingsExist(testBooking, _repository.Object);
            Assert.AreEqual("", result);



        }








        private static DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }


    }


}
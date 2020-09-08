using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Room> allRooms = roomRepo.GetAll();

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 1");

            Room singleRoom = roomRepo.GetById(1);

            Console.WriteLine($"{singleRoom.Id} {singleRoom.Name} {singleRoom.MaxOccupancy}");

            Room bathroom = new Room
            {
                Name = "Bathroom",
                MaxOccupancy = 1
            };

            roomRepo.Insert(bathroom);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id}");
            Console.WriteLine("-------------------------------");
            bathroom.Name = "Outhouse";
            bathroom.MaxOccupancy = 1;

            roomRepo.Update(bathroom);
            Room UpdateTest = roomRepo.GetById(bathroom.Id);
            Console.WriteLine($"Updated: {UpdateTest.Id} {UpdateTest.Name} {UpdateTest.MaxOccupancy}");
            Console.WriteLine("-------------------------------");
            roomRepo.Delete(bathroom.Id);

            List<Room> allRooms2 = roomRepo.GetAll();

            foreach (Room room in allRooms2)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }






            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Roommate> allRoommates = roommateRepo.GetAll();

            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate} {roommate.Room}");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Roommate with Id 1");

            Roommate singleRoommate = roommateRepo.GetById(1);

            Console.WriteLine($"{singleRoommate.Id} {singleRoommate.Firstname} {singleRoommate.Lastname} {singleRoommate.RentPortion} {singleRoommate.MovedInDate} {singleRoommate.Room}");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting First Roommate with RoomId 1");
            Roommate singleRoommate2 = roommateRepo.GetByRoom(1);

            Console.WriteLine($"{singleRoommate2.Id} {singleRoommate2.Firstname} {singleRoommate2.Lastname} {singleRoommate2.RentPortion} {singleRoommate2.MovedInDate} {singleRoommate2.Room.Name} {singleRoommate2.Room.MaxOccupancy} {singleRoommate2.Room.MaxOccupancy}");
            Roommate roomy1 = new Roommate
            {
                Firstname = "Matt",
                Lastname = "Patt",
                RentPortion = 40,
                MovedInDate = new DateTime(2020, 09, 15),
                Room = null,
                RoomId = 3
                
            };
            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Roommates with RoomId 3");
            List<Roommate> allRoommatesByRoom = roommateRepo.GetAllWithRoom(3);

            foreach (Roommate roommate in allRoommatesByRoom)
            {
                Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate} {roommate.Room.Name}");
            }

            roommateRepo.Insert(roomy1);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Roommate with id {roomy1.Id}");
            Console.WriteLine("-------------------------------");
            roomy1.Firstname = "Arthur";
            roomy1.RentPortion = 25;

            roommateRepo.Update(roomy1);
            Roommate UpdatedTest = roommateRepo.GetById(roomy1.Id);
            Console.WriteLine($"Updated: {UpdatedTest.Id} {UpdatedTest.Firstname} {UpdatedTest.Lastname} {UpdatedTest.RentPortion} {UpdatedTest.MovedInDate}");
            Console.WriteLine("-------------------------------");
            roomRepo.Delete(roomy1.Id);

            List<Roommate> allRoommates2 = roommateRepo.GetAll();

            foreach (Roommate roommate in allRoommates2)
            {
                Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate} {roommate.RoomId}");
            }
        }
    }
}
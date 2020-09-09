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
           /* RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

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
            }*/






            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);

            int userEntry = 1;
            bool mainWhileCheck = true;

            while (mainWhileCheck != false)
            {

                Console.WriteLine("Welcome to Roommate Manager!");
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("");
                Console.WriteLine("1) Get all Roommates");
                Console.WriteLine("2) Get Roommate by Id/Edit");
                Console.WriteLine("3) Get First Roommate by Room");
                Console.WriteLine("4) Get Roommates by Room");
                Console.WriteLine("5) Add new Rommmate");
               
                Console.WriteLine("6) Delete a Roommate");
                Console.WriteLine("0) Exit");
                Console.WriteLine("");
                userEntry = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                if (userEntry == 0)
                {
                    mainWhileCheck = false;
                    break;
                }else if(userEntry == 1){
                    Console.WriteLine("Getting All Roommates:");
                    Console.WriteLine();

                    List<Roommate> allRoommates = roommateRepo.GetAll();

                    foreach (Roommate roommate in allRoommates)
                    {
                        Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate} {roommate.Room}");
                    }
                    Console.WriteLine("----------------------------");
                }else if(userEntry == 2)
                {
                    int byIdEntry = 1;
                    Console.Write("Type in the id of the roommate you want to find:");
                    byIdEntry = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Getting Roommate with Id {byIdEntry}");

                    Roommate singleRoommate = roommateRepo.GetById(byIdEntry);

                    Console.WriteLine($"{singleRoommate.Id} {singleRoommate.Firstname} {singleRoommate.Lastname} {singleRoommate.RentPortion} {singleRoommate.MovedInDate} {singleRoommate.Room}");
                    Console.WriteLine("----------------------------");

                    string editCheck = "a";
                    bool editWhile = true;
                    Console.WriteLine("");
                    Console.Write("Do you want to Edit this Entry Y/N:");
                    editCheck = Console.ReadLine();
                    Console.WriteLine("");
                    if(editCheck == "y" || editCheck == "Y")
                    {
                        int editSelect = 1;
                        while (editWhile == true)
                        {
                            Console.WriteLine("What do you want to edit:");
                            Console.WriteLine("");
                            Console.WriteLine("1) First Name");
                            Console.WriteLine("2) Last Name");
                            Console.WriteLine("3) Rent Portion");
                            Console.WriteLine("4) Move in Date");
                            Console.WriteLine("5) Assigned Room Id");
                            Console.WriteLine("0) Edit Complete");

                            editSelect = int.Parse(Console.ReadLine());

                            if(editSelect == 0)
                            {
                                editWhile = false;
                              
                            }else if(editSelect == 1)
                            {
                                Console.WriteLine($"The entry's First Name is {singleRoommate.Firstname}. What would you like to change it to?");
                                singleRoommate.Firstname = Console.ReadLine();
                                Console.WriteLine("");
                            }else if (editSelect == 2)
                            {
                                Console.WriteLine($"The entry's Last Name is {singleRoommate.Lastname}. What would you like to change it to?");
                                singleRoommate.Lastname = Console.ReadLine();
                            }else if(editSelect == 3)
                            {
                                Console.WriteLine($"The entry's Rent Portion is {singleRoommate.RentPortion}. What would you like to change it to?");
                                singleRoommate.RentPortion = int.Parse(Console.ReadLine());
                            }else if(editSelect == 4)
                            {
                                Console.WriteLine($"The entry's Move in Day is {singleRoommate.MovedInDate}. What would you like to change it to? (Year, Month, Day)");
                                singleRoommate.MovedInDate= DateTime.Parse(Console.ReadLine());
                            }else if (editSelect == 5)
                            {
                                Console.WriteLine($"The entry's Assigned Room Id is {singleRoommate.RoomId}. What would you like to change it to?");
                                singleRoommate.RoomId = int.Parse(Console.ReadLine());
                            }
                        }
                        roommateRepo.Update(singleRoommate);
                        Roommate UpdatedTest = roommateRepo.GetById(singleRoommate.Id);
                        Console.WriteLine($"Updated: {UpdatedTest.Id} {UpdatedTest.Firstname} {UpdatedTest.Lastname} {UpdatedTest.RentPortion} {UpdatedTest.MovedInDate}");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                   
                }
                else if(userEntry == 3)
                {
                    int byIdEntry = 1;
                    Console.Write("Type in the Roomid of the roommate you want to find:");
                    byIdEntry = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Getting Latest Roommate with RoomId {byIdEntry}");
                    Roommate singleRoommate2 = roommateRepo.GetByRoom(byIdEntry);

                    Console.WriteLine($"{singleRoommate2.Id} {singleRoommate2.Firstname} {singleRoommate2.Lastname} {singleRoommate2.RentPortion} {singleRoommate2.MovedInDate} {singleRoommate2.Room.Name} {singleRoommate2.Room.MaxOccupancy} {singleRoommate2.Room.MaxOccupancy}");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("");
                }
                else if(userEntry == 4)
                {
                    int byIdEntry = 1;
                    Console.Write("Type in the Roomid of the roommates you want to find:");
                    byIdEntry = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Getting Roommates with RoomId {byIdEntry}");
                    List<Roommate> allRoommatesByRoom = roommateRepo.GetAllWithRoom(byIdEntry);

                    foreach (Roommate roommate in allRoommatesByRoom)
                    {
                        Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate} {roommate.Room.Name}");
                    }
                    Console.WriteLine("");
                }
                else if(userEntry == 5)
                {
                    Roommate roomy1 = new Roommate
                    {
                        Firstname = "Matt",
                        Lastname = "Patt",
                        RentPortion = 40,
                        MovedInDate = new DateTime(2020, 09, 15),
                        Room = null,
                        RoomId = 3

                    };
                    Console.WriteLine("");
                    Console.WriteLine("Input information for a new Roommate:");
                    Console.Write("First Name:");
                    roomy1.Firstname = Console.ReadLine();
                    Console.Write("Last Name:");
                    roomy1.Lastname = Console.ReadLine();
                    Console.Write("Rent Portion:");
                    roomy1.RentPortion = int.Parse(Console.ReadLine());
                    Console.Write("Move In Date (Year, Month, Day):");
                    roomy1.MovedInDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Assigned Room Id:");
                    roomy1.RoomId = int.Parse(Console.ReadLine());

                    Console.Write("Press any key to submit the Roommate:");
                    Console.ReadLine();
                    roommateRepo.Insert(roomy1);
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"Added the new Roommate with id {roomy1.Id}");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("");
                }
                else if(userEntry == 6)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Which Roommate would you like to Delete?");
                         List<Roommate> allRoommates = roommateRepo.GetAll();

                    foreach (Roommate roommate in allRoommates)
                    {
                        Console.WriteLine($"{roommate.Id}) {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate}");
                    }
                    roommateRepo.Delete(int.Parse(Console.ReadLine()));

                    List<Roommate> allRoommates2 = roommateRepo.GetAll();

                    foreach (Roommate roommate in allRoommates2)
                    {
                        Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate} {roommate.RoomId}");
                    }
                    Console.WriteLine("");
                }
               

              
               
               
                
              
               

              

               
               

               
                
            }
        }
    }
}
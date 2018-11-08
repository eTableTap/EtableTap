using System;
using Hangfire;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;

namespace TableTap.BackGroundWorker.Classes
{
    public class EmailQueuing
    {

        public static void stopEmail()
        {
            /// stops the EmailNotification hangfire task (01)
            /// 

            RecurringJob.RemoveIfExists("01");
        }

        public static bool startEmailNotificationSystem()
        {
            /// creates hangfire task to send hourly reminder email notifications
            /// returns a true if job starts successfully, a false if there is an error

            stopEmail();

            try
            {

                RecurringJob.AddOrUpdate("01",
                () => startEmailWorker(),
                Cron.Minutely);

                startEmailWorker();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static List<List<string>> testData()
        {
            /// Test data

                        string email1 = "hayden.bartlett1@hotmail.com";
                        string phone = "0434346773";
                        string user = "Hayden Bartlett";
                        string tableid = "001";
                        string roomName = "room1";
                        string buildName = "building1";
                        string date = "09/09/1864";
                        string hour = "9.30";
                        string URL = "www.URL.com";


                        string email2 = "c3185636@uon.edu.au";
                        string phone2 = "0434346773";
                        string user2 = "hayden bartlett2";
                        string tableid2 = "001";
                        string roomName2 = "room1";
                        string buildName2 = "building1";
                        string date2 = "09/09/1864";
                        string hour1 = "9.30";
                        string URL2 = "www.URL.com";

            //for each loop through SQL results 


                        List<string> dataset1 = new List<string>();
                        List<string> dataset2 = new List<string>();


                        dataset1.Add(user);
                        dataset1.Add(phone);
                        dataset1.Add(email1);
                        dataset1.Add(tableid);
                        dataset1.Add(roomName);
                        dataset1.Add(buildName);
                        dataset1.Add(date);
                        dataset1.Add(hour);
                        dataset1.Add(URL);


                        dataset2.Add(user2);
                        dataset2.Add(phone2);
                        dataset2.Add(email2);
                        dataset2.Add(tableid2);
                        dataset2.Add(roomName2);
                        dataset2.Add(buildName2);
                        dataset2.Add(date2);
                        dataset2.Add(hour1);
                        dataset2.Add(URL2);



                        List<List<string>> data = new List<List<string>>();
                        data.Add(dataset1);
                        data.Add(dataset2);

                       return data;
        }


        public static void startEmailWorker()
        {
            List<GroupModel> groups = new List<GroupModel>();

//            List<List<string>> data = new List<List<string>>();

            groups = GroupDAL.loadGroupListattime();


            foreach(GroupModel group in groups)
            {
                List<string> dataset1 = new List<string>();

                string URL = "https://www.etabletap.com/UL/BookingReceipt.aspx?id=" +  group.groupID;

                UserModel user = new UserModel();
                TableModel table = new TableModel();
                RoomModel room = new RoomModel();
                BuildingModel building = new BuildingModel();


                table = TableBL.getTableByID(group.tableID);

                user = UserBL.passUserSearch(group.emailAddress);

                room = RoomBL.getRoomByID(table.RoomID);

                building = BuildingBL.getBuildingByID(room.BuildingID);


                // main user
                NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, user.Email , table.TableID.ToString(),
                    room.RoomName, building.BuildingName, group.gDate.ToString(), group.gHour.ToString() + ":00", URL);

                //group member 1
                try
                { 
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, group.memberEmail1, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, group.gDate.ToString(), group.gHour.ToString() + ":00", URL);
                }
                catch
                {

                }

                // group member 2
                try
                {
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, group.memberEmail2, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, group.gDate.ToString(), group.gHour.ToString() + ":00", URL);
                }
                catch
                {

                }

                // groupmember 3
                try
                {
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, group.memberEmail3, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, group.gDate.ToString(), group.gHour.ToString() + ":00", URL);
                }
                catch
                {

                }

                // group member 4
                try
                {
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, group.memberEmail4, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, group.gDate.ToString(), group.gHour.ToString() + ":00", URL);
                }
                catch
                {

                }

                // groupmember 5
                try
                {
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, group.memberEmail5, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, group.gDate.ToString(), group.gHour.ToString() + ":00", URL);
                }
                catch
                {

                }
            }


  //          return data;
        }



        public static void testemailWorker()
        {
            DateTime time = System.DateTime.Now;

            List<List<string>> bookings = testData();

            foreach(List<string> booking in bookings)
            {
                NotifyBL.startNotifyBooking(booking[0], booking[1], booking[2], booking[3], booking[4], booking[5], booking[6], booking[7], booking[8]);
            }



            

        }




    }
}
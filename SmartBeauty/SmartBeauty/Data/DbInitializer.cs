using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartBeauty.Data;

namespace SmartBeauty.Models
{
    public class DbInitializer
    {
        public static void Initialize(Data.ApplicationDbContext context)
        {
            // context.Database.EnsureCreated();
            if (context.Client.Any())
            {
                return;   // DB has been seeded
            }

            //Seed Client Data
            var clients = new Client[]
            {
                new Client {ClientID ="C027", UserName ="CarsonAlexander", Email ="CarsonAlexander@gmail.com", FirstName = "Carson", LastName ="Alexander", Address ="2019 Main Str, Vancouver, BC", DOB = DateTime.Parse("12/25/1967"), PhoneNumber ="7781230001"},
                new Client {ClientID ="C028", UserName ="MeredithAlonso", Email ="MeredithAlonso@gmail.com", FirstName ="Meredith", LastName ="Alonso", Address ="2333 Silver Ave, Surrey, BC", DOB = DateTime.Parse("3/22/1991"), PhoneNumber ="7781230002"},
                new Client {ClientID ="C029", UserName ="ArturoAnand", Email ="ArturoAnand@gmail.com", FirstName ="Arturo", LastName ="Anand", Address ="2863 Delta Ave, Burnaby, BC", DOB = DateTime.Parse("2/28/2000"), PhoneNumber ="7781230003"},
                new Client {ClientID ="C030", UserName ="GytisBarzdukas", Email ="GytisBarzdukas@gmail.com", FirstName ="Gytis", LastName ="Barzdukas", Address ="3947 Victoria Dr, Vancouver, BC", DOB = DateTime.Parse("11/7/1993"), PhoneNumber ="7781230004"},
                new Client {ClientID ="C031", UserName ="YanLi", Email ="YanLi@gmail.com", FirstName ="Yan", LastName ="Li", Address ="6282 E 27th Ave, Vancouver, BC", DOB = DateTime.Parse("11/14/1995"), PhoneNumber ="7781230005"},

            };

            context.Client.AddRange(clients);
            context.SaveChanges();

            //Seed TimeSpot Data

            var timespots = new TimeSpot[]
            {
                new TimeSpot {TimeSpotID = "001", TimeSpotName = "09 AM - 10 AM"},
                new TimeSpot {TimeSpotID = "002", TimeSpotName = "10 AM - 11 AM"},
                new TimeSpot {TimeSpotID = "003", TimeSpotName = "11 AM - 12 PM"},
                new TimeSpot {TimeSpotID = "004", TimeSpotName = "12 PM - 01 PM"},
                new TimeSpot {TimeSpotID = "005", TimeSpotName = "01 PM - 02 PM"},
                new TimeSpot {TimeSpotID = "006", TimeSpotName = "02 PM - 03 PM"},
                new TimeSpot {TimeSpotID = "007", TimeSpotName = "04 PM - 05 PM"}

            };
            context.TimeSpot.AddRange(timespots);
            context.SaveChanges();
            var services = new Service[]
            {
                new Service {ServiceID ="S017SP10", ServiceName ="Hair cut", Description ="Hair cut", Price = 45},
                new Service {ServiceID ="S017SP11", ServiceName ="Color correction", Description ="Color correction", Price = 70},
                new Service {ServiceID ="S017SP12", ServiceName ="Root touch-up", Description ="Root touch-up", Price = 50},
                new Service {ServiceID ="S017SP13", ServiceName ="Hair curling", Description ="Hair curling", Price = 80},
                new Service {ServiceID ="S017SP14", ServiceName ="Hair dyeing", Description ="Hair dyeing", Price = 100},
                            };
            context.Service.AddRange(services);
            context.SaveChanges();

            //Seed Salon Data

            var salons = new Salon[]
                {
            new Salon { SalonID = "S017", SalonName = "Langara Salon & Nail Spa", UserName = "Salon17", Email = "support@langaranail.ca", Address = "2321 49th street, Vancouver BC", PhoneNumber = "77812311226" },
            new Salon { SalonID = "S018", SalonName = "Naaz Hair and Beauty Salon", UserName = "Salon18", Email = "business@nazz.ca", Address = "2348 Burrard street, Vancouver, BC", PhoneNumber = "71112311226" },
                        };
            context.Salon.AddRange(salons);
            context.SaveChanges();

            //Seed Staff Data

            var staffs = new Staff[]
            {
                new Staff {StaffID ="S017E001", SalonID=salons.Single(s => s.SalonName=="Langara Salon & Nail Spa").SalonID, TimeSpotID=timespots.Single(t=>t.TimeSpotName == "09 AM - 10 AM").TimeSpotID , UserName ="", Email ="", FirstName ="Nick", LastName ="Knight", Rating = "5"},
                new Staff {StaffID ="S017E002", SalonID=salons.Single(s => s.SalonName=="Langara Salon & Nail Spa").SalonID, TimeSpotID=timespots.Single(t=>t.TimeSpotName == "10 AM - 11 AM").TimeSpotID , UserName ="", Email ="", FirstName ="Jane", LastName ="Howard", Rating = "5"},
                new Staff {StaffID ="S017E003", SalonID=salons.Single(s => s.SalonName=="Langara Salon & Nail Spa").SalonID, TimeSpotID=timespots.Single(t=>t.TimeSpotName == "11 AM - 12 PM").TimeSpotID , UserName ="", Email ="", FirstName ="Ashley", LastName ="Stamp", Rating = "5"},
                new Staff {StaffID ="S017E004", SalonID=salons.Single(s => s.SalonName=="Langara Salon & Nail Spa").SalonID, TimeSpotID=timespots.Single(t=>t.TimeSpotName == "12 PM - 01 PM").TimeSpotID , UserName ="", Email ="", FirstName ="Wayne", LastName ="Turner", Rating = "5"},
                new Staff {StaffID ="S018E001", SalonID=salons.Single(s => s.SalonName=="Naaz Hair and Beauty Salon").SalonID, TimeSpotID=timespots.Single(t=>t.TimeSpotName == "09 AM - 10 AM").TimeSpotID , UserName ="", Email ="", FirstName ="Nancy", LastName ="Stinson", Rating = "5"},

                            };
            context.Staff.AddRange(staffs);
            context.SaveChanges();


            //Seed LastAppointment Data
            var lastappointments = new LastAppointment[]
            {
                new LastAppointment {LastAppointmentID="A010", ClientID = clients.Single(c => c.LastName == "Alexander").ClientID, LastAppointmentDate= DateTime.Parse("2/28/2021"), ServiceUsing="Hair dyeing"},
                new LastAppointment {LastAppointmentID="A011", ClientID = clients.Single(c => c.LastName == "Alonso").ClientID ,LastAppointmentDate= DateTime.Parse("2/28/2021"), ServiceUsing="Bang cut"},
                new LastAppointment {LastAppointmentID="A012", ClientID = clients.Single(c => c.LastName == "Li").ClientID ,LastAppointmentDate= DateTime.Parse("2/28/2021"), ServiceUsing="Digital perm"},
            };
            context.LastAppointment.AddRange(lastappointments);
            context.SaveChanges();

            var appointments = new Appointment[]
                {
                new Appointment {AppointmentID=1, ClientID = clients.Single(c => c.LastName == "Alexander").ClientID, SalonID=salons.Single(s => s.SalonName=="Langara Salon & Nail Spa").SalonID, ServiceID = services.Single(v => v.ServiceName =="Hair cut").ServiceID, StaffID = staffs.Single(st => st.LastName == "Knight").StaffID, BookingDate = DateTime.Parse("2/28/2021"), TimeSpotID=timespots.Single(t => t.TimeSpotName == "11 AM - 12 PM").TimeSpotID, ShowUp = "Yes"},
                new Appointment {AppointmentID=2, ClientID = clients.Single(c => c.LastName == "Alonso").ClientID, SalonID=salons.Single(s => s.SalonName=="Langara Salon & Nail Spa").SalonID, ServiceID = services.Single(v => v.ServiceName =="Hair cut").ServiceID, StaffID = staffs.Single(st => st.LastName == "Howard").StaffID, BookingDate = DateTime.Parse("2/28/2021"), TimeSpotID=timespots.Single(t => t.TimeSpotName == "12 PM - 01 PM").TimeSpotID, ShowUp = "Yes"},
                new Appointment {AppointmentID=3, ClientID = clients.Single(c => c.LastName == "Anand").ClientID, SalonID=salons.Single(s => s.SalonName=="Langara Salon & Nail Spa").SalonID, ServiceID = services.Single(v => v.ServiceName =="Hair cut").ServiceID, StaffID = staffs.Single(st => st.LastName == "Stamp").StaffID,BookingDate = DateTime.Parse("2/28/2021"), TimeSpotID=timespots.Single(t => t.TimeSpotName == "10 AM - 11 AM").TimeSpotID, ShowUp = "Yes"},
                new Appointment {AppointmentID=4, ClientID = clients.Single(c => c.LastName == "Barzdukas").ClientID, SalonID=salons.Single(s => s.SalonName=="Langara Salon & Nail Spa").SalonID, ServiceID = services.Single(v => v.ServiceName =="Hair cut").ServiceID,StaffID = staffs.Single(st => st.LastName == "Turner").StaffID, BookingDate = DateTime.Parse("2/28/2021"), TimeSpotID=timespots.Single(t => t.TimeSpotName == "09 AM - 10 AM").TimeSpotID, ShowUp = "Yes"},
                new Appointment {AppointmentID=5, ClientID = clients.Single(c => c.LastName == "Li").ClientID, SalonID=salons.Single(s => s.SalonName=="Langara Salon & Nail Spa").SalonID, ServiceID = services.Single(v => v.ServiceName =="Hair cut").ServiceID, StaffID = staffs.Single(st => st.LastName == "Turner").StaffID,BookingDate = DateTime.Parse("2/28/2021"), TimeSpotID=timespots.Single(t => t.TimeSpotName == "11 AM - 12 PM").TimeSpotID, ShowUp = "Yes"},

                };


            context.Appointment.AddRange(appointments);
            context.SaveChanges();
        }
    }
}

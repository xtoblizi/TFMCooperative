using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public class DropDown
    {
            public enum PaymentStatus
            {
                PaymentVerified = 1, PaymentUnverified
            }
            //public enum Unit
            //{
            //    None = 1, Kg, Litres, Bag, Crate, Basket, Tubbers, Mudu, Cup, Bottle, Tonnnes
            //}

            //public enum Withdrawal
            //{
            //    Processing = 0, Successful = 1, Declined
            //}

            public enum AccountType
            {
                Savings = 1, Current
            }
            public enum BankName
            {
                Access = 1,
                Citibank,
                Diamond,
                DynamicStandard,
                Ecobank,
                Fidelity,
                FirstBank,
                FCMB,
                GTB,
                Heritage,
                Keystone,
                Providus,
                Skye,
                StanbicIBTC,
                StandardChartered,
                Sterling,
                Suntrust,
                Union,
                UBA,
                Unity,
                Wema,
                Zenith,
            }

            public enum BusinessEntry
            {
                Individual = 1, Corporate
            }

            public enum Qualification
            {
                PHD = 1, MASTERS, BSC, HND, OND, NCE, O_LEVEL, Leaving_School

            }
            public enum Gender
            {
                Male, Female
            }
            public enum State
            {
                Abia = 1, Adamawa, AkwaIbom, Anambra, Bauchi, Bayelsa, Benue, Borno, CrossRiver, Delta, Ebonyi, Edo, Ekiti,
                Abuja, Gombe, Imo, Jigawa, Kaduna, Kano, Katsina, Kebbi, Kogi, Kwara, Lagos, Nasarawa, Niger, Ogun, Ondo, Osun,
                Oyo, Plateau, Rivers, Sokoto, Taraba, Yobe, Zamfara
            }

            public enum FileType
            {
                 JPEG, PNG,
            }

            public enum ModeOfIdentification
            {
                National_ID_Card = 1,
                International_Passport,
                Drivers_Lincense,
                Voters_Card,
                Company_Id


            }

            public enum AddressType
            {
                Business_Address = 1,
                Home_Address
            }
        }
    
}
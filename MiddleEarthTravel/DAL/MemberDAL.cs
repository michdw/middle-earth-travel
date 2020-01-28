using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MiddleEarthTravel.Models;
using Dapper;

namespace MiddleEarthTravel.DAL
{
    public class MemberDAL
    {
        readonly string connectionString;
        public MemberDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        readonly string checkForUserName =
            "SELECT UserName FROM [members] WHERE UserName = @userName";
        readonly string getMemberByName =
            "SELECT * FROM [members] WHERE UserName = @userName";
        readonly string registerMember =
            "INSERT INTO [members] (UserName, Password, About, IsAdmin, MemberSince) " +
            "VALUES (@username, @password, @about, @isAdmin, @memberSince)";


        public bool CheckForUserName(string userName)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            List<string> list = db.Query<string>(checkForUserName, new { userName }).ToList();
            return list.Count > 0;
        }

        public Member GetMemberByName(string userName)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            Member member = db.Query<Member>(getMemberByName, new { userName }).ToList().FirstOrDefault();
            return member;
        }

        public void RegisterMember(Member member)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            db.Execute(registerMember, new { member.UserName, password = member.Password, about = member.About, isAdmin = member.IsAdmin, memberSince = member.MemberSince });
        }
    }
}
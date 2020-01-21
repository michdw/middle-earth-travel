using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RangersOfTheNorth.Models;
using Dapper;

namespace RangersOfTheNorth.DAL
{
    public class MemberDAL
    {
        readonly string connectionString;
        public MemberDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        readonly string registerMember =
            "INSERT INTO [members] (MemberName, Password, About, IsAdmin, MemberSince) " +
            "VALUES (@membername, @password, @about, @isAdmin, @memberSince)";
        readonly string getMemberByName =
            "SELECT MemberName FROM [members] WHERE MemberName = @membername";


        public void RegisterMember(Member member)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            db.Execute(registerMember, new { memberName = member.MemberName, password = member.Password, about = member.About, isAdmin = member.IsAdmin, memberSince = member.MemberSince });
        }

        public Member GetMemberByName(string memberName)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            return db.Query<Member>(getMemberByName, new { memberName }) as Member;
        }

        public bool CheckForMemberName(string memberName)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            List<string> list = db.Query<string>(getMemberByName, new { memberName }).ToList();
            return list.Count > 0;

        }


    }
}
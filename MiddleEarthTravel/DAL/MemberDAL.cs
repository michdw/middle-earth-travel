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

        readonly string checkForDisplayName =
            "SELECT DisplayName FROM [members] WHERE DisplayName = @displayName";
        readonly string getMemberByName =
            "SELECT * FROM [members] WHERE DisplayName = @displayName";        
        readonly string getMemberByID =
            "SELECT * FROM [members] WHERE ID = @memberID";
        readonly string registerMember =
            "INSERT INTO [members] (DisplayName, Password, About, IsAdmin, MemberSince) " +
            "VALUES (@displayname, @password, @about, @isAdmin, @memberSince)";
        readonly string getAdminRequests =
            "SELECT * from [members] WHERE isAdmin IS NULL";
        readonly string adminRequest =
            "UPDATE [members] SET isAdmin = NULL WHERE ID = @memberID";
        readonly string adminApprove =
            "UPDATE [members] SET isAdmin = 1 WHERE ID = @memberID";
        readonly string adminDeny =
            "UPDATE [members] SET isAdmin = 0 WHERE ID = @memberID";
        readonly string changeName =
            "UPDATE [members] SET DisplayName = @displayName WHERE ID = @memberID";


        public bool CheckForDisplayName(string displayName)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            List<string> list = db.Query<string>(checkForDisplayName, new { displayName }).ToList();
            return list.Count > 0;
        }

        public List<Member> GetAdminRequests()
        {
            using SqlConnection db = new SqlConnection(connectionString);
            List<Member> requesters = db.Query<Member>(getAdminRequests).ToList();
            return requesters;
        }

        public Member GetMemberByName(string displayName)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            Member member = db.Query<Member>(getMemberByName, new { displayName }).ToList().FirstOrDefault();
            return member;
        }

        public Member GetMemberByID(int memberID)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            Member member = db.Query<Member>(getMemberByID, new { memberID }).ToList().FirstOrDefault();
            return member;
        }

        public void RegisterMember(Member member)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            db.Execute(registerMember, new { member.DisplayName, password = member.Password, about = member.About, isAdmin = member.IsAdmin, memberSince = member.MemberSince });
        }

        public void AdminRequest(int memberID)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            db.Execute(adminRequest, new { memberID });
        }
        public void AdminApprove(int memberID)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            db.Execute(adminApprove, new { memberID });
        }
        public void AdminDeny(int memberID)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            db.Execute(adminDeny, new { memberID });
        }

        public void ChangeName(string displayName, int memberID)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            db.Execute(changeName, new { displayName, memberID });
        }
    }
}
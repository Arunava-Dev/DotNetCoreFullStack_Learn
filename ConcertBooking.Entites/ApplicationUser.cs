using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Identity : membership program that provides -> Authentication-credentials &
//Authorization - accept rights
//Steps->
//Authentication :
//1. Register : IdentityUser Class - Id(Guid) , UserName , Password , Email , Phone
     // SignInManager - check User Signin or not

// UserManager Class : Store user data in database, get user Information from database , add role to user

// 2. IdentityRole :  Id, Name

//Claim : Piece of information about user, adhar card, user Id
//ClaimsIdentity = List<Claim>




namespace ConcertBooking.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? Pincode { get; set; }

    }
}

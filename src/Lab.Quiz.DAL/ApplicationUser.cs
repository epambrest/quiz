using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Lab.Quiz.DAL.Interfaces;

namespace Lab.Quiz.DAL
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
    }
}
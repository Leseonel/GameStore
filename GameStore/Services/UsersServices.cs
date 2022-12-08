﻿using GameStore.Data.Repositories.UserRepository;
using GameStore.Data.UnitOfWork;
using GameStore.Models;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class UsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _usersRepository = _unitOfWork.Users;
        }
    }
}
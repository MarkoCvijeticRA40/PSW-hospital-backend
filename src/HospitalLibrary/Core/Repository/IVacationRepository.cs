﻿using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IVacationRepository
    {
        IEnumerable<Vacation> GetAll();
        Vacation GetById(int id);
        void Create(Vacation vacation);
        void Update(Vacation vacation);
        void Delete(Vacation vacation);
    }
}
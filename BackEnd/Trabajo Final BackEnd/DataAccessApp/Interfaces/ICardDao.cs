﻿using DataAccessApp.Models.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessApp.Interfaces
{
    public interface ICardDao
    {
        Task<IEnumerable<CardModel>> GetAllAsync();
    }
}

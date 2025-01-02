using GameApp.Dtos.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardApp.Interfaces
{
    public interface ICardService
    {
        Task<IEnumerable<CardDto>> GetAllCardsAsync();
    }
}

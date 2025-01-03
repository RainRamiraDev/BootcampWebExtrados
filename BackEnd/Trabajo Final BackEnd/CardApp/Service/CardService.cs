﻿using CardApp.Interfaces;
using DataAccessApp.Interfaces;
using GameApp.Dtos.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardApp.Service
{
    public class CardService : ICardService
    {
        private readonly ICardDao _cardDao;

        public CardService(ICardDao cardDao)
        {
            _cardDao = cardDao;
        }

        public async Task<IEnumerable<CardDto>> GetAllCardsAsync()
        {
            var cards = await _cardDao.GetAllAsync();

            // Mapeo de CardModel a CardDto
            var cardDtos = cards.Select(card => new CardDto
            {
                Id_card = card.Id_card,
                Illustration = card.Illustration,
                Attack = card.Attack,
                Defense = card.Defense
            }).ToList();

            return cardDtos;
        }
    }
}

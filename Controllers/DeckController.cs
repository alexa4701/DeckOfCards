using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeckOfCards.Domain.Models;

namespace DeckOfCards.Controllers
{
    [ApiController]
    [Route("api")]
    public class DeckController : ControllerBase
    {
        private const int MAX_INDEX = 51;
        private static Deck deck = new Deck();
        private static int topIndex = 0;

        [HttpGet]
        public ActionResult<Card> DealOneCard() 
        {
            if (deck == null)
            {
                return BadRequest();
            }

            if (topIndex > MAX_INDEX)
            {
                return NoContent();
            }

            int current = topIndex;
            topIndex = ++topIndex;

            return deck.Cards.ElementAt(current);
        }

        [HttpGet("{action}")]
        public ActionResult<List<Card>> Shuffle(string action) 
        {
            Random rand = new Random();
            List<Card> newCards = new List<Card>();
            List<Card> currentCards = new List<Card>(deck.Cards);

            for (int i = 0; i <= MAX_INDEX; i++)
            {
                int index = rand.Next(MAX_INDEX - i);
                newCards.Add(currentCards.ElementAt(index));
                currentCards.RemoveAt(index);
            }
            deck.Cards = new List<Card>(newCards);
            topIndex = 0;
            
            return NoContent();
        }

        [HttpGet("{action}")]
        public ActionResult<List<Card>> Cut(string action) 
        {
            List<Card> newCards = new List<Card>();
            List<Card> currentCards = new List<Card>(deck.Cards);
            List<Card> firstHalf = currentCards.GetRange(0, 26);
            List<Card> secondHalf = currentCards.GetRange(26, 26);
            
            newCards.AddRange(secondHalf);
            newCards.AddRange(firstHalf);
            deck.Cards = new List<Card>(newCards);
            topIndex = 0;

            return NoContent();
        }
    }
}
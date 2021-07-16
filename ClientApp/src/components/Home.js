import React, { useState, useEffect } from 'react'
import { ButtonGroup, Row, Card, Col } from 'reactstrap'
import deckService from '../services/deck'

const Home = () => {
  const [cards, setCards] = useState([])

  const dealOneCard = () => {
    deckService
      .dealOneCard()
      .then(card => {
        if(!card){
          alert("No more cards! Time to shuffle.")
        } else {
          let newCards = [...cards]
          newCards.push(card)
          setCards(newCards)
        }
      })
  }

  const shuffle = () => {
    setCards([])
    deckService
      .shuffle()
      .then(() => {
        alert("Deck shuffled!")
      })
  }
  
  const cut = () => {
    setCards([])
    deckService
      .cut()
      .then(() => {
        alert("Deck cut!")
      })
  }
  return (
    <>
      <Row>
        <ButtonGroup>
          <button id="deal-btn" className="btn btn-secondary" onClick={dealOneCard}>
            Deal one card
          </button>
          <button id="shuffle-btn" className="btn btn-secondary" onClick={shuffle}>
            Shuffle deck
          </button>
          <button id="cut-btn" className="btn btn-secondary" onClick={cut}>
            Cut deck
          </button>
        </ButtonGroup>
      </Row>
      <Row>
        {cards.map(card => 
            <Col xs="2">
              <Card key={card.id}>
                <i className={`bi bi-suit-${card.suit}-fill`}></i>
                {card.rankName}
                <i className={`bi bi-suit-${card.suit}-fill`}></i>
              </Card>
            </Col>
          )}
      </Row>
    </>
  )
}

export default Home
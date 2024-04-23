using System;
using System.Collections.Generic;

public enum Suit { Hearts, Diamonds, Clubs, Spades }
public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

// 카드 한 장을 표현하는 클래스
public class Card
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    public Card(Suit s, Rank r)
    {
        Suit = s;
        Rank = r;
    }

    public int GetValue()
    {
        if ((int)Rank <= 10)
        {
            return (int)Rank;
        }
        else if ((int)Rank <= 13)
        {
            return 10;
        }
        else
        {
            return 11;
        }
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}

// 덱을 표현하는 클래스
public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();

        foreach (Suit s in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(s, r));
            }
        }

        Shuffle();
    }

    public void Shuffle()
    {
        Random rand = new Random();

        for (int i = 0; i < cards.Count; i++)
        {
            int j = rand.Next(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card DrawCard()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}

// 패를 표현하는 클래스
public class Hand
{
    private List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int GetTotalValue()
    {
        int total = 0;
        int aceCount = 0;

        foreach (Card card in cards)
        {
            if (card.Rank == Rank.Ace)
            {
                aceCount++;
            }
            total += card.GetValue();
        }

        while (total > 21 && aceCount > 0)
        {
            total -= 10;
            aceCount--;
        }

        return total;
    }
}

// 플레이어를 표현하는 클래스
public class Player
{
    public Hand Hand { get; private set; }

    public Player()
    {
        Hand = new Hand();
    }

    public Card DrawCardFromDeck(Deck deck)
    {
        Card drawnCard = deck.DrawCard();
        Hand.AddCard(drawnCard);
        return drawnCard;
    }
}

// 여기부터는 학습자가 작성
// 딜러 클래스를 작성하고, 딜러의 행동 로직을 구현하세요.
public class Dealer : Player
{
    // 코드를 여기에 작성하세요
    public void DrawDealerCard(Deck deck)
    {
        while (this.Hand.GetTotalValue() < 17)
        {
            Card dealerCard = DrawCardFromDeck(deck);
            Console.WriteLine($"딜러 카드  : {dealerCard.Suit} {dealerCard.Rank}");
            Console.WriteLine($"딜러 총 합 : {Hand.GetTotalValue()}");
        }
    }


}

// 블랙잭 게임을 구현하세요. 
public class Blackjack
{
    Player player = new Player();
    Dealer dealer = new Dealer();
    Deck deck = new Deck();

    public void PlayGame()
    {
        // 최초 2회 카드 드로우
        for (int k = 0; k < 2; k++)
        {
            player.DrawCardFromDeck(deck);
            dealer.DrawCardFromDeck(deck);
        }
        Console.WriteLine("StartGame\n");
        Console.WriteLine($"Player의 카드 합 : {player.Hand.GetTotalValue()}");
        Console.WriteLine($"Dealer의 카드 합 : {dealer.Hand.GetTotalValue()}");

        Console.WriteLine("==============<Player>================");
        // while문을 통해 player 카드를 먼저 셋팅
        while (player.Hand.GetTotalValue() < 21)
        {
            //카드 드로우를 할 것인가?
            Console.Write("카드를 드로우 하시겠습니까? (y/n) ");
            string input = Console.ReadLine();
            // 드로우 한다.
            if(input == "y")
            {
                Card drawCard = player.DrawCardFromDeck(deck);
                Console.WriteLine($"Player가 뽑은 카드 : {drawCard.Suit} {drawCard.Rank}");
                Console.WriteLine($"Player의 카드 합 : {player.Hand.GetTotalValue()}");
            }
            else if(input == "n")
            {
                break;
            }
            else
            {
                Console.WriteLine("올바른 값을 입력해주세요.");
            }
        }
        Console.WriteLine();
        // dealer 카드 셋팅
        Console.WriteLine("==============<Dealer>================");
        dealer.DrawDealerCard(deck);
        Console.WriteLine();
        // 최종 비교
        Console.WriteLine("==============<Result>================");
        CheckResult();
    }

    public void CheckResult()
    {
        int playerTotal = player.Hand.GetTotalValue();
        int dealerTotal = dealer.Hand.GetTotalValue();
        //Console.WriteLine($"Player : {playerTotal}, Dealer : {dealerTotal}");
        
        // 딜러 승리
        if(playerTotal > 21)
        {
            Console.WriteLine("플레이어 21 오버, 딜러 승리");
        }
        else if(dealerTotal > 21)
        {
            Console.WriteLine("딜러 21 오버, 플레이어 승리");
        }
        // 둘다 over가 아닌경우
        else if(playerTotal > dealerTotal)
        {
            Console.WriteLine("플레이어 승리!");
        }
        else
        {
            Console.WriteLine("딜러 승리!");
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        // 블랙잭 게임을 실행하세요
        Blackjack game = new Blackjack();
        game.PlayGame();
    }
}
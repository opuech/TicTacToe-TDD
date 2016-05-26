using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core;
using TicTacToe.Core.Monad;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Dto;
using TicTacToe.IDomain.Events;

namespace TicTacToe.Domain.GameAggregate
{
    public class Game : IGame
    {
        Guid gameId;
        Player[] players;
        Grid grid;
        
        int iCurrentPlayer;

       

        public Game(Maybe<IDomainEventChannel> domainEventChannel, 
                    Guid gameId, 
                    Player[] players, 
                    int iCurrentPlayer,
                    Grid grid)
        {
            this.DomainEventChannel = domainEventChannel;

            if (gameId == null)
                throw new ArgumentNullException("gameId");

            this.gameId = gameId;
            if (players == null)
                throw new ArgumentNullException("players");

            if (players.GetLength(0) != 2)
                throw new InvalidOperationException(
                    string.Format("invalid players range. Expected : 2. actual : {0}", 
                        players.GetLength(0)));

            if (players[0].PlayerCode == null)
                throw new ArgumentNullException("player1Code");

            if (players[1].PlayerCode == null)
                throw new ArgumentNullException("player2Code");

            this.players = players;

            if (!new int?[] { 0, 1, null }.Contains(iCurrentPlayer))
                throw new InvalidOperationException(
                    string.Format("invalid current player value. Expected : 0, 1 or null. actual : {0}",
                        iCurrentPlayer));

            this.iCurrentPlayer = iCurrentPlayer;

            this.grid = grid;


        }

        public Maybe<IDomainEventChannel> DomainEventChannel { get; set; }

        public string GetPlayer1Code()
        {
            return this.players[0].PlayerCode;
        }

        public string GetPlayer2Code()
        {
            return players[1].PlayerCode;
        }

        public string GetCurrentPlayerCode()
        {
            
            return players[iCurrentPlayer].PlayerCode;
            
        }

        private void NextPlayer()
        {
            iCurrentPlayer = (iCurrentPlayer + 1) % 2;
           
            DomainEventChannel.Do(
                x => x.Submit<CurrentPlayerChanged>(
                    new CurrentPlayerChanged(
                        new GameDto(GetCurrentGrid(), GetCurrentPlayerCode()))));
        }
        
        public string GetCurrentGrid()
        {
            return grid.ToString();
        }

        public void Start()
        {
            
            DomainEventChannel.Do(
                x => x.Submit<GameStarted>(
                    new GameStarted(
                        new GameDto(GetCurrentGrid(), GetCurrentPlayerCode()))));
        }

        

        public Result ApplyPlayerSelection(string playerCode, int x, int y)
        {
            if (playerCode.Equals(GetCurrentPlayerCode()))
            {
                 grid = grid.WithNewPlayerSelection(GetPlayer(playerCode), x, y);

                 NextPlayer();
            }

            return Result.Ok();
        }

     

        private Player GetPlayer(string playerCode)
        {
            return players.Where(x => x.PlayerCode == playerCode).First();
               
        }
    }
}
